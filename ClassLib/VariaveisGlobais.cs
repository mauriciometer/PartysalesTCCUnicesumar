using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PartySalesTUCG.ClassLib
{
    public class Globals
    {
        private static Globals _obj;
        public static Globals Current
        {
            get
            {
                if (_obj == null)
                    _obj = new Globals();
                return _obj;
            }
        }
        private Globals() { }

        private string _username;
        private string _festa;
        private int _idFesta;
        private string _chavePix = Properties.Settings.Default["ChavePix"].ToString();
        private string _bancoDados = Properties.Settings.Default["BancoDados"].ToString();
        private string _connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=";
        private bool _caixaAberto;

        public string UserName { get { return _username; } }

        public bool CaixaAberto { get { return _caixaAberto; } set { this._caixaAberto = value; } }

        public string Festa { get { return _festa; } }

        public int IdFesta { get { return _idFesta; } }
        public void SetUserName(string userName)
        {
            _username = userName;
        }

        public void SetFesta(string festa)
        { _festa = festa; }

        public void SetIdFesta(int idfesta)
        {
            _idFesta = idfesta;
        }

        public string ChavePix { get { return _chavePix; } }

        public string ConnectionString { get { return _connectionString+_bancoDados; } }
 
    }
   /* public class VariaveisGlobais
    {
        public string ChavePix
        {
            get
            {
                return Properties.Settings.Default["ChavePix"].ToString();
                //    return System.Configuration.ConfigurationManager.AppSettings["ChavePix"].ToString();
            }
        }
        public int IdFesta { get; set; }
        public string Vendedor { get; set; }

        public string NomeFesta { get; set; }

        public string ConnectionStringBd
        {
            get
            {
                return "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=PartySalesTUCCG_aa.accdb";
            }
        }
    }*/
}
