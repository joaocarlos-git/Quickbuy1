using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido: Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        /// <summary>
        /// Pedido deve ter pelo memos um Item de pedido ou muitos itens de pedidos
        /// </summary>
        public ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedido.Any())
                AdicionarCritica("Crítica - Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("Crítica - Cep é de preenchimento obrigatório");

            if (FormaPagamentoId == 0)
                AdicionarCritica("Crítica - não foi informado a forma de pagamento");

            if (NumeroEndereco == 0)
                AdicionarCritica("Crítica - Numero não informado");

            if (string.IsNullOrEmpty(EnderecoCompleto))
                AdicionarCritica("Crítica - não foi informado o endereço");

            if (string.IsNullOrEmpty(Cidade))
                AdicionarCritica("Crítica - Nome da cidade não foi informado");

            if (string.IsNullOrEmpty(Estado))
                AdicionarCritica("Crítica - Estado não foi informado");

        }
    }
}
