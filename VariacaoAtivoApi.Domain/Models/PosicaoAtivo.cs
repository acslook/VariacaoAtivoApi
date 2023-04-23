namespace VariacaoAtivoApi.Domain.Models
{
    public class PosicaoAtivo
    {
        public string CodigoAtivo { get; set; }
        public DateTime DataPosicao { get; set; }
        public decimal ValorPosicao { get; set; }

        public VariacaoAtivo CalcularVariacao(PosicaoAtivo? posicaoDiaAnterior, PosicaoAtivo? posicaoInicial)
        {

            return new VariacaoAtivo
            {
                DataPosicao = DataPosicao,
                ValorPosicao = ValorPosicao,
                VariacaoD_Menos_1 = CalcularVariacaoData(posicaoDiaAnterior),
                VariacaoPrimeriaData = CalcularVariacaoData(posicaoInicial)
            };

            decimal? CalcularVariacaoData(PosicaoAtivo? posicaoDiaAnterior) =>
            posicaoDiaAnterior is null
            ? null
            : (ValorPosicao - posicaoDiaAnterior.ValorPosicao) / posicaoDiaAnterior.ValorPosicao;
        }
    }
}
