using Ecommerce.Application.Common.Resources;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Application.Common.Behavioures
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IStringLocalizer<SharedResources> localizer, IEnumerable<IValidator<TRequest>> validators)
        {
            _localizer = localizer;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x => _localizer[$"{x.PropertyName}"] + " :" + x.ErrorMessage).FirstOrDefault();

                    throw new ValidationException(message);

                }
            }
            return await next();
        }
    }
}
