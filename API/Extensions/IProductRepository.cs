using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Extensions;
public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<Product> GetAsNoTrackingByIdAsync(int id);
    Task<ProductDto> GetDtoByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetListAsync();
    void Add(Product item);
    void Delete(Product item);
    Task<PagedList<ProductDto>> GetPagedListAsync(ProductParams param);
    Task<bool> SaveAllAsync();
}