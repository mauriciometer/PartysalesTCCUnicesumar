using QRCoder;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace PartySalesTUCG
{
    public partial class FrmPix : Form
    {
        private string qrPix;
        private double valor;
        private bool pago = false;

        public FrmPix(string _QRPix, double _Valor)
        {
            this.qrPix = _QRPix;
            this.valor = _Valor;
            InitializeComponent();

            this.txtValor.Text = _Valor.ToString("C");
            geraQRPix();
        }

        public double Valor { get { return this.valor; } }
        private void geraQRPix()
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrPix, QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(3);
            pbPix.Image = qrCodeImage;
        }
        private void btnPago_Click(object sender, EventArgs e)
        {
            this.pago = true;
            this.Close();
        }

        public bool recebePix()
        {
            this.ShowDialog();
            return this.pago;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.pago = false;
            this.Close();
        }
    }
}
