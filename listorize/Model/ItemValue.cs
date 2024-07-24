using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
namespace listorize.Model;

[PrimaryKey(nameof(ItemValue.ItemId), nameof(ItemValue.ItemColumnId))]
public class ItemValue {
    [Required]
    [ForeignKey(nameof(ItemValue.Item))]
    public int? ItemId { get; set; }
    [Required]
    [ForeignKey(nameof(ItemValue.ItemColumn))]
    public int? ItemColumnId { get; set; }
    public required string Value { get; set; }
    [Required]
    [JsonIgnore] 
    public Item? Item { get; set; }
    [Required]
    [JsonIgnore] 
    public ItemColumn? ItemColumn { get; set; }
}