namespace ToDoApi2.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonId { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }

        public string? Address { get; set; }
        public string? PostalZip { get; set; }
       
    }
}
