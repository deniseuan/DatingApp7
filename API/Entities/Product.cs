namespace API.Entities;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public ICollection<ProductPhoto> ProductPhotos { get; set; } = [];
    public ProductBrand ProductBrand { get; set; }
}