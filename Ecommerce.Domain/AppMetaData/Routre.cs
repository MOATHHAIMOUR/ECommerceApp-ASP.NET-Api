namespace Ecommerce.Domain.AppMetaData
{
    public static class Routre
    {
        public const string root = "Api";
        public const string version = "v1";
        public const string rule = root + "/" + version + "/";


        public static class CrudOpreations
        {
            public const string GetList = "Create";

            public const string GetById = "{Id}";

            public const string Create = "Create";

            public const string Update = "Update";

            public const string Delete = "Delete";
        }


        public static class StudentRouting
        {
            public const string prefix = rule + "Product/";


            public const string List = prefix + CrudOpreations.GetList;

            public const string GetById = prefix + CrudOpreations.GetById;

            public const string Create = prefix + CrudOpreations.Create;

            public const string Update = prefix + CrudOpreations.Update;

            public const string Delete = prefix + CrudOpreations.Delete + "/" + CrudOpreations.GetById;
        }


    }
}
