using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System_do_licencji.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
       

    }
}
