using System;
using System.Windows.Forms;

namespace Vendas_Inventario
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            progressBar1.Visible = true;

            this.progressBar1.Value = this.progressBar1.Value + 2;
            if (this.progressBar1.Value == 10)
            {
                label3.Text = "Lendo Módulos..";
            }
            else if (this.progressBar1.Value == 20)
            {
                label3.Text = "Ativando Módulos.";
            }
            else if (this.progressBar1.Value == 40)
            {
                label3.Text = "Iniciando Módulos..";
            }
            else if (this.progressBar1.Value == 60)
            {
                label3.Text = "Carregando Módulos..";
            }
            else if (this.progressBar1.Value == 80)
            {
                label3.Text = "Carga de Módulos concluída.";
            }
            else if (this.progressBar1.Value == 100)
            {
                frm.Show();
                timer1.Enabled = false;
                this.Hide();
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }
    }
}
