﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Hims_WebAPI.BHISHAK_APP_DB
{
    public partial class TblAdmState
    {
        public TblAdmState()
        {
            TblAppointmentPatientTemps = new HashSet<TblAppointmentPatientTemp>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Updatedby { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TblAppointmentPatientTemp> TblAppointmentPatientTemps { get; set; }
    }
}
