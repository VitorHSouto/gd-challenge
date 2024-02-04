namespace gd_api
{
    [Flags]
    public enum CompanyIncludeDetails
    {
        Undefined = 0,
        Address = 1,
        All = 2,
    }

    public enum CustomExceptionError
    {
        Undefined,
        NotFound,
        FormError,
        Unauthorized,
    }
}
