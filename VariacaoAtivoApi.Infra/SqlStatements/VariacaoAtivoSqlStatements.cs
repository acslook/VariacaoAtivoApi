using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApi.Data.SqlStatements
{
    public class VariacaoAtivoSqlStatements
    {
        public static (string, Dictionary<string, object>) InserirVariacaoAtivo(List<PosicaoAtivo> posicoesAtivo)
        {
            var script = $@"
            INSERT INTO posicao_ativo
            (codigo_ativo, data_posicao, valor_posicao)
            VALUES
            {string.Join(',', posicoesAtivo.Select((p, i) => $@"
                (
                :{nameof(PosicaoAtivo.CodigoAtivo)}_{i},
                :{nameof(PosicaoAtivo.DataPosicao)}_{i},
                :{nameof(PosicaoAtivo.ValorPosicao)}_{i}
                )"
            ))}
            ON CONFLICT (codigo_ativo, data_posicao) DO NOTHING;";


            Dictionary<string, object> dbArgs = new Dictionary<string, object>();

            for (int i = 0; i < posicoesAtivo.Count(); i++)
            {
                dbArgs.Add($"{nameof(PosicaoAtivo.CodigoAtivo)}_{i}", posicoesAtivo[i].CodigoAtivo);
                dbArgs.Add($"{nameof(PosicaoAtivo.DataPosicao)}_{i}", posicoesAtivo[i].DataPosicao);
                dbArgs.Add($"{nameof(PosicaoAtivo.ValorPosicao)}_{i}", posicoesAtivo[i].ValorPosicao);
            }         
            
            return (script, dbArgs);
        } 

        public static string ObterPosicoesAtivo => $@"
            SELECT 
                codigo_ativo {nameof(PosicaoAtivo.CodigoAtivo)}, 
                data_posicao {nameof(PosicaoAtivo.DataPosicao)}, 
                valor_posicao {nameof(PosicaoAtivo.ValorPosicao)}
            FROM posicao_ativo
            WHERE codigo_ativo = :codigoAtivo
            ORDER BY data_posicao";
    }
}
