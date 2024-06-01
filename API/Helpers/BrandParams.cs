namespace API.Helpers;
public class BrandParams : PaginationParams
{
    public string OrderBy { get; set; } = "name";
}