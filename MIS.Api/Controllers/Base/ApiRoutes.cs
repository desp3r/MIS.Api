namespace MIS.Api.Controllers.Base
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Register = Base + "/identity/user/register";

            public const string Login = Base + "/identity/user/login";

        }

        public static class User
        {
            public const string CRUD = Base + "/user";

            public const string List = Base + "user/list";


        }
        public static class Employee
        {
            public const string CRUD = Base + "/employee";

            public const string List = Base + "/employee/list";
        }

        public static class Appointment
        {
            public const string CRUD = Base + "/appointment";

            public const string List = Base + "/appointment/list";
        }
    }
}
