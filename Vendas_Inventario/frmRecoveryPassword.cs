﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;

namespace Vendas_Inventario
{
    public partial class frmRecoveryPassword : Form
    {
         String cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\SIS_DB.accdb;";

        public frmRecoveryPassword()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Informe o seu email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            try
            {
                 Cursor = Cursors.WaitCursor;
                 timer1.Enabled = true;
                DataSet ds = new DataSet();
                OleDbConnection con = new OleDbConnection(cs);
                con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT User_Password FROM Registration Where Email = '" + txtEmail.Text + "'", con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress("abcd@gmail.com");
                    // Recipient e-mail address.
                    Msg.To.Add(txtEmail.Text);
                    Msg.Subject = "Detalhes de sua senha:";
                    Msg.Body = "Sua Senha: " + Convert.ToString(ds.Tables[0].Rows[0]["user_Password"]) + "";
                    Msg.IsBodyHtml = true;
                    // your remote SMTP server IP.
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("abcd@gmail.com", "abcd");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    MessageBox.Show(("Senha enviada com sucesso " + ("\r\n" + "Verifica o seu emmail")), "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Hide();
                    frmLogin LoginForm1 = new frmLogin();
                    LoginForm1.Show();
                    LoginForm1.txtUserName.Text = "";
                    LoginForm1.txtPassword.Text = "";
                    LoginForm1.ProgressBar1.Visible = false;
                    LoginForm1.txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecoveryPassword_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void RecoveryPassword_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Hide();
            frmLogin frm = new frmLogin();
            frm.txtUserName.Text = "";
            frm.txtPassword.Text = "";
            frm.txtUserName.Focus();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
           timer1.Enabled = false;
        }

       
    }
}
