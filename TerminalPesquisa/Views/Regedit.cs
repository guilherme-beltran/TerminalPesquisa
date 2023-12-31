﻿namespace TerminalPesquisa
{
    public partial class Regedit : Form
    {
        #region Construtor
        public Regedit()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void Regedit_Load(object sender, EventArgs e)
        {
            txtInstancia.Text = Properties.Settings.Default.Instancia;
            txtBanco.Text = Properties.Settings.Default.Banco;
            txtUsuario.Text = Properties.Settings.Default.Usuario;
            txtSenha.Text = Properties.Settings.Default.Senha;
            Properties.Settings.Default.stringConexao = @"Data Source=" + Properties.Settings.Default.Instancia + ";Initial Catalog=" + Properties.Settings.Default.Banco + ";User ID=" + Properties.Settings.Default.Usuario + ";Password=" + Properties.Settings.Default.Senha + ";Encrypt=False";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Control | Keys.Enter:
                    btnSalvar.PerformClick();
                    break;
                case Keys.Enter:
                    btnEditar.PerformClick();
                    break;
                case Keys.Delete:
                    btnLimpar.PerformClick();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Botões
        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitaEdicao();
        }

        private void bnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Instancia = txtInstancia.Text;
            Properties.Settings.Default.Banco = txtBanco.Text;
            Properties.Settings.Default.Usuario = txtUsuario.Text;
            Properties.Settings.Default.Senha = txtSenha.Text;

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            Properties.Settings.Default.stringConexao = @"Data Source=" + Properties.Settings.Default.Instancia + ";Initial Catalog=" + Properties.Settings.Default.Banco + ";User ID=" + Properties.Settings.Default.Usuario + ";Password=" + Properties.Settings.Default.Senha + ";Encrypt=False";
            MessageBox.Show("Configurações salvas com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void pbDuvidas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter -> Editar\n\nCTRL + Enter -> Salvar\n\nDelete -> Limpar formulário", "Atalhos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Métodos
        private void HabilitaEdicao()
        {
            txtInstancia.Enabled = true;
            txtBanco.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
        }

        private void Limpar()
        {
            txtInstancia.Text = "";
            txtBanco.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }
        #endregion

    }
}
