namespace API.Entities;
public class ProductBrand
{
    public int ProductId { get; set; }
    public int BrandId { get; set; }

    public Product Product { get; set; }
    public Brand Brand { get; set; }

    public ProductBrand() {}

    public ProductBrand(int brandId)
    {
        BrandId = brandId;
    }
}