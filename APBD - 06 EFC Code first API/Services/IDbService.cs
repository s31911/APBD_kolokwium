using APBD___06_EFC_Code_first_API.DTOs;
using APBD___06_EFC_Code_first_API.Entities;

namespace APBD___06_EFC_Code_first_API.Services;

public interface IDbService
{
    Task<Orders> GetOrder(int id);
    Task UpdateOrder(int id,UpdateOrderDto order);
}