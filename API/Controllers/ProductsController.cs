using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ProductsController : BaseApiController
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<ProductDto>>> GetPagedListAsync
    ([FromQuery] ProductParams param)
    {
        var data = await _productRepository.GetPagedListAsync(param);

        Response.AddPaginationHeader(new(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages));

        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetDtoByIdAsync([FromRoute]int id)
    {
        var item = await _productRepository.GetDtoByIdAsync(id);

        if (item == null) return NotFound($"Product with id {id} not found.");

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> AddAsync([FromBody] ProductCreateDto request)
    {
        Product item = _mapper.Map<Product>(request);

        _productRepository.Add(item);

        if (!await _productRepository.SaveAllAsync()) return BadRequest("Error al crear nuevo producto.");

        return Ok(await _productRepository.GetDtoByIdAsync(item.Id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> UpdateAsync([FromBody] ProductUpdateDto request, [FromRoute]int id)
    {
        var itemToUpdate = await _productRepository.GetByIdAsync(id);
        
        if (itemToUpdate == null) return NotFound($"Producto con id {id} no encontrado.");

        _mapper.Map(request, itemToUpdate);
        
        if (!await _productRepository.SaveAllAsync()) return BadRequest("Error al actualizar producto.");

        return Ok(await _productRepository.GetDtoByIdAsync(itemToUpdate.Id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute]int id)
    {
        var itemToDelete = await _productRepository.GetByIdAsync(id);

        if (itemToDelete == null) return NotFound($"Producto con id {id} no encontrado.");

        _productRepository.Delete(itemToDelete);

        if (!await _productRepository.SaveAllAsync()) return BadRequest("Error al eliminar producto.");

        return Ok();
    }
    
}