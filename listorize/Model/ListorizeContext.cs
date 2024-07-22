using Microsoft.EntityFrameworkCore;
namespace listorize.Model;

public class ListorizeContext : DbContext {
    IConfiguration _config;
    public ListorizeContext(IConfiguration config) {
        _config = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = _config.GetConnectionString("Default");
        if (string.IsNullOrWhiteSpace(connectionString)) {
            // ~/.local/share
            connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "listorize");
            if (!Directory.Exists(connectionString)) {
                Directory.CreateDirectory(connectionString);
            }
            connectionString = Path.Combine(connectionString, "listorize.db");
            connectionString = $"Data Source={connectionString}";
        }
        options.UseSqlite(connectionString);
    }
    public DbSet<List> List { get; set; }
    public DbSet<ListColumn> ListColumn { get; set; }
    public DbSet<ListItem> ListItem { get; set; }
    public DbSet<ListValue> ListValue { get; set; }
    public DbSet<Lookup> Lookup { get; set; }
    public DbSet<LookupOption> LookupOption { get; set; }
    public DbSet<Note> Note { get; set; }
}