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
            public const string GetInfo = Base + "/user/info";

            public const string Appointment = Base + "user/appointment";


        }
    }
}
