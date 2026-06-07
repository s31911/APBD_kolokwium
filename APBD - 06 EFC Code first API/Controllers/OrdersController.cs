using APBD___06_EFC_Code_first_API.DTOs;
using APBD___06_EFC_Code_first_API.Exceptions;
using APBD___06_EFC_Code_first_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD___06_EFC_Code_first_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : Controller
{
    private readonly IDbService _dbService;
    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetOrder(int id)
    {
        try
        {
            var res = await _dbService.GetOrder(id);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound();
            
        }
    }
    
    
   
    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpadtePc(int id,UpdateOrderDto orderDto)
    {
        try
        {
            await _dbService.UpdateOrder(id,orderDto);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
            
        }
        
    }
    
}