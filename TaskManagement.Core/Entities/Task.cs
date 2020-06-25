using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Core.EntitiesEnums;

namespace TaskManagement.Core.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
