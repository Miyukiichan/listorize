using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace listorize.Model;

[PrimaryKey(nameof(ItemValue.ItemId), nameof(ItemValue.ItemColumnId))]
public class ItemValue {
    [ForeignKey(nameof(ItemValue.Item))]
    public int ItemId { get; set; }
    [ForeignKey(nameof(ItemValue.ItemColumn))]
    public int ItemColumnId { get; set; }
    public required string Value { get; set; }
    public required Item Item { get; set; }
    public required ItemColumn ItemColumn { get; set; }
}