﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Hims_WebAPI.BHISHAK_APP_DB
{
    public partial class TblAdmPatientRelation
    {
        public int RelationId { get; set; }
        public string Relation { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
