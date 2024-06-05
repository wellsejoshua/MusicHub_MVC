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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(OrderDetail obj)
        {
            _context.OrderDetails.Update(obj);
        }
    }
}
