using Gerador.EAN;
using System;

namespace Gerador.Forms
{
    public partial class frmPrincipal : DevExpress.XtraEditors.XtraForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                textEdit1.Text = string.Empty;
                var random = new Random();
                var codigobarras = EAN13.GerarCodigoBarras("789", "001", string.Empty + random.Next(1, 999999).ToString("000000"));
                if (EAN13.Validar(codigobarras))
                {
                    textEdit1.Text = codigobarras;
                }
                else
                {
                    textEdit1.Text = string.Empty;
                }
            }
        }
    }
}