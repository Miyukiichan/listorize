using System.ComponentModel.DataAnnotations;
using listorize.Components.Util;
namespace listorize.Model;
public class List : BaseModel {
    [Required]
    public string? Name { get; set; }
}