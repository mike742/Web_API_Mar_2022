using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.Data.Interfaces;
using Web_API_Mar_2022.ModelDto;

namespace Web_API_Mar_2022.Data.SqlRepos
{
    public class SqlOrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public SqlOrderRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderReadDto> GetAll()
        {
            var orders = _context.Orders.Select(o => _mapper.Map(o)).ToList();
            var products = _context.Products.Select(p => _mapper.Map(p)).ToList();
            var orderProducts = _context.OrderProduts.ToList();

            foreach (var order in orders)
            {
                List<ProductReadDto> productsToAdd = new List<ProductReadDto>();

                foreach (var op in orderProducts)
                {
                    if (op.OrderId == order.Id)
                    {
                        var p = products.Find(p => p.Id == op.ProductId);
                        productsToAdd.Add(p);
                    }
                }

                order.Products = productsToAdd;
            }

            return orders;
        }
    }
}
