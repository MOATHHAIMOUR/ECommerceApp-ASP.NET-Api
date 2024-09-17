using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common.Extentions;
using Ecommerce.Application.Common.Results;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries;
using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services.ProductServices
{
    public class ProductServices : IProductServices
    {

        private readonly IProductrRepository _productrRepository;
        private IMapper _mapper;

        public ProductServices(IProductrRepository productrRepository, IMapper mapper)
        {
            _productrRepository = productrRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProductDTO>>> GetAllProductsPaginatedAsync(Dictionary<string, string>? Filters, Dictionary<string, string>? Ordering, int PageNumber = 1, int PageSize = 10)
        {
            //1-Get Products 
            var query = _productrRepository.GetTableNoTracking()
                .ToPaginated(PageNumber, PageSize);

            //2-include categorey
            query = query.Include(p => p.Category);

            //3-Applay Filters if exist
            if (Filters != null && Filters.Any())
                query = query.CustomFiltering(Filters);

            //3-Applay ordering if exist
            if (Filters != null && Ordering.Any())
                query = query.CustomOrdering(Ordering);

            //3-fetch all products
            List<ProductDTO> ProductsDTO = await
                query.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return Result<List<ProductDTO>>.Succsess(ProductsDTO);
        }

        public async Task<Result<ProductDTO>> GetProductById(int Id)
        {
            var Product = await _productrRepository.GetById(Id, Include => Include.Category)
                .FirstOrDefaultAsync();

            return Result<ProductDTO>.Succsess(_mapper.Map<ProductDTO>(Product));

        }

        public async Task<int> AddAsync(Product product)
        {
            var Product = await _productrRepository.AddAsync(product);
            return Product.Id;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            return await _productrRepository.UpdateAsync(product);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _productrRepository.IsExist(id);
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            return await _productrRepository.DeleteAsync(product);
        }


    }
}
