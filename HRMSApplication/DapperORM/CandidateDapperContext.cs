using Npgsql;
using System.Data;

namespace HRMSApplication.DapperORM
{
    public class CandidateDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public CandidateDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public object EOCandidateEntity { get; internal set; }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
