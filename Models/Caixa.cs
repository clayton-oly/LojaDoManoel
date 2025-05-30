namespace LojaDoManoel.Models
{
    public class Caixa
    {
        public string CaixaId { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public Caixa(string id, int altura, int largura, int comprimento)
        {
            CaixaId = id;
            Altura = altura;
            Largura = largura;
            Comprimento = comprimento;
        }

    }
}
