using Npgsql;
using System.Data;

namespace HRMSApplication.DapperORM
{
    public class InductionDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public InductionDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public object InductionEntity { get; internal set; }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
