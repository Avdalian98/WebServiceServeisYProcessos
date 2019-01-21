using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS1.Models;

namespace WS1.Controllers
{
    public class TelefonsController : ApiController
    {
        // GET: api/telefons
        [Route("api/telefons")]
        public HttpResponseMessage Get()
        {
            var telefons = TelefonsRepository.GetAllTelefons();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefons);
            return response;
        }

        [Route("api/telefons/{name:alpha}")]
        public HttpResponseMessage Get(string telefon)
        {
            var telefons = TelefonsRepository.SearchTelefonByName(telefon);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefons);
            return response;
        }
    }
}
