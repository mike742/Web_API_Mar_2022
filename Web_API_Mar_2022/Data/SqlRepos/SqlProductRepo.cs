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

        public IEnumerable<ProductReadDto> GetAll()
        {
            var products = _context.Products.Select(p => _mapper.Map(p)).ToList();

            return products;
        }
    }
}
