﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Hims_WebAPI.BHISHAK_APP_DB
{
    public partial class TblAdmOccupationMaster
    {
        public int Id { get; set; }
        public string Occupation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
