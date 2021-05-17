using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Model
{
    public class Job
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public class JobUserMapping
    {
        public int JobId { get; set; }
        public string UserId { get; set; }        
    }
}
