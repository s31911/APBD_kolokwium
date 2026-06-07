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
    public async Task<GetOrderDto> GetOrder(int id)
    {
        var checkIfExists = await _dbContext.Orders.AnyAsync(item => item.OrderId == id);
        if (!checkIfExists)
        {
            throw new NotFoundException($"Order with id {id} not found!");
        };
        
        var result = await _dbContext.Orders.Where(item => item.OrderId == id).Select(
            order => new GetOrderDto()
            {
                OrderId =  order.OrderId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                User = order.user.UserName,
                Payments = order.Payments.Select(payment => new GetOrderDto.PaymentsDTO()
                {
                    PaymentId = payment.PaymentId,
                    PaymentMethod = payment.PaymentMethod,
                    Amount =   payment.Amount,
                    Status = payment.PaymentStatus
                }).ToList(),
                OrderItems = order.OrderItemsCollection.Select(items => new GetOrderDto.OrderItemsDTO()
                    {
                        Quantity = items.Quantity,
                        Price = items.Price,
                        Product = new GetOrderDto.ProductDto()
                        {
                            ProductsId = items.ProductId,
                            Name = items.Product.Name,
                            Description = items.Product.Description,
                            Price = items.Product.Price,
                            StockQuantity =  items.Product.StockQuantity,
                        }
                        
                    }
                    
                    ).ToList(),
                
            }
            
            
            
            ).FirstOrDefaultAsync();
        
        return result;
    }

    public async Task UpdateOrder(int id,UpdateOrderDto order)
    {
        
        var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var myorder = _dbContext.Orders.FirstOrDefault();

            if (myorder == null)
            {
                throw new NotFoundException("ORDER NOT FOUND");
            }

            myorder.Status = "Processed";
            foreach (var orderItemse in myorder.OrderItemsCollection)
            {
                orderItemse.Price =  orderItemse.Price * (decimal) 0.9 ;
                
            }
            
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
        
    }
}