namespace API.Entities;
public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ProductBrand> ProductBrands { get; set; } = [];
}