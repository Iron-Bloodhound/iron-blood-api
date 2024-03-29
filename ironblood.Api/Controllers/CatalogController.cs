using Microsoft.AspNetCore.Mvc;
using ironblood.Domain.Catalog;
using ironblood.Data;
using Microsoft.EntityFrameworkCore;
using ironblood.Api.Security;
using Microsoft.AspNetCore.Authorization;
using System.Security.Policy;

namespace ironblood.Api.Controllers
{
    [ApiController]
    // made this change 
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;
        
        public CatalogController(StoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        //Made it as far as getting the code from Auth0 but could not figure out how to get it run with it in here. 
        //Just wanted to show we at least got this far. 
        //
        //### GET Token from Auth0
        //curl --request POST \
        //--Url https://dev-4d632sdt18goxks6.us.auth0.com/oauth/token \
        //--header 'content-type: application/json' \
        //--data '{"client_id":"hOLVQPlPgPsjsFadykWL6eRFUZGc22hv","client_secret":"yNFfhODlmhfxD0Gd3qUG6IXpwCXNMoY77M7fBp_uukLFerCurrcUXrK5DRY0QOb2","audience":"http://localhost:5253/swagger/index.html","grant_type":"client_credentials"}'

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating (int id, [FromBody] Rating rating)
        {

            var item = _db.Items.Find(id);
            if(item == null)
            {
                return NotFound();
            }

            item.AddRating(rating);
            _db.SaveChanges();
            return Ok(item);

        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            if(id != item.Id)
            {
                return BadRequest();
            }
            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize("delete:catalog")]

        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            if(item == null)
            {
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();
            return Ok();

        }
    }
}