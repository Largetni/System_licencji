using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System_do_licencji.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string Address { get; set; }
        public int RegionId { get; set; }
        public bool HasFirstLicense { get; set; }
        public bool HasSecondLicense { get; set; }
        public bool HasThirdLicense { get; set; }
        public bool ClubLicenseIsRenewed { get; set; }
    }
}
