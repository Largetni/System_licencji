using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System_do_licencji.Models
{
    public class Player : IdentityUser
    {
       // public override string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int ClubId { get; set; }
        public bool HasFirstLicense { get; set; }
        public bool HasSecondLicense { get; set; }
        public bool HasThirdLicense { get; set; }
        public bool LicenseIsRenewed { get; set; }

        public Player() : base() { }
     

    }
}
