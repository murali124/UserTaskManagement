using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Model
{
    public class Job
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public class JobUserIdMapping
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
    }

    public class JobUserMapping : JobUserIdMapping
    {
        public string UserName { get; set; }
        public string JobName { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
