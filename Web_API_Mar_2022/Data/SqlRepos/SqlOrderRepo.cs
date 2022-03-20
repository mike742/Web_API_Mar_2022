using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.Data.Interfaces;
using Web_API_Mar_2022.ModelDto;
using Web_API_Mar_2022.Models;

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

        public void Create(OrderCreateDto order)
        {
            Order newOrder = _mapper.Map(order);
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            foreach (int item in order.ProductIds)
            {
                OrderProduts op = new OrderProduts
                {
                    OrderId = newOrder.Id,
                    ProductId = item
                };
                _context.OrderProduts.Add(op);
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order orderToDelete = _context.Orders.ToList().Find(o => o.Id == id);

            if (orderToDelete != null)
            {
                _context.Orders.Remove(orderToDelete);

                var rangeOfProducts = _context.OrderProduts.Where(op => op.OrderId == id);
                _context.OrderProduts.RemoveRange(rangeOfProducts);

                _context.SaveChanges();
            }
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

        public OrderReadDto GetById(int id)
        {
            var order = _context.Orders
                .Where(o => o.Id == id)
                .Select(o => _mapper.Map(o))
                .FirstOrDefault();
            var orderProducts = _context.OrderProduts.ToList();
            var products = _context.Products.Select(p => _mapper.Map(p)).ToList();

            if (order != null)
            {
                List<ProductReadDto> productsToAdd = new List<ProductReadDto>();

                foreach (var op in orderProducts)
                {
                    if (op.OrderId == id)
                    {
                        var p = products.Find(p => p.Id == op.ProductId);
                        productsToAdd.Add(p);
                    }
                }

                order.Products = productsToAdd;
            }

            return order;
        }

        public void Update(int id, OrderCreateDto order)
        {
            var orderFromDb = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (orderFromDb != null)
            {
                orderFromDb.Name = order.Name;
                orderFromDb.Date = order.Date;

                _context.SaveChanges();
            }

            var rangeProducts = _context.OrderProduts
                .Where(op => op.OrderId == id).ToList();

            _context.OrderProduts.RemoveRange(rangeProducts);

            foreach (var item in order.ProductIds)
            {
                var op = new OrderProduts
                {
                    OrderId = id,
                    ProductId = item
                };

                _context.OrderProduts.Add(op);
            }
            _context.SaveChanges();
        }
    }
}
