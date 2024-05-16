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
            var objFromDb = _context.Products.FirstOrDefault(u=>u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Type = obj.Type;
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;    
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                if(obj.ImageUrl != null) { 
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
