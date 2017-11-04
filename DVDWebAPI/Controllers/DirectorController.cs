using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDWEBAPIData;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;
using System.Web.Http.Cors;

namespace DVDWebAPI.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DirectorController : ApiController
    {
        static IDirectorRepository _dirRepo = DirectorFactory.Create();

        [Route("directors")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_dirRepo.GetDirectorList());
        }
        
    }
}