using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using pix_payload_generator.net.Models.CobrancaModels;

namespace PartySalesTUCG.ClassLib
{
    internal class Venda
    {
        private int _idFesta;
        private string _vendedor;
        private IList<ItensVenda> _itens;
        private string _identVenda;
        private IList<Pagamento> _pagamentos;
        private int _idVenda;
        private TUCGDataAcess daTucg = new();

        #region Construtores
        public Venda()
        {
            _idFesta = 0;
            _itens = new List<ItensVenda>();
            _identVenda = string.Empty;
            _pagamentos = new List<Pagamento>();
            _vendedor = string.Empty;
        }

        public Venda(int id, string vendedor)
        {
            _idFesta = id;
            _vendedor = vendedor;
            _identVenda = string.Empty;
            _itens = new List<ItensVenda>();
            _pagamentos = new List<Pagamento>();
        }

        #endregion Construtores

        #region Propriedades
        public IList<ItensVenda> Itens
        {
            get { return _itens; }
        }

        public IList<Pagamento> Pagamentos
        {
            get { return _pagamentos; }
            set { _pagamentos = value; }
        }

        public string ValorTotal
        {
            get
            {
                double total = 0;
                foreach (ItensVenda venda in _itens)
                {
                    total += venda.ValorTotal;
                }
                return total.ToString("C");
            }
        }

        public double ValorTotalNum
        {
            get
            {
                double total = 0;
                foreach (ItensVenda venda in _itens)
                {
                    total += venda.ValorTotal;
                }
                return total;
            }
        }

        public string ValorTotalPago
        {
            get
            {
                double total = 0;
                foreach (Pagamento pagto in _pagamentos)
                {
                    total += pagto.Valor;
                }

                return total.ToString("C");
            }
        }
        public string IdentVenda
        {
            get { return _identVenda; }
            set { _identVenda = value; }
        }

        public int IdVenda { get { return _idVenda; } set { _idVenda = value; } }

        #endregion Propriedades

        #region Metodos
        public bool RegistraVenda()
        {
            try
            {
                daTucg.RegistraVenda(this);
                return true;    
            }
            catch (Exception ex) { MessageBox.Show("Falha geral na gravação"); return false; }
        }
        #endregion Metodos

    }

    internal class ItensVenda
    {
        private int _itemVenda;
        private int _qtdeVendido = 0;
        private double _vlrUnit = 0;



        public ItensVenda(int idItem, int qtde, double vlrUnit)
        {
            _itemVenda = idItem;
            _qtdeVendido = qtde;
            _vlrUnit = vlrUnit;
        }

        public double ValorTotal
        {
            get { return (_qtdeVendido * _vlrUnit); }
        }

        public int ItemVenda { get { return this._itemVenda; } set { this._itemVenda = value; } }

        public int QtdeVendido { get { return this._qtdeVendido; } set { this._qtdeVendido = value; } }

        public double VlrUnit { get { return this._vlrUnit; } set { this._vlrUnit = value; } }

    }

    internal class Pagamento
    {
        private string _tipo; // new List<string> { "PIX", "DINHEIRO" , "CONTA"};
        private double _valor;
        private string _identPix;
        private Conta _conta;
        public Pagamento(string tipo, double valor)
        {
            _valor = valor;
            _tipo = tipo;
        }

        public Pagamento(string tipo, double valor, string identPix)
        {
            _valor = valor;
            _tipo = tipo;
            _identPix = identPix;
        }
        public Pagamento(double valor, Conta conta)
        {
            _valor = valor;
            _conta = conta;
            _tipo = "Conta de " + conta.Nome;
        }


        public double Valor { get { return _valor; } }
        public string DescPagto { get { return this._tipo + " :" + this._valor.ToString("C"); } }

        public string Tipo { get { return this._tipo; } }
        public string IdentPix { get { return this._identPix; } }

        public Conta ContaPG { get { return this._conta; } }


    }

    internal class Conta
    {
        private int _idConta;
        private int _idVenda;
        private double _valor;
        private string _nome;

        public Conta(int idConta, string nome, double valor)
        {
            _idConta = idConta;
            _nome = nome;
            _valor = valor;
        }

        public int IdVenda { get { return _idVenda; } set { this._idVenda = value; } }

        public string Nome { get { return _nome; } }

        public int IdConta { get { return _idConta; } }

        public double Valor { get { return _valor; } }

        public int IdRegistroConta()
        {
            int _idRegistroConta = 0;

            return _idRegistroConta;
        }
    }
}
