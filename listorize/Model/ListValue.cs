using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace listorize.Model;

[PrimaryKey(nameof(ListValue.ListItemId), nameof(ListValue.ListColumnId))]
public class ListValue {
    [ForeignKey(nameof(ListValue.ListItem))]
    public int ListItemId { get; set; }
    [ForeignKey(nameof(ListValue.ListColumn))]
    public int ListColumnId { get; set; }
    public required string Value { get; set; }
    public required ListItem ListItem { get; set; }
    public required ListColumn ListColumn { get; set; }
}