using System.ComponentModel.DataAnnotations.Schema;

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
public class ListColumn {
    
    public int Id { get; set; }
    public required string Name { get; set; }
    public ColumnType ColumnType { get; set; }
    [ForeignKey(nameof(ListColumn.List))]
    public int ListId { get; set; }
    [ForeignKey(nameof(ListColumn.Lookup))]
    public int? LookupId { get; set; }
    public required List List { get; set; }
    public Lookup? Lookup { get; set; }

}