using System.Drawing;
using System.Globalization;
using VariacaoAtivoApi.Domain.Models;

namespace VariacaoAtivoApi.Domain.Dtos.Response
{
    public class VariacaoAtivoResponseDto
    {
        public string DataPosicao { get; set; }
        public string ValorPosicao { get; set; }
        public string? VariacaoD_Menos_1 { get; set; }
        public string? VariacaoPrimeriaData { get; set; }

        public static explicit operator VariacaoAtivoResponseDto(VariacaoAtivo variacao)
        {
            return new VariacaoAtivoResponseDto
            {
                DataPosicao = variacao.DataPosicao.ToString("dd/MM/yyyy"),
                ValorPosicao = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", variacao.ValorPosicao),
                VariacaoD_Menos_1 = variacao.VariacaoD_Menos_1?.ToString("P2") ?? "-",
                VariacaoPrimeriaData = variacao.VariacaoPrimeriaData?.ToString("P2") ?? "-"
            };
        }
    }
}
