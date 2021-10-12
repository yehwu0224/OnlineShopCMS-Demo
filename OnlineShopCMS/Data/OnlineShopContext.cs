using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopCMS.Models;
using OnlineShopCMS.Areas.Identity.Data;

namespace OnlineShopCMS.Data
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext (DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineShopCMS.Models.Product> Product { get; set; }
        public DbSet<OnlineShopCMS.Models.Category> Category { get; set; }
        public DbSet<OnlineShopCMS.Models.Comment> Comment { get; set; }
        
    }
}
