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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void Update(ShoppingCart obj)
        {
            _context.ShoppingCarts.Update(obj);
        }
    }
}
