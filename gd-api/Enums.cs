namespace gd_api
{
    [Flags]
    public enum CompanyIncludeDetails
    {
        Undefined = 0,
        Address = 1,
        File = 2,
        All = 4,
    }

    [Flags]
    public enum ProductIncludeDetails
    {
        Undefined = 0,
        File = 1,
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
