namespace API.Entities;

public class ContactInfo{
    public int Id { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }
}