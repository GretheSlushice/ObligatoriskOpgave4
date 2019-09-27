using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpligatoriskOpgave1;

namespace ObligatoriskOpgave4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Bog> bogListe = new List<Bog>();

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return bogListe;
        }

        // GET: api/Books/5
        [HttpGet("{isbn13}", Name = "Get")]
        public Bog Get(string isbn13)
        {
            return bogListe.Find(e => e.Isbn13 == isbn13);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            bogListe.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Bog value)
        {
            Bog bog = Get(isbn13);
            if (bog != null)
            {
                bog.Titel = value.Titel;
                bog.Forfatter = value.Forfatter;
                bog.SideTal = value.SideTal;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Bog bog = Get(isbn13);
            bogListe.Remove(bog);
        }
    }
}
