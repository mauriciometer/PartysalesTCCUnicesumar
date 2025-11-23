using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PartySalesTUCG.dsTUCGTableAdapters;


namespace PartySalesTUCG.ClassLib
{
    internal class TUCGDataAcess
    {
        private readonly dsTUCG DsParty = new();

        private OleDbConnection connection = new OleDbConnection(Globals.Current.ConnectionString);
        private OleDbCommand dbCommand = new OleDbCommand();

        public TUCGDataAcess()
        {
            dbCommand.Connection = connection;
        }

        #region FESTA

        public int RegistraFesta(string nome, DateTime dataFesta)
        {
            int retorno = 0;
            dbCommand.CommandText = "INSERT INTO FESTA (Nome, DataFesta) VALUES (?, ?)";
            dbCommand.Parameters.Clear();
            dbCommand.Parameters.Add(new OleDbParameter("Nome", nome));
            dbCommand.Parameters.Add(new OleDbParameter("DataFesta", dataFesta.Date));

            try
            {
                if (dbCommand.Connection.State == ConnectionState.Closed)
                {
                    dbCommand.Connection.Open();
                }
                dbCommand.ExecuteNonQuery();

                // Pega o ID da festa recém-criada
                dbCommand.CommandText = "SELECT @@IDENTITY";
                retorno = (int)dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar festa: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dbCommand.Connection.State == ConnectionState.Open)
                {
                    dbCommand.Connection.Close();
                }
            }
            return retorno;
        }

        public DataTable GetFestas()
        {
            DataTable dtFestas = new DataTable();
            string sql = "SELECT ID, Nome, DataFesta FROM FESTA ORDER BY DataFesta DESC";

            using (OleDbConnection conn = new OleDbConnection(Globals.Current.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dtFestas);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar festas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dtFestas;
        }

        #endregion

        #region ITENS
        public IList<string[]> ItensVenda
        {
            get
            {
                IList<string[]> itens = new List<string[]>();
                //  DataSet1 recipiesNewDataSet = new DataSet1();

                ITENSTableAdapter itensDisponiveis = new ITENSTableAdapter();

                DataTable ItensVendaDataTable = itensDisponiveis.GetDataByIdFesta(Globals.Current.IdFesta);

                DataTableReader reader = new DataTableReader(ItensVendaDataTable);

                IList<string> linha = new List<string>();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        linha.Add(reader[i].ToString());
                    }

                    itens.Add(linha.ToArray());
                    linha.Clear();
                }

                return itens;
            }
        }

        public IList<string[]> ItensVendaCad(int idFesta)
        {
            IList<string[]> itens = new List<string[]>();
            //  DataSet1 recipiesNewDataSet = new DataSet1();

            ITENSTableAdapter itensDisponiveis = new ITENSTableAdapter();

            DataTable ItensVendaDataTable = itensDisponiveis.GetDataByFestaCad(idFesta);

            DataTableReader reader = new DataTableReader(ItensVendaDataTable);

            IList<string> linha = new List<string>();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    linha.Add(reader[i].ToString());
                }

                itens.Add(linha.ToArray());
                linha.Clear();
            }

            return itens;

        }

        public int RegistraItem(int idFesta, string descricao, double valorvenda, string tipo, bool ativo)
        {
            int retorno = 0;
            dbCommand.CommandText = "INSERT INTO ITENS(ID_FESTA,Descricao,ValorVenda,Tipo, Ativo) VALUES (?,?,?,?,?)";
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID_FESTA", idFesta));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Descricao", descricao));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ValorVenda", valorvenda));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Tipo", tipo));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Ativo", ativo));
            try
            {
                if (dbCommand.Connection.State == ConnectionState.Closed)
                {
                    dbCommand.Connection.Open();
                }
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dbCommand.CommandText = "SELECT @@IDENTITY";

            try
            {
                retorno = (int)dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dbCommand.Connection.Close();
            return retorno;
        }

        public void AtualizaItem(int iditem, string descricao, double valorvenda, string tipo, bool ativo)
        {
            int retorno = 0;
            dbCommand.CommandText = "UPDATE ITENS SET Descricao = ?, ValorVenda = ? , Tipo = ?, Ativo = ? where ID = ?";

            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Descricao", descricao));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ValorVenda", valorvenda));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Tipo", tipo));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Ativo", ativo));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", iditem));
            try
            {
                if (dbCommand.Connection.State == ConnectionState.Closed)
                {
                    dbCommand.Connection.Open();
                }
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                retorno = dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dbCommand.Connection.Close();

        }

        #endregion ITENS

        #region PESSOA
        public IList<string[]> Pessoas
        {
            get
            {
                IList<string[]> itens = new List<string[]>();
                //  DataSet1 recipiesNewDataSet = new DataSet1();

                // dsTUCGTableAdapters.ITENSTableAdapter itensDisponiveis = new dsTUCGTableAdapters.ITENSTableAdapter();
                PESSOASTableAdapter pessoas = new PESSOASTableAdapter();
                DataTable PessoasDataTable = pessoas.GetData();

                DataTableReader reader = new DataTableReader(PessoasDataTable);

                IList<string> linha = new List<string>();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        linha.Add(reader[i].ToString());
                    }

                    itens.Add(linha.ToArray());
                    linha.Clear();
                }

                return itens;
            }
        }

        public IList<string> Pessoa(int pessoa_ID)
        {
            IList<string[]> itens = new List<string[]>();
            //  DataSet1 recipiesNewDataSet = new DataSet1();

            // dsTUCGTableAdapters.ITENSTableAdapter itensDisponiveis = new dsTUCGTableAdapters.ITENSTableAdapter();
            PESSOASTableAdapter pessoas = new PESSOASTableAdapter();
            DataTable PessoasDataTable = pessoas.GetDataByID(pessoa_ID);

            DataTableReader reader = new DataTableReader(PessoasDataTable);

            IList<string> linha = new List<string>();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    linha.Add(reader[i].ToString());
                }
            }

            return linha;

        }

        public int RegistraPessoa(string[] dados)
        {
            int retorno = 0;

            //System.Data.OleDb.OleDbConnection _connection = new();
            //
            ////_connection.ConnectionString = Globals.Current.ConnectionString;
            //
            ////System.Data.OleDb.OleDbCommand _command = new();
            //dbCommand.Connection = _connection;
            dbCommand.CommandText = "INSERT INTO PESSOAS(Nome,Telefone,ContatoTerreiro) VALUES (?,?,?)";
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nome", dados[0]));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Telefone", dados[1]));
            dbCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Contato", dados[2]));
            try
            {
                dbCommand.Connection.Open();
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dbCommand.CommandText = "SELECT @@IDENTITY";

            try
            {
                retorno = (int)dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dbCommand.Connection.Close();

            /*dsTUCGTableAdapters.PESSOASTableAdapter pessoas = new dsTUCGTableAdapters.PESSOASTableAdapter();
            var retins = pessoas.Insert(
                dados[0], //Nome
                dados[1], //Telefone
                dados[2] //contato
                ); ;

            retorno = (int)pessoas.GetIdInserted();*/

            return retorno;
        }
        #endregion PESSOA

        #region VENDA
        public void RegistraVenda(Venda venda)
        {
            dbCommand.CommandText = "INSERT INTO VENDA(ID_FESTA,DataHora,Vendedor,Valor) VALUES (?,(now()),?,?)";
            dbCommand.Parameters.Add(new OleDbParameter("ID_FESTA", Globals.Current.IdFesta));
            dbCommand.Parameters.Add(new OleDbParameter("Vendedor", Globals.Current.UserName));
            dbCommand.Parameters.Add(new OleDbParameter("Valor", venda.ValorTotalNum));

            try
            {
                if (dbCommand.Connection.State == ConnectionState.Closed)
                {
                    dbCommand.Connection.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro de conexão: " + e.Message);
            }

            if (dbCommand.Connection.State == ConnectionState.Open)
            {
                try
                {
                    //grava a venda
                    dbCommand.ExecuteNonQuery();
                    //busca id da venda gravada
                    dbCommand.CommandText = "SELECT @@IDENTITY";
                    venda.IdVenda = (int)dbCommand.ExecuteScalar();

                    //passa gravacao de itens
                    RegistraItensDaVenda(venda);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro gravar venda: " + e.Message);

                }

            }

            if (dbCommand.Connection.State == ConnectionState.Open)
            {
                dbCommand.Connection.Close();
            }
        }

        public void RegistraItensDaVenda(Venda venda)
        {
            dbCommand.CommandText = "INSERT INTO ITENS_VENDA(ID_VENDA,ID_ITEM,QTDE,VLRUNIT,VLRTOTAL) VALUES (?,?,?,?,?)";

            foreach (ItensVenda item in venda.Itens)
            {
                dbCommand.Parameters.Clear();

                dbCommand.Parameters.Add(new OleDbParameter("ID_VENDA", venda.IdVenda));
                dbCommand.Parameters.Add(new OleDbParameter("ID_ITEM", item.ItemVenda));
                dbCommand.Parameters.Add(new OleDbParameter("QTDE", item.QtdeVendido));
                dbCommand.Parameters.Add(new OleDbParameter("VLRUNIT", item.VlrUnit));
                dbCommand.Parameters.Add(new OleDbParameter("VLRTOTAL", item.ValorTotal));


                if (dbCommand.Connection.State != ConnectionState.Open)
                {
                    try
                    {
                        if (dbCommand.Connection.State == ConnectionState.Closed)
                        {
                            dbCommand.Connection.Open();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro de conexão: " + e.Message);
                    }
                }

                if (dbCommand.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        //grava a item venda
                        dbCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro gravar item da venda: " + e.Message);
                    }

                }
            }

            RegistraPagamentosVenda(venda);
        }

        public void RegistraPagamentosVenda(Venda venda)
        {
            string _ComandoExec = "INSERT INTO PAGAMENTO(ID_VENDA,TipoPagto,VlrLiquido,IdentPix,IdConta)" +
                "VALUES (?,?,?,?,?)";

            dbCommand.CommandText = _ComandoExec;
            foreach (Pagamento pgto in venda.Pagamentos)
            {
                dbCommand.Parameters.Clear();

                dbCommand.Parameters.Add(new OleDbParameter("ID_VENDA", venda.IdVenda));
                dbCommand.Parameters.Add(new OleDbParameter("TipoPagamento", pgto.Tipo));
                dbCommand.Parameters.Add(new OleDbParameter("VlrLiquido", pgto.Valor));
                dbCommand.Parameters.Add(new OleDbParameter("IdentPix", (pgto.IdentPix == null ? String.Empty : pgto.IdentPix)));
                dbCommand.Parameters.Add(new OleDbParameter("IdPessoa", (pgto.ContaPG == null ? 0 : pgto.ContaPG.IdConta)));


                if (dbCommand.Connection.State != ConnectionState.Open)
                {
                    try
                    {
                        if (dbCommand.Connection.State == ConnectionState.Closed)
                        {
                            dbCommand.Connection.Open();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro de conexão: " + e.Message);
                    }
                }

                if (dbCommand.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        dbCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro gravar pagamento da venda: " + e.Message);
                    }

                }

                if (pgto.ContaPG != null)
                {
                    pgto.ContaPG.IdVenda = venda.IdVenda;

                    RegistraVendaNaConta(pgto.ContaPG);

                    dbCommand.CommandText = _ComandoExec;

                }

                if (pgto.Tipo.Equals("DINHEIRO"))
                {
                    RegistraMovCaixa(Globals.Current.IdFesta, "Venda na Festa", pgto.Valor, "V", Globals.Current.UserName);

                    dbCommand.CommandText = _ComandoExec;
                }
            }
        }

        public void RegistraVendaNaConta(Conta conta)
        {
            dbCommand.CommandText = "INSERT INTO CONTA(" +
                "ID_FESTA,ID_PESSOA,ID_VENDA,DESCRICAO,VLRDEBITO,DTHORA) " +
                "VALUES (?,?,?,?,?,(now()))";

            dbCommand.Parameters.Clear();

            dbCommand.Parameters.Add(new OleDbParameter("ID_FESTA", Globals.Current.IdFesta));
            dbCommand.Parameters.Add(new OleDbParameter("ID_PESSOA", conta.IdConta));
            dbCommand.Parameters.Add(new OleDbParameter("ID_VENDA", conta.IdVenda));
            dbCommand.Parameters.Add(new OleDbParameter("DESCRICAO", "Compra na Festa"));
            dbCommand.Parameters.Add(new OleDbParameter("VLRDEBITO", conta.Valor));

            if (dbCommand.Connection.State != ConnectionState.Open)
            {
                try
                {
                    if (dbCommand.Connection.State == ConnectionState.Closed)
                    {
                        dbCommand.Connection.Open();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro de conexão: " + e.Message);
                }
            }

            if (dbCommand.Connection.State == ConnectionState.Open)
            {
                try
                {
                    dbCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro gravar conta da venda: " + e.Message);
                }

            }
        }

        #endregion VENDA

        #region CONTA

        public IList<string[]> ExtratoConta(int idFesta, int idPessoa)
        {


            IList<string[]> extrato = new List<string[]>();
            //  DataSet1 recipiesNewDataSet = new DataSet1();

            CONTATableAdapter cONTATableAdapter = new CONTATableAdapter();

            DataTable tbExtrato = cONTATableAdapter.GetDataByFestaPessoa(idFesta, idPessoa);

            DataTableReader reader = new DataTableReader(tbExtrato);

            IList<string> linha = new List<string>();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    linha.Add(reader[i].ToString());
                }

                extrato.Add(linha.ToArray());
                linha.Clear();
            }

            return extrato;

        }

        public void RegistraCredito(int idPessoa, string descricao, double credito, string tipo)
        {

            dbCommand.CommandText = "INSERT INTO CONTA(" +
                 "ID_FESTA,ID_PESSOA,DESCRICAO,VLRCREDITO,DTHORA) " +
                 "VALUES (?,?,?,?,(now()))";
            dbCommand.Parameters.Clear();
            dbCommand.Parameters.Add(new OleDbParameter("ID_FESTA", Globals.Current.IdFesta));
            dbCommand.Parameters.Add(new OleDbParameter("ID_PESSOA", idPessoa));
            dbCommand.Parameters.Add(new OleDbParameter("DESCRICAO", descricao));
            dbCommand.Parameters.Add(new OleDbParameter("VLRCREDITO", credito));

            try
            {
                if (dbCommand.Connection.State == ConnectionState.Closed)
                {
                    dbCommand.Connection.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro de conexão: " + e.Message);
            }

            if (dbCommand.Connection.State == ConnectionState.Open)
            {
                try
                {
                    dbCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro gravar credito: " + e.Message);

                }

            }

            if (dbCommand.Connection.State == ConnectionState.Open)
            {
                dbCommand.Connection.Close();
            }

            if (tipo.Equals("D"))
            {
                RegistraMovCaixa(Globals.Current.IdFesta, "Credito em conta", credito, "C", Globals.Current.UserName);

            }
        }

        public double SaldoConta(int idFesta, int idPessoa)
        {
            double credito = 0;
            double debito = 0;

            foreach (string[] item in this.ExtratoConta(idFesta, idPessoa))
            {

                credito += (!(item[4] == string.Empty) ? double.Parse(item[4]) : 0);
                debito += (!(item[5] == string.Empty) ? double.Parse(item[5]) : 0);
            }

            return (credito - debito);
        }

        #endregion CONTA

        #region CAIXA
        public void RegistraMovCaixa(int idFesta, string descricao, double valor, string tipomov, string usuario)
        {
            /* movimentos:
             * A - ABERTURA (ENTRADA)
             * E - ENTRADA (ENTRADA)
             * V - VENDA (ENTRADA)
             * C - CREDITO CONTA (ENTRADA)
             * R - RETIRADA (SAIDA)
             * F - FECHAMENTO (SAIDA)
             */
            string tpentra = " A E V C ";
            string tpsaida = " R ";
            string tpFecha = " F ";


            dbCommand.Parameters.Clear();
            dbCommand.Parameters.Add(new OleDbParameter("ID_FESTA", idFesta));
            dbCommand.Parameters.Add(new OleDbParameter("DESRICAO", descricao));
            dbCommand.Parameters.Add(new OleDbParameter("VALOR", valor));
            dbCommand.Parameters.Add(new OleDbParameter("TIPOMOV", tipomov));
            dbCommand.Parameters.Add(new OleDbParameter("USUARIO", usuario));

            if (tpentra.Contains(tipomov))
            {
                dbCommand.CommandText = "INSERT INTO CAIXA(" +

                    "ID_FESTA,DESCRICAO,ENTRADA,DTMOV,TIPOMOV,USUARIO) " +
                    "VALUES(?,?,?,(now()),?,?)";
            }
            else if (tpsaida.Contains(tipomov) || tpFecha.Contains(tipomov))
            {
                dbCommand.CommandText = "INSERT INTO CAIXA(" +
                "ID_FESTA,DESCRICAO,SAIDA,DTMOV,TIPOMOV,USUARIO) " +
                "VALUES(?,?,?,(now()),?,?)";
            }
            else { return; }


            try
            {
                if (dbCommand.Connection.State == ConnectionState.Closed)
                {
                    dbCommand.Connection.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro de conexão: " + e.Message);
            }

            if (dbCommand.Connection.State == ConnectionState.Open)
            {
                try
                {
                    dbCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro gravar movimento caixa: " + e.Message);

                }

            }

            if (tpFecha.Contains(tipomov))
            {
                try
                {
                    if (dbCommand.Connection.State == ConnectionState.Closed)
                    {
                        dbCommand.Connection.Open();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro de conexão: " + e.Message);
                }

                if (dbCommand.Connection.State == ConnectionState.Open)
                {
                    try
                    {
                        dbCommand.Parameters.Clear();

                        dbCommand.Parameters.Add(new OleDbParameter("ID_FESTA", idFesta));
                        dbCommand.CommandText = "UPDATE CAIXA SET TIPOMOV = 'X' WHERE ID_FESTA = ? AND TIPOMOV = 'A'";
                     
                        dbCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro gravar movimento caixa: " + e.Message);

                    }

                }
            }

            if (dbCommand.Connection.State == ConnectionState.Open)
            {
                dbCommand.Connection.Close();
            }
        }

        public double VerificaCaixa(int idFesta)
        {
            CAIXATableAdapter taCaixa = new CAIXATableAdapter();

            if ((taCaixa.AberturaCaixa(idFesta)) == null)
            {
                return 0;
            }
            else { return Convert.ToDouble(taCaixa.AberturaCaixa(idFesta)); }



        }

        public IList<string[]> MovimentoCaixa(int idFesta)
        {


            IList<string[]> caixa = new List<string[]>();
            //  DataSet1 recipiesNewDataSet = new DataSet1();

            CAIXATableAdapter taCaixa = new CAIXATableAdapter();

            DataTable tbCaixa = taCaixa.GetDataByIdFesta(idFesta);

            DataTableReader reader = new DataTableReader(tbCaixa);

            IList<string> linha = new List<string>();
            int[] _cols = new int[4] { 2, 3, 4, 7 };

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (_cols.Contains(i))
                    {
                        if (i == 3 || i == 4)
                        {
                            linha.Add(Convert.ToDouble(reader[i]).ToString("C"));
                        }
                        else
                        {
                            linha.Add(reader[i].ToString());
                        }
                    }

                }
                caixa.Add(linha.ToArray());
                linha.Clear();
            }

            return caixa;

        }
        #endregion CAIXA

        #region RELATORIO
        public DataTable GetExtratoConta(int idFesta, int idPessoa)
        {
            DataTable dtRelatorio = new DataTable();

            string sql = "SELECT * FROM relatorio_venda " +
                         "WHERE ID_FESTA = ? AND ID_PESSOA = ? ORDER BY DTHORA";

            using (OleDbConnection conn = new OleDbConnection(Globals.Current.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.Add(new OleDbParameter("ID_FESTA", idFesta));
                cmd.Parameters.Add(new OleDbParameter("ID_PESSOA", idPessoa));

                try
                {
                    conn.Open();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dtRelatorio);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar relatório de extrato: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } return dtRelatorio;
        }

        public DataTable GetExtratoContaGeral(int idFesta)
        {
            DataTable dtRelatorio = new DataTable();

            string sql = "SELECT * FROM relatorio_venda " +
                         "WHERE ID_FESTA = ? ORDER BY PESSOA,DTHORA";

            using (OleDbConnection conn = new OleDbConnection(Globals.Current.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.Add(new OleDbParameter("ID_FESTA", idFesta));

                try
                {
                    conn.Open();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dtRelatorio);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar relatório de extrato: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dtRelatorio;
        }

        public DataTable GetRelatorioVendasGeral(int idFesta)
        {
            DataTable dtRelatorio = new DataTable();

            string sql = "SELECT Descricao, IIF(ISNULL(sum(QTDE)), 0, sum(QTDE)) AS QTDE_TOTAL, IIF(ISNULL(SUM(VLRTOTAL)), 0, SUM(VLRTOTAL)) AS VALOR_TOTAL " +
                         "FROM VENDAS_FESTA " +
                         "WHERE ID_FESTA = ? " +
                         "GROUP BY Descricao " +
                         "ORDER BY Descricao";

            using (OleDbConnection conn = new OleDbConnection(Globals.Current.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.Add(new OleDbParameter("ID_FESTA", idFesta));

                try
                {
                    conn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dtRelatorio);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar relatório de vendas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dtRelatorio;
        }

        public DataTable GetRelatorioCaixa(int idFesta)
        {
            DataTable dtRelatorio = new DataTable();

            string sql = "SELECT DTMOV, DESCRICAO, ENTRADA, SAIDA, TIPOMOV, USUARIO " +
                         "FROM CAIXA " +
                         "WHERE ID_FESTA = ? " +
                         "ORDER BY DTMOV";

            using (OleDbConnection conn = new OleDbConnection(Globals.Current.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.Add(new OleDbParameter("ID_FESTA", idFesta));
                try
                {
                    conn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dtRelatorio);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar relatório de caixa: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dtRelatorio;
        }
        #endregion
    }

}
