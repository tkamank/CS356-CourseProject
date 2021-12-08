using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C356_Project.Models;

namespace C356_Project.Data
{
    public class C356_ProjectContext : DbContext
    {
        public C356_ProjectContext (DbContextOptions<C356_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<C356_Project.Models.TaskEntry> TaskEntry { get; set; }
    }
}
