namespace ToDoApi2.Models;

public class PersonDTO
{
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int PersonId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string PostalZip { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
