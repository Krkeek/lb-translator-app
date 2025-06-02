namespace Common.Interface.Models;

/// <summary>
/// Represents credentials required to connect to a SQL Server database.
/// </summary>
/// <param name="server">The database server address or name.</param>
/// <param name="database">The name of the target database.</param>
/// <param name="user">The username used for authentication.</param>
/// <param name="password">The password used for authentication.</param>
public record DatabaseCredentials(string server, string database, string user, string password);