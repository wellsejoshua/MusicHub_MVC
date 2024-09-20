using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicHub.DataAccess.Data;
using MusicHub.Models;
using MusicHub.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {



            //Migrations if Not Applied 
            try
            {
                if(_context.Database.GetPendingMigrations().Count () > 0)
                {
                    _context.Database.Migrate();
                }

            }
            catch (Exception)
            {

                throw;
            }
            //Create roles if none
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();

                //if roles are not created, create admin user too
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@musichub.com",
                    Email = "admin@musichub.com",
                    Name = "Admin Josh",
                    PhoneNumber = "1234567890",
                    StreetAddress = "1234 adminTest Rd.",
                    State = "IL",
                    PostalCode = "12345",
                    City = "Chicago",
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@musichub.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }

            return;
          
        }
    }
}
