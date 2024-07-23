using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using listorize.Components.Util;
namespace listorize.Model;

public class Item : BaseModel {
    [Required]
    public string? Name { get; set; }
    [ForeignKey(nameof(Item.ParentItem))]
    public int? ParentItemId { get; set; }
    [ForeignKey(nameof(Item.Note))]
    public int? NoteId { get; set; }
    [ForeignKey(nameof(Item.ChildItem))]
    public int? ChildItemId { get; set; }
    public Item? ParentItem { get; set; }
    public Note? Note { get; set; }
    public Item? ChildItem { get; set; }
}