namespace TMS.Application.Common.Constants
{
    public static class AppConstant
    {
        public const string DB_NAME = "TMSDB";
        public const string JWT_TOKEN_KEY = "TokenKey";

        public const string ACCOUNT_CONFIMATION_SUBJECT = "Confirmation Email";
    }
    public static class Roles
    {
        public const string ADMIN = "Administrator";
        public const string ORGANIZER = "Organizer";
        public const string CUSTOMER = "Customer";
    }
    public static class RolesPolicy
    {
        public const string ADMIN_POLICY = "RequireAdminRole";
        public const string ORGANIZER_POLICY = "RequireOrganizerRole";
        public const string CUSTOMER_POLICY = "RequireCustomerRole";
    }
}
