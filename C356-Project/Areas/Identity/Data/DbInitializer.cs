using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C356_Project.Models;

using TaskEntry = C356_Project.Models.TaskEntry;

namespace C356_Project.Areas.Identity.Data
{
    public static class DbInitializer
    {
        public static void Initalize(C356_AuthDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.TaskEntry.Any())
            {
                return;
            }

            var tasksEntries = new TaskEntry[] {
                new TaskEntry{userTask = "Write Book"},
                new TaskEntry{userTask = "Sew sweater"},
                new TaskEntry{userTask = "Run a 5k"},
                new TaskEntry{userTask = "Code neural net"},
            };
            foreach (TaskEntry t in tasksEntries)
            {
                context.TaskEntry.Add(t);
            }
            context.SaveChanges();
        }
    }
}
