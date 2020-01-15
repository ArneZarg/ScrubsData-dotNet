using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sabio.Models.Requests.Forums
{
    public class ThreadAddRequest
    {
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        [StringLength(200)]
        public string Summary { get; set; }

        [Required]
        [StringLength(4000)]
        public string Information { get; set; }
    }
}
