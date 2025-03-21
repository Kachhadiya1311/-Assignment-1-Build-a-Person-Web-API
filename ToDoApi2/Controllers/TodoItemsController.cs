using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi2.Models;

namespace ToDoApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly TodoContext _context;

    public PersonController(TodoContext context)
    {
        _context = context;
    }

    // GET: api/Person
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPeople()
    {
        return await _context.People
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }

    // GET: api/Person/4
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDTO>> GetPerson(int id)
    {
        var person = await _context.People.FindAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        return ItemToDTO(person);
    }

    // PUT: api/Person/4
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPerson(int id, PersonDTO personDTO)
    {
        if (id != personDTO.PersonId)
        {
            return BadRequest();
        }

        var person = await _context.People.FindAsync(id);
        if (person == null)
        {
            return NotFound();
        }

        person.Name = personDTO.Name;
        person.Phone = personDTO.Phone;
        person.Email = personDTO.Email;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!PersonExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    // POST: api/Person
    [HttpPost]
    public async Task<ActionResult<PersonDTO>> PostPerson(PersonDTO personDTO)
    {
        var person = new Person
        {
            Name = personDTO.Name,
            Phone = personDTO.Phone,
            Email = personDTO.Email
        };

        _context.People.Add(person);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPerson), new { id = person.PersonId }, ItemToDTO(person));
    }

    // DELETE: api/Person/4
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var person = await _context.People.FindAsync(id);
        if (person == null)
        {
            return NotFound();
        }

        _context.People.Remove(person);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PersonExists(int id)
    {
        return _context.People.Any(e => e.PersonId == id);
    }

    private static PersonDTO ItemToDTO(Person person) =>
       new PersonDTO
       {
           PersonId = person.PersonId,
           Name = person.Name,
           Phone = person.Phone,
           Email = person.Email
       };
}
