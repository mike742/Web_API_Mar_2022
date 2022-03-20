using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.ModelDto;
using Web_API_Mar_2022.Models;

namespace Web_API_Mar_2022.Data.Interfaces
{
    public interface IProductRepo
    {
        public IEnumerable<ProductReadDto> GetAll();
    }
}
