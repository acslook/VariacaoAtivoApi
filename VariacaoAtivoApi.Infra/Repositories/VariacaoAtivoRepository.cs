using Dapper;
using VariacaoAtivoApi.Data.Configuration;
using VariacaoAtivoApi.Data.SqlStatements;
using VariacaoAtivoApi.Domain.Interfaces.Repositories;
using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApi.Repository.Repositories
{
    public class VariacaoAtivoRepository : IVariacaoAtivoRepository
    {
        private readonly DbSession _dbSession;

        public VariacaoAtivoRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task InserirPosicoesAtivosAsync(List<PosicaoAtivo> posicoesAtivo)
        {
            var sqlStatement = VariacaoAtivoSqlStatements.InserirVariacaoAtivo(posicoesAtivo);
            await _dbSession.Connection.ExecuteAsync(sqlStatement.Item1, sqlStatement.Item2);
        }

        public async Task<List<PosicaoAtivo>> ObterPosicoesAtivoAsync(string codigoAtivo)
        {
            return (await _dbSession.Connection.QueryAsync<PosicaoAtivo>(VariacaoAtivoSqlStatements.ObterPosicoesAtivo, new { codigoAtivo })).ToList();
        }
    }
}
