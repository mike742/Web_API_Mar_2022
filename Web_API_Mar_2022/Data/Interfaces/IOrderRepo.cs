using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.ModelDto;

namespace Web_API_Mar_2022.Data.Interfaces
{
    public interface IOrderRepo
    {
        public IEnumerable<OrderReadDto> GetAll();
        public OrderReadDto GetById(int id);
        public void Create(OrderCreateDto order);
        public void Update(int id, OrderCreateDto order);
        public void Delete(int id);
    }
}
