using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SportPit.Models.Dto;
using SportPit.Repositories.Interfaces;

namespace SportPit.Repositories;

public class OrderRepository : IOrderRepository
{
    public Dictionary<ProductCartDto, int> CountProductsByProductId { get; } = [];

    public decimal Sum =>
        CountProductsByProductId.Sum(productCount => productCount.Key.Price * productCount.Value);

    public void Add(ProductCartDto productCartDTO)
    {
        if (CountProductsByProductId.TryGetValue(productCartDTO, out int count))
        {
            CountProductsByProductId[productCartDTO] = ++count;
        }
        else
        {
            CountProductsByProductId.Add(productCartDTO, 1);
        }
    }

    public void Clear()
    {
        CountProductsByProductId.Clear();
    }

    public void Remove(ProductCartDto productCartDTO)
    {
        if (CountProductsByProductId.TryGetValue(productCartDTO, out int count))
        {
            CountProductsByProductId[productCartDTO] = --count;

            if (count == 0)
            {
                CountProductsByProductId.Remove(productCartDTO);
            }
        }
    }
}