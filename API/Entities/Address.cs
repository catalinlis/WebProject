using System.Text.Json.Serialization;

namespace API.Entities;

public class Address{
    public int Id { get; set; }
    public required string  Country { get; set; }
    public required string  City { get; set; }
    public int StudentId { get; set; }
    [JsonIgnore]
    public Student? Student { get; set; }
}