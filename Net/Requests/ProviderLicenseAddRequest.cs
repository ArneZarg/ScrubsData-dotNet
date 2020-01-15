﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sabio.Models.Requests.Licenses
{
    public class ProviderLicenseAddRequest
    {
        [Required]
        [Range(1,Int32.MaxValue)]
        public int LicenseStateId {get;set;}
        [Required]
        [StringLength(50)]
        public string LicenseNumber { get; set; }
        public DateTime DateExpires { get; set; }
    }
}
