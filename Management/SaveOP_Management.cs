using Hims_WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hims_WebAPI.Repository.SaveOP_Repository;

namespace Hims_WebAPI.Management
{
    public class SaveOP_Management : ISaveOP_Management
    {
        public OpCreateResult SaveOP(OpInput input)
        {
            SaveOP_Repository obj = new SaveOP_Repository();
            return obj.SaveOP(input);
        }
    }
}

