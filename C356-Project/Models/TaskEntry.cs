using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace C356_Project.Models
{
    public class TaskEntry
    {
        public int ID { get; set; }
        public string userTask { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User {get; set;}
        public string UserId { get; set; }

        public ICollection<Subtask> Subtasks { get; set; }
        public List<TaskEntry> myTaskList { get; set; }
    }
}
