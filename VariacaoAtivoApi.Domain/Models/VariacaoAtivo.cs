namespace VariacaoAtivoApi.Domain.Models
{
    public class VariacaoAtivo
    {
        public DateTime DataPosicao { get; set; }
        public decimal ValorPosicao { get; set; }
        public decimal? VariacaoD_Menos_1 { get; set; }
        public decimal? VariacaoPrimeriaData { get; set; }
    }
}
