using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class AddVitalSignsToSpecialityVo
    {
       
        public int VitalSignId { get; set; }
        public int FacilityId { get; set; }
        public int SpecialityId { get; set; }
        public int OrganizationId { get; set; }
        public string CreatedBy { get; set; }
    }
}
