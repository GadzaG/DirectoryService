namespace DirectoryService.Infrastructure.Postgres;

public class PostgresOptions
{
    public const string POSTGRES = "Postgres";

    public string Server { get; init; } = null!;

    public int Port { get; init; }

    public string Database { get; init; } = null!;

    public string Username { get; init; } = null!;

    public string Password { get; init; } = null!;

    public string GetConnectionString()
    {
        return $"Host={Server};Port={Port};Database={Database};Username={Username};Password={Password};";
    }
}