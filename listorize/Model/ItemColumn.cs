using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using listorize.Components.Util;
namespace listorize.Model;

public enum ColumnType {
    Text,
    Number,
    Select,
    MultiSelect,
    Date,
    DateTime,
    CreatedDateTime,
    LastEditedDateTime,
    Checkbox,
}
public class ItemColumn : BaseModel {
    [Required]
    public string? Name { get; set; }
    [Required]
    public ColumnType? ColumnType { get; set; } = Model.ColumnType.Text;
    [ForeignKey(nameof(ItemColumn.Item))]
    public int? ItemId { get; set; }
    [ForeignKey(nameof(ItemColumn.Lookup))]
    public int? LookupId { get; set; }
    public Item? Item { get; set; }
    public Lookup? Lookup { get; set; }
    public List<ItemValue> ItemValues { get; set; }
}