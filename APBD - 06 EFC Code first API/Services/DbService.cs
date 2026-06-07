using APBD___06_EFC_Code_first_API.Data;
using APBD___06_EFC_Code_first_API.DTOs;
using APBD___06_EFC_Code_first_API.Entities;
using APBD___06_EFC_Code_first_API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD___06_EFC_Code_first_API.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    // public async  Task<IEnumerable<PcsComponentsDto>> GetPcsComponents(int id)
    // {
    //
    //     var res = await _dbContext.Components.Join(_dbContext.PcComponents,
    //             component => component.Code,
    //             pccomponent => pccomponent.ComponentCode,
    //             (component, pccomponent) => new { component, pccomponent }
    //         )
    //         .Where(comp => comp.pccomponent.PcId == id)
    //         .Select(comp => new PcsComponentsDto()
    //         {
    //             Amount = comp.pccomponent.Amount,
    //             Name = comp.component.Name,
    //             Description = comp.component.Description,
    //             
    //         }).ToListAsync();
    //
    //     if (res.Count == 0)
    //     {
    //         throw new NotFoundException();
    //     }
    //
    //     return res;
    // }
    //
    // public async Task AddPcAsync(AddPcDto pcDto)
    // {
    //
    //     await _dbContext.Pcs.AddAsync(new Pc()
    //     {
    //         Name =  pcDto.Name,
    //         Stock = pcDto.Stock,
    //         Warranty = pcDto.Warranty,
    //         CreatedAt = pcDto.CreatedAt,
    //         Weight = pcDto.Weight,
    //     });
    //
    //     await _dbContext.SaveChangesAsync();
    // }
    //
    // public async Task UpdatePcAsync(int id, UpdatePcDto pcDto)
    // {
    //     var pc = await _dbContext.Pcs.FirstOrDefaultAsync(e => e.Id == id);
    //     if (pc == null)
    //     {
    //         throw new NotFoundException();
    //     }
    //     pc.Name =  pcDto.Name;
    //     pc.Stock = pcDto.Stock;
    //     pc.Warranty = pcDto.Warranty;
    //     pc.CreatedAt = pcDto.CreatedAt;
    //     pc.Weight = pcDto.Weight;
    //     
    //     await _dbContext.SaveChangesAsync();
    // }
    //
    // public async Task DeletePcAsync(int id)
    // {
    //     var affectedRows = await _dbContext.Pcs.Where(e => e.Id == id).ExecuteDeleteAsync();
    //     if (affectedRows == 0)
    //     {
    //         throw new NotFoundException();
    //     }
    // }
    //
    // public async Task<IEnumerable<GetPcDto>> GetAllPcs()
    // {
    //     var res = await _dbContext.Pcs.Select(
    //         pc=> new GetPcDto
    //         {
    //             Id = pc.Id,
    //             Name = pc.Name,
    //             Stock = pc.Stock,
    //             Warranty = pc.Warranty,
    //             Weight =  pc.Weight,
    //             CreatedAt = pc.CreatedAt,
    //         }
    //         ).ToListAsync();
    //
    //     
    //     return res;
    //
    // }
    public async Task<Orders> GetOrder(int id)
    {
        var checkIfExists = await _dbContext.Orders.AnyAsync(item => item.OrderId == id);
        if (!checkIfExists)
        {
            throw new NotFoundException($"Order with id {id} not found!");
        };
        
        var result = _dbContext.Orders.FirstOrDefault(item => item.OrderId == id);
        throw new Exception("TMP");
    }

    public async Task UpdateOrder(int id,UpdateOrderDto order)
    {
        throw new NotImplementedException();
    }
}