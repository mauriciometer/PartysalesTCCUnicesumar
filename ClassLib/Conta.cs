using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartySalesTUCG.ClassLib
{
    internal class Pessoa
    {
        private int _idPessoa;
        private string _nome;
        private string _contato;
        private string _telefone;
        private IList<Venda> _vendas = new List<Venda>();
        private TUCGDataAcess daTucg = new();
        public Pessoa(int idPessoa)
        {
            this._idPessoa = idPessoa;
            this._nome = daTucg.Pessoa(idPessoa)[1].ToString();
            this._contato = daTucg.Pessoa(idPessoa)[2].ToString();
        }

        public Pessoa(string nome, string contato, string telefone)
        {
            this._nome = nome; 
            this._contato = contato;
            this._telefone = telefone;
            Registra();
        }
        public IList<Venda> Vendas { get { return _vendas; } }

        private void Registra()
        {
            this._idPessoa = daTucg.RegistraPessoa(new string[]{ this._nome, this._telefone, this._contato});
        }
        

    }
}
