using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hims_WebAPI.ViewModel;

namespace Hims_WebAPI.Management
{
    interface ISaveOP_Management
    {
   public OpCreateResult SaveOP(OpInput input);
    }
}
