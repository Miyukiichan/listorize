using System.ComponentModel.DataAnnotations.Schema;

public class LookupOption {
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey(nameof(LookupOption.Lookup))]
    public int LookupId { get; set; }
    public Lookup Lookup { get; set; }
}