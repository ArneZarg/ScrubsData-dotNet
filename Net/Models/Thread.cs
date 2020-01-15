using System;
using System.Collections.Generic;
using System.Text;

namespace Sabio.Models.Domain.Forums
{
    public class Thread
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Summary { get; set; }
        public string Information { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
