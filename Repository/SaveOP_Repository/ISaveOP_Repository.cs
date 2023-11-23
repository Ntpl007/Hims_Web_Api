using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hims_WebAPI.ViewModel;

namespace Hims_WebAPI.Repository.SaveOP_Repository
{
    interface ISaveOP_Repository
    {
        public OpCreateResult SaveOP(OpInput input);
        public OpCreateResult SaveOPExisting(OpInput input);
    }
}
