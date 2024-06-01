using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(Product item)
    {
        _context.Add(item);
    }

    public void Delete(Product item)
    {
        _context.Remove(item);
    }

    public async Task<Product> GetAsNoTrackingByIdAsync(int id)
    {
        return await _context.Products
            .Include(x => x.ProductBrand)
                .ThenInclude(x => x.Brand)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ProductDto> GetDtoByIdAsync(int id)
    {
        return await _context.Products
            .Include(x => x.ProductBrand)
                .ThenInclude(x => x.Brand)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(x => x.ProductBrand)
                .ThenInclude(x => x.Brand)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<ProductDto>> GetListAsync()
    {
        return await _context.Products
            .Include(x => x.ProductBrand)
                .ThenInclude(x => x.Brand)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PagedList<ProductDto>> GetPagedListAsync(ProductParams param)
    {
            var query = _context.Products
                .Include(x => x.ProductBrand)
                    .ThenInclude(x => x.Brand)
                .AsQueryable();

            query = param.OrderBy switch
            {
                "name" => query.OrderByDescending(u => u.Name),
                _ => query.OrderByDescending(u => u.Name)
            };

            return await PagedList<ProductDto>.CreateAsync(
             query.AsNoTracking().ProjectTo<ProductDto>(_mapper.ConfigurationProvider),
             param.PageNumber,
             param.PageSize);

    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}