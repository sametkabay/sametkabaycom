namespace SametKabay.Application
{
    public interface IPaged
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}