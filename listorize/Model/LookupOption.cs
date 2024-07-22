using System.ComponentModel.DataAnnotations.Schema;
namespace listorize.Model;

public class LookupOption {
    public int Id { get; set; }
    public required string Name { get; set; }
    [ForeignKey(nameof(LookupOption.Lookup))]
    public int LookupId { get; set; }
    public required Lookup Lookup { get; set; }
}