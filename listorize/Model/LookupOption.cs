using System.ComponentModel.DataAnnotations.Schema;
using listorize.Components.Util;
namespace listorize.Model;

public class LookupOption : BaseModel {
    public required string Name { get; set; }
    [ForeignKey(nameof(LookupOption.Lookup))]
    public int LookupId { get; set; }
    public required Lookup Lookup { get; set; }
}