using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Mar_2022.Data.Interfaces;
using Web_API_Mar_2022.ModelDto;
using Web_API_Mar_2022.Models;

namespace Web_API_Mar_2022.Data.SqlRepos
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly Mapper _mapper = new Mapper();
        private readonly AppDbContext _context;

        public SqlProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(ProductCreateDto input)
        {
            Product newProduct = _mapper.Map(input);

            _context.Add(newProduct);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productInDb = _context.Products.ToList()
                 .Find(p => p.Id == id);

            if (productInDb != null)
            {
                _context.Remove(productInDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ProductReadDto> GetAll()
        {
            var products = _context.Products.Select(p => _mapper.Map(p)).ToList();

            return products;
        }

        public ProductReadDto GetById(int id)
        {
            var productInDb = _context.Products.ToList()
                .Find(p => p.Id == id);

            return _mapper.Map( productInDb );
        }

        public void Update(int id, ProductCreateDto input)
        {
            var productInDb = _context.Products.ToList()
                .Find(p => p.Id == id);

            if (productInDb != null)
            {
                productInDb.Name = input.Name;
                productInDb.Price = input.Price;

                _context.SaveChanges();
            }
        }
    }
}
