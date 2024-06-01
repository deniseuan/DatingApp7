namespace API.DTOs;
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; }
    public BrandDto Brand { get; set; }
}