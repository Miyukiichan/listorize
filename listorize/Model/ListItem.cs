using System.ComponentModel.DataAnnotations.Schema;
using listorize.Components.Util;
namespace listorize.Model;

public class ListItem : BaseModel {
    public int ParentListId { get; set; }
    [ForeignKey(nameof(ListItem.Note))]
    public int? NoteId { get; set; }
    [ForeignKey(nameof(ListItem.List))]
    public int? ListId { get; set; }
    public Note? Note { get; set; }
    public List? List { get; set; }
    public string? Name => List is not null ? List.Name : Note is not null ? Note.Name : "";
}