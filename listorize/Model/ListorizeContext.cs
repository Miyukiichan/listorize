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
    public DbSet<ItemColumn> ItemColumns { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemValue> ItemValues { get; set; }
    public DbSet<Lookup> Lookups { get; set; }
    public DbSet<LookupOption> LookupOptions { get; set; }
    public DbSet<Note> Notes { get; set; }
}