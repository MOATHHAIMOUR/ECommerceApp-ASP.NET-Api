namespace Ecommerce.Application.Common.pagination
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ToPaginated<T>(this IQueryable<T> source, int pageNumber, int pageSize)
           where T : class
        {

            if (source == null)
            {
                throw new Exception("Empty");
            }

            //set defualt values
            pageNumber = pageNumber == 0 ? 1 : pageNumber;

            pageSize = pageSize == 0 ? 10 : pageSize;

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;

            source = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return source;
        }




    }
}
