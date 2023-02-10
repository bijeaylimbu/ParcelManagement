using System.Data;
using Microsoft.Data.SqlClient;

namespace com.project.parcel.Infrastructure;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString = _configuration.GetConnectionString("Parcel");
        
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}