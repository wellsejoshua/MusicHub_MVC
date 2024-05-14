using MusicHub.DataAccess.Data;
using MusicHub.DataAccess.Repository.IRepository;
using MusicHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void Update(Product obj)
        {
            _context.Products.Update(obj);
        }
    }
}
