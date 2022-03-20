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
    }
}
