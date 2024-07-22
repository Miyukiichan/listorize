using System.ComponentModel.DataAnnotations.Schema;
namespace listorize.Model;

public class ListItem {
    public int Id { get; set; }
    public int ParentListId { get; set; }
    [ForeignKey(nameof(ListItem.Note))]
    public int? NoteId { get; set; }
    [ForeignKey(nameof(ListItem.List))]
    public int ListId { get; set; }
    public Note? Note { get; set; }
    public required List List { get; set; }

}