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
        public string FullName { get; set; }
    }
}
