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
        public ProductReadDto GetById(int id);
        public void Create(ProductCreateDto inputs);
        public void Update(int id, ProductCreateDto input);
        public void Delete(int id);
    }
}
