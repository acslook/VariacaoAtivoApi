using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace VariacaoAtivoApi.Data.Configuration
{
    public class DbSession
    {
        private readonly IConfiguration _configuration;

        public DbSession(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection =>
            new NpgsqlConnection(_configuration.GetConnectionString("DbAtivosFinanceiros"));
    }
}
