using listorize.Components.Util;
namespace listorize.Model;
public class Note : BaseModel {
    public required string Name { get; set; }
    public required string Body { get; set; }

}