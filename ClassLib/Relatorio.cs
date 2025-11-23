using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PartySalesTUCG.ClassLib
{
    internal class Relatorio
    {
        
        public void ExportarDataTableParaPDF(DataTable dt, string caminhoArquivo, string tituloRelatorio, string subtitulo)
        {
            // --- CÁLCULO DE TOTAIS ---
            double totalCredito = 0;
            double totalDebito = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalCredito += row.IsNull("CREDITO") ? 0 : Convert.ToDouble(row["CREDITO"]);
                totalDebito += row.IsNull("DEBITO") ? 0 : Convert.ToDouble(row["DEBITO"]);
            }
            double saldo = totalCredito - totalDebito;
            // --- FIM DO CÁLCULO ---

            // 1. Configura o documento PDF
            Document doc = new Document(PageSize.A4.Rotate()); // Paisagem

            try
            {
                // 2. Cria o arquivo PDF no disco
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));
                doc.Open();

                // 3. Adiciona um Título
                iTextSharp.text.Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Paragraph titulo = new Paragraph(tituloRelatorio + "\n", fonteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                // 4. Adiciona o Subtítulo
                iTextSharp.text.Font fonteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Paragraph sub = new Paragraph(subtitulo + "\n\n", fonteSubtitulo);
                sub.Alignment = Element.ALIGN_CENTER;
                doc.Add(sub);

                // 5. Prepara a Tabela (Remove colunas desnecessárias)
                DataTable dtView = dt.Copy();
                dtView.Columns.Remove("ID_FESTA");
                dtView.Columns.Remove("ID_PESSOA");
                dtView.Columns.Remove("FESTA");
                dtView.Columns.Remove("PESSOA");
                dtView.Columns.Remove("VENDA");

                PdfPTable tabela = new PdfPTable(dtView.Columns.Count);
                tabela.WidthPercentage = 100;

                // A ordem das colunas no dtView agora é:
                // [0]DataHora, [1]VENDEDOR, [2]DESCRICAO, [3]QTDE, [4]VLRUNIT, [5]DEBITO, [6]CREDITO
            
                float[] widths = new float[] { 2f, 2f, 4f, 1f, 1.5f, 1.5f, 1.5f };
                tabela.SetWidths(widths);
                

                // 6. Adiciona os Cabeçalhos
                iTextSharp.text.Font fonteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                foreach (DataColumn column in dtView.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, fonteHeader));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(cell);
                }

                // 7. Adiciona as Linhas de Dados
                iTextSharp.text.Font fonteCelulas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (DataRow row in dtView.Rows)
                {
                    foreach (DataColumn column in dtView.Columns)
                    {
                        string valorCelula = "";
                        PdfPCell cell = new PdfPCell();
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;

                        if (column.ColumnName == "DEBITO" || column.ColumnName == "CREDITO" || column.ColumnName == "VLRUNIT" || column.ColumnName == "VLRTOTAL")
                        {
                            double valor = row.IsNull(column) ? 0.0 : Convert.ToDouble(row[column]);
                            valorCelula = valor.ToString("C");
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }
                        else if (column.ColumnName == "QTDE")
                        {
                            valorCelula = row.IsNull(column) ? "0" : row[column].ToString();
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }
                        else
                        {
                            valorCelula = row[column].ToString();
                        }

                        cell.Phrase = new Phrase(valorCelula, fonteCelulas);
                        tabela.AddCell(cell);
                    }
                }

                // 8. Adiciona a Linha de Totais (Dinâmica)
                iTextSharp.text.Font fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                int colunasMescladas = dtView.Columns.Count - 2; // (Total de colunas - Débito - Crédito)

                PdfPCell cellLabelTotal = new PdfPCell(new Phrase("TOTAIS:", fonteTotal));
                cellLabelTotal.Colspan = colunasMescladas;
                cellLabelTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellLabelTotal.BackgroundColor = BaseColor.LIGHT_GRAY;
                tabela.AddCell(cellLabelTotal);

                PdfPCell cellTotalDebito = new PdfPCell(new Phrase(totalDebito.ToString("C"), fonteTotal));
                cellTotalDebito.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellTotalDebito.BackgroundColor = BaseColor.LIGHT_GRAY;
                tabela.AddCell(cellTotalDebito);

                PdfPCell cellTotalCredito = new PdfPCell(new Phrase(totalCredito.ToString("C"), fonteTotal));
                cellTotalCredito.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellTotalCredito.BackgroundColor = BaseColor.LIGHT_GRAY;
                tabela.AddCell(cellTotalCredito);

                // 9. Adiciona a Linha de Saldo (Dinâmica)
                iTextSharp.text.Font fonteSaldoLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                iTextSharp.text.Font fonteSaldoValor = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                BaseColor corSaldo = (saldo >= 0) ? BaseColor.BLUE : BaseColor.RED;
                fonteSaldoValor.SetColor(corSaldo.R, corSaldo.G, corSaldo.B);

                PdfPCell cellLabelSaldo = new PdfPCell(new Phrase("SALDO (Crédito - Débito):", fonteSaldoLabel));
                cellLabelSaldo.Colspan = colunasMescladas;
                cellLabelSaldo.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabela.AddCell(cellLabelSaldo);

                PdfPCell cellSaldo = new PdfPCell(new Phrase(saldo.ToString("C"), fonteSaldoValor));
                cellSaldo.Colspan = 2; // Mescla as 2 últimas colunas
                cellSaldo.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabela.AddCell(cellSaldo);

                // 10. ADICIONA A TABELA AO DOCUMENTO (APENAS UMA VEZ)
                doc.Add(tabela);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na geração do PDF: " + ex.Message, ex);
            }
            finally
            {
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
        }

       
        public void ExportarDataTableParaExcel(DataTable dt, string caminhoArquivo, string tituloRelatorio)
        {
            // --- CÁLCULO DE TOTAIS ---
            double totalCredito = 0;
            double totalDebito = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalCredito += row.IsNull("CREDITO") ? 0 : Convert.ToDouble(row["CREDITO"]);
                totalDebito += row.IsNull("DEBITO") ? 0 : Convert.ToDouble(row["DEBITO"]);
            }
            double saldo = totalCredito - totalDebito;
            // --- FIM DO CÁLCULO ---

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    // Prepara a Tabela (Remove colunas desnecessárias)
                    DataTable dtView = dt.Copy();
                    dtView.Columns.Remove("ID_FESTA");
                    dtView.Columns.Remove("ID_PESSOA");
                    dtView.Columns.Remove("FESTA");      // <-- REMOVIDO
                    dtView.Columns.Remove("PESSOA");     // <-- REMOVIDO
                    dtView.Columns.Remove("VENDA");      // <-- REMOVIDO

                    var worksheet = workbook.Worksheets.Add(dtView, "Extrato");

                    // Adiciona um Título
                    worksheet.Row(1).InsertRowsAbove(2);
                    var cellTitulo = worksheet.Cell(1, 1);
                    cellTitulo.Value = tituloRelatorio;
                    cellTitulo.Style.Font.Bold = true;
                    cellTitulo.Style.Font.FontSize = 16;

                    // --- LÓGICA DE TOTAIS (DINÂMICA) ---
                    int ultimaLinha = worksheet.LastRowUsed().RowNumber();

                    // Calcula dinamicamente as posições das colunas
                    int colCredito = dtView.Columns.Count; // Última coluna
                    int colDebito = colCredito - 1; // Penúltima coluna
                    int colLabel = colDebito - 1;   // Coluna anterior

                    // Célula "TOTAIS:"
                    var cellLabelTotal = worksheet.Cell(ultimaLinha + 2, colLabel);
                    cellLabelTotal.Value = "TOTAIS:";
                    cellLabelTotal.Style.Font.Bold = true;
                    cellLabelTotal.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    cellLabelTotal.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // Célula Total Débito
                    var cellTotalDebito = worksheet.Cell(ultimaLinha + 2, colDebito);
                    cellTotalDebito.Value = totalDebito;
                    cellTotalDebito.Style.NumberFormat.Format = "R$ #,##0.00";
                    cellTotalDebito.Style.Font.Bold = true;
                    cellTotalDebito.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // Célula Total Crédito
                    var cellTotalCredito = worksheet.Cell(ultimaLinha + 2, colCredito);
                    cellTotalCredito.Value = totalCredito;
                    cellTotalCredito.Style.NumberFormat.Format = "R$ #,##0.00";
                    cellTotalCredito.Style.Font.Bold = true;
                    cellTotalCredito.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // --- LÓGICA DE SALDO (DINÂMICA) ---
                    // Célula "SALDO:"
                    var cellLabelSaldo = worksheet.Cell(ultimaLinha + 3, colLabel);
                    cellLabelSaldo.Value = "SALDO (Crédito - Débito):";
                    cellLabelSaldo.Style.Font.Bold = true;
                    cellLabelSaldo.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // Célula Valor Saldo (mescla as colunas de Débito e Crédito)
                    var cellSaldo = worksheet.Cell(ultimaLinha + 3, colDebito);
                    cellSaldo.Value = saldo;
                    cellSaldo.Style.NumberFormat.Format = "R$ #,##0.00";
                    cellSaldo.Style.Font.Bold = true;
                    cellSaldo.Style.Font.FontSize = 12;
                    cellSaldo.Style.Font.FontColor = (saldo >= 0) ? XLColor.Blue : XLColor.Red;
                    worksheet.Range(ultimaLinha + 3, colDebito, ultimaLinha + 3, colCredito).Merge();
                    cellSaldo.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // Ajusta o tamanho das colunas ao conteúdo
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(caminhoArquivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na geração do Excel: " + ex.Message, ex);
            }
        }

        public void ExportarVendasGeralPDF(DataTable dt, string caminhoArquivo, string tituloRelatorio, string subtitulo)
        {
            // --- Cálculo do Total Geral ---
            double totalGeral = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalGeral += row.IsNull("VALOR_TOTAL") ? 0 : Convert.ToDouble(row["VALOR_TOTAL"]);
            }
            // --- Fim do Cálculo ---

            Document doc = new Document(PageSize.A4); // Retrato

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));
                doc.Open();

                // Título e Subtítulo
                iTextSharp.text.Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                doc.Add(new Paragraph(tituloRelatorio + "\n", fonteTitulo) { Alignment = Element.ALIGN_CENTER });

                iTextSharp.text.Font fonteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                doc.Add(new Paragraph(subtitulo + "\n\n", fonteSubtitulo) { Alignment = Element.ALIGN_CENTER });

                // Tabela (Descricao, QTDE_TOTAL, VALOR_TOTAL)
                PdfPTable tabela = new PdfPTable(dt.Columns.Count);
                tabela.WidthPercentage = 100;
                tabela.SetWidths(new float[] { 4f, 1.5f, 2f }); // Coluna Descricao (4f) mais larga

                // Cabeçalhos
                iTextSharp.text.Font fonteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                foreach (DataColumn column in dt.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName.Replace("_", " "), fonteHeader)); // Troca "QTDE_TOTAL" por "QTDE TOTAL"
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(cell);
                }

                // Linhas de Dados
                iTextSharp.text.Font fonteCelulas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (DataRow row in dt.Rows)
                {
                    tabela.AddCell(new Phrase(row["Descricao"].ToString(), fonteCelulas));

                    tabela.AddCell(new PdfPCell(new Phrase(row["QTDE_TOTAL"].ToString(), fonteCelulas))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    });

                    tabela.AddCell(new PdfPCell(new Phrase(Convert.ToDouble(row["VALOR_TOTAL"]).ToString("C"), fonteCelulas))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    });
                }

                // --- Linha de Total Geral ---
                iTextSharp.text.Font fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);

                PdfPCell cellLabelTotal = new PdfPCell(new Phrase("TOTAL GERAL:", fonteTotal));
                cellLabelTotal.Colspan = 2; // Mescla as 2 primeiras colunas
                cellLabelTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellLabelTotal.BackgroundColor = BaseColor.LIGHT_GRAY;
                tabela.AddCell(cellLabelTotal);

                PdfPCell cellTotal = new PdfPCell(new Phrase(totalGeral.ToString("C"), fonteTotal));
                cellTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellTotal.BackgroundColor = BaseColor.LIGHT_GRAY;
                tabela.AddCell(cellTotal);

                doc.Add(tabela);
            }
            catch (Exception ex) { throw new Exception("Erro PDF: " + ex.Message, ex); }
            finally { if (doc.IsOpen()) doc.Close(); }
        }

        public void ExportarVendasGeralExcel(DataTable dt, string caminhoArquivo, string tituloRelatorio)
        {
            // --- Cálculo do Total Geral ---
            double totalGeral = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalGeral += row.IsNull("VALOR_TOTAL") ? 0 : Convert.ToDouble(row["VALOR_TOTAL"]);
            }
            // --- Fim do Cálculo ---

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(dt, "VendasGeral");

                    // Adiciona um Título
                    worksheet.Row(1).InsertRowsAbove(2);
                    var cellTitulo = worksheet.Cell(1, 1);
                    cellTitulo.Value = tituloRelatorio;
                    cellTitulo.Style.Font.Bold = true;
                    cellTitulo.Style.Font.FontSize = 16;

                    // --- Linha de Total Geral ---
                    int ultimaLinha = worksheet.LastRowUsed().RowNumber();

                    var cellLabelTotal = worksheet.Cell(ultimaLinha + 2, 2); // Coluna B
                    cellLabelTotal.Value = "TOTAL GERAL:";
                    cellLabelTotal.Style.Font.Bold = true;
                    cellLabelTotal.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    cellLabelTotal.Style.Fill.BackgroundColor = XLColor.LightGray;

                    var cellTotal = worksheet.Cell(ultimaLinha + 2, 3); // Coluna C
                    cellTotal.Value = totalGeral;
                    cellTotal.Style.NumberFormat.Format = "R$ #,##0.00";
                    cellTotal.Style.Font.Bold = true;
                    cellTotal.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // Ajusta o tamanho das colunas ao conteúdo
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(caminhoArquivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Excel: " + ex.Message, ex);
            }
        }

        public void ExportarExtratoGeralPDF(DataTable dt, string caminhoArquivo, string tituloRelatorio, string subtitulo)
        {
            // --- CÁLCULO DE TOTAIS ---
            double totalCredito = 0;
            double totalDebito = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalCredito += row.IsNull("CREDITO") ? 0 : Convert.ToDouble(row["CREDITO"]);
                totalDebito += row.IsNull("DEBITO") ? 0 : Convert.ToDouble(row["DEBITO"]);
            }
            double saldo = totalCredito - totalDebito;
            // --- FIM DO CÁLCULO ---

            Document doc = new Document(PageSize.A4.Rotate()); // Paisagem

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));
                doc.Open();

                // Títulos
                doc.Add(new Paragraph(tituloRelatorio + "\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph(subtitulo + "\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)) { Alignment = Element.ALIGN_CENTER });

        
                // 5. Prepara a Tabela (Seleciona as colunas corretas do 'dt')
                // A coluna de data no seu 'relatorio_venda' chama-se 'DTHORA'.
                DataTable dtView = dt.DefaultView.ToTable(false, "DTHORA", "VENDEDOR", "DESCRICAO", "QTDE", "VLRUNIT", "DEBITO", "CREDITO");

                PdfPTable tabela = new PdfPTable(dtView.Columns.Count); // Contagem de colunas agora é 7
                tabela.WidthPercentage = 100;

                // Define as larguras relativas corretas para as 7 colunas
                float[] widths = new float[] { 2f, 2f, 4f, 1f, 1.5f, 1.5f, 1.5f };
                tabela.SetWidths(widths);

                // 6. Adiciona os Cabeçalhos
                iTextSharp.text.Font fonteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                foreach (DataColumn column in dtView.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, fonteHeader));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(cell);
                }

                // 7. Adiciona as Linhas de Dados
                iTextSharp.text.Font fonteGrupoHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                iTextSharp.text.Font fonteCelulas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                string currentPessoa = "";
                double subTotalCredito = 0;
                double subTotalDebito = 0;

                // Loop principal com quebra de grupo
                foreach (DataRow row in dt.Rows)
                {
                    string pessoaDaLinha = row["PESSOA"].ToString();

                    // 1. DETECTA A QUEBRA DE GRUPO
                    if (pessoaDaLinha != currentPessoa)
                    {
                        // 2. Imprime o rodapé do grupo anterior
                        if (currentPessoa != "")
                        {
                            AdicionarLinhaSubtotalPDF(tabela, subTotalDebito, subTotalCredito, dtView.Columns.Count);
                        }

                        // 3. Reseta subtotais e define a nova pessoa
                        subTotalCredito = 0;
                        subTotalDebito = 0;
                        currentPessoa = pessoaDaLinha;

                        // 4. Imprime o cabeçalho do novo grupo
                        PdfPCell cellHeaderPessoa = new PdfPCell(new Phrase("Pessoa: " + currentPessoa, fonteGrupoHeader));
                        cellHeaderPessoa.Colspan = dtView.Columns.Count;
                        cellHeaderPessoa.BackgroundColor = new BaseColor(220, 220, 220); // Cinza mais claro
                        tabela.AddCell(cellHeaderPessoa);
                    }

                    // 5. Adiciona a linha de dados atual (usando o dtView)
                    foreach (DataColumn column in dtView.Columns)
                    {
                        string valorCelula = "";
                        PdfPCell cell = new PdfPCell();
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;

                        // Usa o 'row[column.ColumnName]' para pegar o valor do DataTable original 'dt'
                        // mas apenas para as colunas que estão no 'dtView'
                        if (column.ColumnName == "DEBITO" || column.ColumnName == "CREDITO" || column.ColumnName == "VLRUNIT")
                        {
                            double valor = row.IsNull(column.ColumnName) ? 0.0 : Convert.ToDouble(row[column.ColumnName]);
                            valorCelula = valor.ToString("C");
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }
                        else if (column.ColumnName == "QTDE")
                        {
                            valorCelula = row.IsNull(column.ColumnName) ? "0" : row[column.ColumnName].ToString();
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }
                        else
                        {
                            valorCelula = row[column.ColumnName].ToString();
                        }
                        cell.Phrase = new Phrase(valorCelula, fonteCelulas);
                        tabela.AddCell(cell);
                    }

                    // 6. Acumula subtotais (lendo do DataTable 'dt' original)
                    subTotalCredito += row.IsNull("CREDITO") ? 0 : Convert.ToDouble(row["CREDITO"]);
                    subTotalDebito += row.IsNull("DEBITO") ? 0 : Convert.ToDouble(row["DEBITO"]);
                }

                // 7. Imprime o rodapé do ÚLTIMO grupo
                AdicionarLinhaSubtotalPDF(tabela, subTotalDebito, subTotalCredito, dtView.Columns.Count);

                // 8. Imprime o TOTAL GERAL
                //AdicionarLinhaTotalGeralPDF(tabela, grandTotalDebito, grandTotalCredito, dtView.Columns.Count);
                AdicionarLinhaTotalGeralPDF(tabela, totalDebito, totalCredito, dtView.Columns.Count);
                doc.Add(tabela);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na geração do PDF: " + ex.Message, ex);
            }
            finally
            {
                if (doc.IsOpen()) doc.Close();
            }
        }

        private void AdicionarLinhaSubtotalPDF(PdfPTable tabela, double debito, double credito, int colCount)
        {
            iTextSharp.text.Font fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            int colunasMescladas = colCount - 2;
            double saldo = credito - debito;

            // Linha de Subtotal
            PdfPCell cellLabelTotal = new PdfPCell(new Phrase("Subtotal Pessoa:", fonteTotal));
            cellLabelTotal.Colspan = colunasMescladas;
            cellLabelTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabela.AddCell(cellLabelTotal);

            tabela.AddCell(new PdfPCell(new Phrase(debito.ToString("C"), fonteTotal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
            tabela.AddCell(new PdfPCell(new Phrase(credito.ToString("C"), fonteTotal)) { HorizontalAlignment = Element.ALIGN_RIGHT });

            // Linha de Saldo
            iTextSharp.text.Font fonteSaldoValor = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            BaseColor corSaldo = (saldo >= 0) ? BaseColor.BLUE : BaseColor.RED;
            fonteSaldoValor.SetColor(corSaldo.R, corSaldo.G, corSaldo.B);

            PdfPCell cellLabelSaldo = new PdfPCell(new Phrase("Saldo Pessoa:", fonteTotal));
            cellLabelSaldo.Colspan = colunasMescladas;
            cellLabelSaldo.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabela.AddCell(cellLabelSaldo);

            PdfPCell cellSaldo = new PdfPCell(new Phrase(saldo.ToString("C"), fonteSaldoValor));
            cellSaldo.Colspan = 2; // Mescla as 2 últimas colunas
            cellSaldo.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabela.AddCell(cellSaldo);
        }

        private void AdicionarLinhaTotalGeralPDF(PdfPTable tabela, double debito, double credito, int colCount)
        {
            iTextSharp.text.Font fonteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            int colunasMescladas = colCount - 2;
            double saldo = credito - debito;

            // Linha de Total Geral
            PdfPCell cellLabelTotal = new PdfPCell(new Phrase("TOTAL GERAL FESTA:", fonteTotal));
            cellLabelTotal.Colspan = colunasMescladas;
            cellLabelTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellLabelTotal.BackgroundColor = BaseColor.LIGHT_GRAY;
            tabela.AddCell(cellLabelTotal);

            tabela.AddCell(new PdfPCell(new Phrase(debito.ToString("C"), fonteTotal)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY });
            tabela.AddCell(new PdfPCell(new Phrase(credito.ToString("C"), fonteTotal)) { HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = BaseColor.LIGHT_GRAY });

            // Linha de Saldo Geral
            iTextSharp.text.Font fonteSaldoValor = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13);
            BaseColor corSaldo = (saldo >= 0) ? BaseColor.BLUE : BaseColor.RED;
            fonteSaldoValor.SetColor(corSaldo.R, corSaldo.G, corSaldo.B);

            PdfPCell cellLabelSaldo = new PdfPCell(new Phrase("SALDO GERAL FESTA:", fonteTotal));
            cellLabelSaldo.Colspan = colunasMescladas;
            cellLabelSaldo.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabela.AddCell(cellLabelSaldo);

            PdfPCell cellSaldo = new PdfPCell(new Phrase(saldo.ToString("C"), fonteSaldoValor));
            cellSaldo.Colspan = 2;
            cellSaldo.HorizontalAlignment = Element.ALIGN_RIGHT;
            tabela.AddCell(cellSaldo);
        }

        public void ExportarExtratoGeralExcel(DataTable dt, string caminhoArquivo, string tituloRelatorio)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("ExtratoGeral");

                    // Adiciona um Título
                    worksheet.Cell(1, 1).Value = tituloRelatorio;
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                    worksheet.Range(1, 1, 1, 7).Merge(); // Mescla 7 colunas para o título

                    // Cabeçalhos
                    int colIdx = 1;
                    int rowIdx = 3;
                    var dtView = dt.DefaultView.ToTable(false, "DTHORA", "VENDEDOR", "DESCRICAO", "QTDE", "VLRUNIT", "DEBITO", "CREDITO");
                    foreach (DataColumn column in dtView.Columns)
                    {
                        worksheet.Cell(rowIdx, colIdx).Value = column.ColumnName.Replace("_", " ");
                        worksheet.Cell(rowIdx, colIdx).Style.Font.Bold = true;
                        worksheet.Cell(rowIdx, colIdx).Style.Fill.BackgroundColor = XLColor.LightGray;
                        colIdx++;
                    }
                    rowIdx++;

                    // --- Lógica de Agrupamento ---
                    double grandTotalCredito = 0;
                    double grandTotalDebito = 0;
                    double subTotalCredito = 0;
                    double subTotalDebito = 0;
                    string currentPessoa = "";
                    int colCount = dtView.Columns.Count; // 7

                    foreach (DataRow row in dt.Rows)
                    {
                        string pessoaDaLinha = row["PESSOA"].ToString();

                        // 1. DETECTA A QUEBRA DE GRUPO
                        if (pessoaDaLinha != currentPessoa)
                        {
                            // 2. Imprime o total do grupo anterior (se houver)
                            if (currentPessoa != "")
                            {
                                double saldoPessoa = subTotalCredito - subTotalDebito;
                                worksheet.Cell(rowIdx, colCount - 2).Value = "Subtotal Pessoa:";
                                worksheet.Cell(rowIdx, colCount - 1).Value = subTotalDebito;
                                worksheet.Cell(rowIdx, colCount).Value = subTotalCredito;
                                worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount).Style.Font.Bold = true;

                                rowIdx++;
                                worksheet.Cell(rowIdx, colCount - 2).Value = "Saldo Pessoa:";
                                worksheet.Cell(rowIdx, colCount - 1).Value = saldoPessoa;
                                worksheet.Range(rowIdx, colCount - 1, rowIdx, colCount).Merge();
                                worksheet.Cell(rowIdx, colCount - 1).Style.Font.FontColor = (saldoPessoa >= 0) ? XLColor.Blue : XLColor.Red;
                                worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount - 1).Style.Font.Bold = true;

                                rowIdx++;
                            }

                            // 3. Reseta e define a nova pessoa
                            subTotalCredito = 0;
                            subTotalDebito = 0;
                            currentPessoa = pessoaDaLinha;

                            // 4. Imprime o cabeçalho do novo grupo
                            worksheet.Cell(rowIdx, 1).Value = "Pessoa: " + currentPessoa;
                            worksheet.Range(rowIdx, 1, rowIdx, colCount).Merge();
                            worksheet.Cell(rowIdx, 1).Style.Font.Bold = true;
                            worksheet.Cell(rowIdx, 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                            rowIdx++;
                        }

                        // 5. Adiciona a linha de dados atual
                        colIdx = 1;
                        //foreach (DataColumn column in dtView.Columns)
                        foreach(DataColumn column in dt.Columns)
                        {
                            var cell = worksheet.Cell(rowIdx, colIdx);

                            if(dtView.Columns.Contains(column.ColumnName))
                            { 
                                object value = row[column];

                                if (value is double || value is decimal)
                                {
                                    cell.Value = Convert.ToDouble(value);
                                }
                                else if (value is int || value is long)
                                {
                                    cell.Value = Convert.ToInt32(value);
                                }
                                else if (value is DateTime)
                                {
                                    cell.Value = (DateTime)value;
                                }
                                else
                                {
                                    cell.Value = value.ToString();
                                }
                                colIdx++;
                            }
                        }

                        // 6. Acumula totais
                        subTotalCredito += row.IsNull("CREDITO") ? 0 : Convert.ToDouble(row["CREDITO"]);
                        subTotalDebito += row.IsNull("DEBITO") ? 0 : Convert.ToDouble(row["DEBITO"]);
                        grandTotalCredito += row.IsNull("CREDITO") ? 0 : Convert.ToDouble(row["CREDITO"]);
                        grandTotalDebito += row.IsNull("DEBITO") ? 0 : Convert.ToDouble(row["DEBITO"]);

                        rowIdx++;
                    }

                    // 7. Imprime o rodapé do ÚLTIMO grupo
                    double saldoUltimaPessoa = subTotalCredito - subTotalDebito;
                    worksheet.Cell(rowIdx, colCount - 2).Value = "Subtotal Pessoa:";
                    worksheet.Cell(rowIdx, colCount - 1).Value = subTotalDebito;
                    worksheet.Cell(rowIdx, colCount).Value = subTotalCredito;
                    worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount).Style.Font.Bold = true;

                    rowIdx++;
                    worksheet.Cell(rowIdx, colCount - 2).Value = "Saldo Pessoa:";
                    worksheet.Cell(rowIdx, colCount - 1).Value = saldoUltimaPessoa;
                    worksheet.Range(rowIdx, colCount - 1, rowIdx, colCount).Merge();
                    worksheet.Cell(rowIdx, colCount - 1).Style.Font.FontColor = (saldoUltimaPessoa >= 0) ? XLColor.Blue : XLColor.Red;
                    worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount - 1).Style.Font.Bold = true;

                    rowIdx += 2;

                    // 8. Imprime o TOTAL GERAL
                    double saldoGeral = grandTotalCredito - grandTotalDebito;
                    worksheet.Cell(rowIdx, colCount - 2).Value = "TOTAL GERAL FESTA:";
                    worksheet.Cell(rowIdx, colCount - 1).Value = grandTotalDebito;
                    worksheet.Cell(rowIdx, colCount).Value = grandTotalCredito;
                    worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount).Style.Font.Bold = true;
                    worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount).Style.Fill.BackgroundColor = XLColor.DarkGray;
                    worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount).Style.Font.FontColor = XLColor.White;

                    rowIdx++;
                    worksheet.Cell(rowIdx, colCount - 2).Value = "SALDO GERAL FESTA:";
                    worksheet.Cell(rowIdx, colCount - 1).Value = saldoGeral;
                    worksheet.Range(rowIdx, colCount - 1, rowIdx, colCount).Merge();
                    worksheet.Cell(rowIdx, colCount - 1).Style.Font.FontColor = (saldoGeral >= 0) ? XLColor.Blue : XLColor.Red;
                    worksheet.Range(rowIdx, colCount - 2, rowIdx, colCount - 1).Style.Font.Bold = true;
                    worksheet.Cell(rowIdx, colCount - 1).Style.Font.FontSize = 13;

                    // Formata as colunas numéricas
                    worksheet.Column(4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right; // QTDE
                    worksheet.Column(5).Style.NumberFormat.Format = "R$ #,##0.00"; // VLRUNIT
                    worksheet.Column(6).Style.NumberFormat.Format = "R$ #,##0.00"; // DEBITO
                    worksheet.Column(7).Style.NumberFormat.Format = "R$ #,##0.00"; // CREDITO

                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(caminhoArquivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na geração do Excel: " + ex.Message, ex);
            }
        }

        public void ExportarCaixaPDF(DataTable dt, string caminhoArquivo, string tituloRelatorio, string subtitulo)
        {
            // --- 1. LÓGICA DE PROCESSAMENTO DO CAIXA ---
            double valorAbertura = 0;
            double totalEntradas = 0; // Total de 'v', 'e', 'c'
            double totalSaidas = 0;   // Total de 'r'

            // Tabela temporária apenas para as linhas de movimento
            DataTable dtMovimentos = new DataTable();
            dtMovimentos.Columns.Add("DTMOV");
            dtMovimentos.Columns.Add("DESCRICAO");
            dtMovimentos.Columns.Add("ENTRADA");
            dtMovimentos.Columns.Add("SAIDA");
            dtMovimentos.Columns.Add("USUARIO");

            foreach (DataRow row in dt.Rows)
            {
                string tipo = row.IsNull("TIPOMOV") ? "" : row["TIPOMOV"].ToString().ToLower();

                if (tipo == "a") // Abertura 
                {
                    valorAbertura += row.IsNull("ENTRADA") ? 0 : Convert.ToDouble(row["ENTRADA"]);
                }
                else
                {
                    // Adiciona a linha na tabela de movimentos
                    dtMovimentos.Rows.Add(
                        row["DTMOV"],
                        row["DESCRICAO"],
                        row["ENTRADA"],
                        row["SAIDA"],
                        row["USUARIO"]
                    );

                   
                    totalEntradas += row.IsNull("ENTRADA") ? 0 : Convert.ToDouble(row["ENTRADA"]);
                    totalSaidas += row.IsNull("SAIDA") ? 0 : Convert.ToDouble(row["SAIDA"]);
                }
            }
            double saldoFinal = valorAbertura + totalEntradas - totalSaidas; // 
                                                                             // --- FIM DA LÓGICA ---

            // 2. Geração do PDF
            Document doc = new Document(PageSize.A4); // Retrato

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));
                doc.Open();

                // Títulos
                doc.Add(new Paragraph(tituloRelatorio + "\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph(subtitulo + "\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 12)) { Alignment = Element.ALIGN_CENTER });

                // --- 3. Bloco de Abertura ---
                PdfPTable tabelaAbertura = new PdfPTable(2);
                tabelaAbertura.WidthPercentage = 100;
                tabelaAbertura.SetWidths(new float[] { 3f, 1f });

                iTextSharp.text.Font fonteBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                PdfPCell cellLabelAbertura = new PdfPCell(new Phrase("Valor de Abertura:", fonteBold));
                cellLabelAbertura.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellLabelAbertura.Border = iTextSharp.text.Rectangle.NO_BORDER;

                PdfPCell cellValorAbertura = new PdfPCell(new Phrase(valorAbertura.ToString("C"), fonteBold));
                cellValorAbertura.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellValorAbertura.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tabelaAbertura.AddCell(cellLabelAbertura);
                tabelaAbertura.AddCell(cellValorAbertura);
                doc.Add(tabelaAbertura);
                doc.Add(new Paragraph("\n")); // Espaçamento

                // --- 4. Tabela de Movimentações ---
                doc.Add(new Paragraph("Movimentações do Caixa:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                PdfPTable tabelaMov = new PdfPTable(dtMovimentos.Columns.Count);
                tabelaMov.WidthPercentage = 100;
                tabelaMov.SetWidths(new float[] { 2f, 4f, 1.5f, 1.5f, 1.5f }); // DTMOV, DESC, ENTRADA, SAIDA, USUARIO

                // Cabeçalhos
                iTextSharp.text.Font fonteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                foreach (DataColumn column in dtMovimentos.Columns)
                {
                    tabelaMov.AddCell(CriarCelulaHeader(column.ColumnName, fonteHeader));
                }

                // Linhas de Dados
                iTextSharp.text.Font fonteCelulas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (DataRow row in dtMovimentos.Rows)
                {
                    tabelaMov.AddCell(CriarCelulaDado(row, "DTMOV", fonteCelulas));
                    tabelaMov.AddCell(CriarCelulaDado(row, "DESCRICAO", fonteCelulas));
                    tabelaMov.AddCell(CriarCelulaDado(row, "ENTRADA", fonteCelulas));
                    tabelaMov.AddCell(CriarCelulaDado(row, "SAIDA", fonteCelulas));
                    tabelaMov.AddCell(CriarCelulaDado(row, "USUARIO", fonteCelulas));
                }
                doc.Add(tabelaMov);
                doc.Add(new Paragraph("\n")); // Espaçamento

                // --- 5. Bloco de Resumo (Saldo Final) ---
                doc.Add(new Paragraph("Fechamento:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                PdfPTable tabelaResumo = new PdfPTable(2);
                tabelaResumo.WidthPercentage = 100;
                tabelaResumo.SetWidths(new float[] { 3f, 1f });

                // Reusa os métodos auxiliares de alinhamento
                tabelaResumo.AddCell(CriarCelulaResumo("Valor de Abertura:", fonteCelulas, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));
                tabelaResumo.AddCell(CriarCelulaResumo(valorAbertura.ToString("C"), fonteCelulas, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));

                tabelaResumo.AddCell(CriarCelulaResumo("Total de Entradas (Vendas/Créditos/Outras):", fonteCelulas, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));
                tabelaResumo.AddCell(CriarCelulaResumo(totalEntradas.ToString("C"), fonteCelulas, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));

                tabelaResumo.AddCell(CriarCelulaResumo("Total de Saídas (Retiradas):", fonteCelulas, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));
                tabelaResumo.AddCell(CriarCelulaResumo(totalSaidas.ToString("C"), fonteCelulas, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));

                // Linha do Saldo
                iTextSharp.text.Font fonteSaldo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13);
                BaseColor corSaldo = (saldoFinal >= 0) ? BaseColor.BLUE : BaseColor.RED;
                fonteSaldo.SetColor(corSaldo.R, corSaldo.G, corSaldo.B);

                tabelaResumo.AddCell(CriarCelulaResumo("SALDO FINAL (Abertura + Entradas - Saídas):", fonteSaldo, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));
                tabelaResumo.AddCell(CriarCelulaResumo(saldoFinal.ToString("C"), fonteSaldo, Element.ALIGN_RIGHT, iTextSharp.text.Rectangle.NO_BORDER));

                doc.Add(tabelaResumo);
            }
            catch (Exception ex) { throw new Exception("Erro PDF: " + ex.Message, ex); }
            finally { if (doc.IsOpen()) doc.Close(); }
        }

        private PdfPCell CriarCelulaResumo(string texto, iTextSharp.text.Font fonte, int alinhamento, int borda)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, fonte));
            cell.HorizontalAlignment = alinhamento;
            cell.Border = borda;
            return cell;
        }

        private PdfPCell CriarCelulaHeader(string texto, iTextSharp.text.Font fonte)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, fonte));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            return cell;
        }

        private PdfPCell CriarCelulaDado(DataRow row, string nomeColuna, iTextSharp.text.Font fonte)
        {
            string valorCelula = "";
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_LEFT; // Padrão

            // Verifica colunas de moeda
            if (nomeColuna == "DEBITO" || nomeColuna == "CREDITO" || nomeColuna == "VLRUNIT" || nomeColuna == "VLRTOTAL" || nomeColuna == "ENTRADA" || nomeColuna == "SAIDA")
            {
                double valor = row.IsNull(nomeColuna) ? 0.0 : Convert.ToDouble(row[nomeColuna]);
                valorCelula = valor.ToString("C");
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            // Verifica colunas de quantidade
            else if (nomeColuna == "QTDE")
            {
                valorCelula = row.IsNull(nomeColuna) ? "0" : row[nomeColuna].ToString();
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            // Outras colunas (texto, data, etc.)
            else
            {
                valorCelula = row.IsNull(nomeColuna) ? "" : row[nomeColuna].ToString();
            }

            cell.Phrase = new Phrase(valorCelula, fonte);
            return cell;
        }

    }
}