using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.ModelDto;
using Web_API_Mar_2022.Models;

namespace Web_API_Mar_2022.Data
{
    public class Mapper
    {
        public Product Map(ProductReadDto input)
        {
            return new Product { 
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }
        public ProductReadDto Map(Product input)
        {
            return new ProductReadDto {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }
        public ProductCreateDto Map(Product input, bool create)
        {
            return new ProductCreateDto { 
                Name = input.Name,
                Price = input.Price
            };
        }
        public Product Map(ProductCreateDto input)
        {
            return new Product { 
                Name = input.Name,
                Price = input.Price
            };
        }

        public OrderReadDto Map(Order order)
        {
            return new OrderReadDto
            {
                Id = order.Id,
                Date = order.Date,
                Name = order.Name
            };
        }
        public Order Map(OrderReadDto order)
        {
            return new Order
            {
                Id = order.Id,
                Date = order.Date,
                Name = order.Name
            };
        }
    }
}
