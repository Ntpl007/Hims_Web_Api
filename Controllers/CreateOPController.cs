using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hims_WebAPI.ViewModel;

using Microsoft.AspNetCore.Cors;
using Hims_WebAPI.Repository.SaveOP_Repository;
using Hims_WebAPI.Management;

namespace Hims_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreateOPController : ControllerBase
    {
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
     public  OpCreateResult SaveOp(OpInput input,long patid)
        {
            SaveOP_Management obj= new SaveOP_Management();
            var respnse= obj.SaveOP(input);
            return respnse;

        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        public OpCreateResult SaveOPExisting(OpInput input)
        {
            SaveOP_Repository obj = new SaveOP_Repository();
            var respnse = obj.SaveOPExisting(input);
            return respnse;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        public OpCreateResult SaveExistingOp(OpInput input)
        {
            OpCreateResult obj = new OpCreateResult();
            SaveOP_Repository n = new SaveOP_Repository();
            return n.SaveExistingOP(input);

        }




    }
}
