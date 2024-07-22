using System.ComponentModel.DataAnnotations;

namespace listorize.Model;
public class List {
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}