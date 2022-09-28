using Npgsql;
using System.Data;

namespace HRMSApplication.DapperORM
{
    public class EmployeeDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public EmployeeDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public object EmployeeResource { get; internal set; }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
