namespace QuickBuy.Dominio.Entidades
{
    public class Produto:Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Crítica - Nome do produto não foi informado");

            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Crítica - Descriçao do produto não foi informado");

            if (string.IsNullOrEmpty(Preco))
                AdicionarCritica("Crítica - Preço do produto não foi informado");
        }
    }
}
