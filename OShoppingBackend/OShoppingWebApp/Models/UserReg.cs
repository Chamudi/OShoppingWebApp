using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OShoppingWebApp.Models
{
    public class UserReg : IdentityUser
    {
        public int CustomerId { get; set; }
        public string CusName { get; set; }
        public string CusEmail { get; set; }
        public string CusMobile { get; set; }
        public string CusAddress { get; set; }      
        public string CusPassword { get; set; }
    }
}
