using CrudNet8.Data;
using CrudNet8.Models;
using CrudNet8.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CrudNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext dbContext;

        public ContactsController(ContactlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var AddDomainModel = new Contact()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Favourite = request.Favourite,
            };

            dbContext.Contacts.Add(AddDomainModel); 
            dbContext.SaveChanges();

            return Ok(AddDomainModel);
        }
    }
}
