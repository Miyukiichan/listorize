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
    public required string Name { get; set; }
    public ColumnType ColumnType { get; set; }
    [ForeignKey(nameof(ItemColumn.Item))]
    public int ItemId { get; set; }
    [ForeignKey(nameof(ItemColumn.Lookup))]
    public int? LookupId { get; set; }
    public required Item Item { get; set; }
    public Lookup? Lookup { get; set; }
}