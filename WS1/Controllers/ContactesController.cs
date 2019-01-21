using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS1.Models;
namespace WS1.Controllers
{
    
    public class ContactesController : ApiController
    {
        public bool todo = false;
        // GET: api/contactes
        [Route("api/contactes")]
        public HttpResponseMessage Get()
        {
            var contactes = ContactesRepository.GetAllContactes();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        [Route("api/contactes/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var contactes = ContactesRepository.SearchContactesByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        // GET: api/contacte/5
        [Route("api/contacte/{id?}")]
        public HttpResponseMessage GetContacte(int id)
        {
            var contacte = ContactesRepository.GetContacte(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
            return response;
        }
        // GET: api/contacte/5
        [Route("api/contacteTot/{id?}")]
        public HttpResponseMessage GetContacteTot(int id)
        {
             var contacte = ContactesRepository.GetContacte(id);
             var telefon = TelefonsRepository.GetTelefon(contacte.contacteId);
            todo = true;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
            return response;
        }

        // PUT: api/contacte/5
        [Route("api/contacte/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody]contacte val)
        {
            var contacte = ContactesRepository.UpdateContacte(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
            return response;

        }

    }
}
