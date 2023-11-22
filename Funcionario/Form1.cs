using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;

namespace Funcionario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtCPF.Text.Equals("") && !txtEndereco.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Nome = txtNome.Text;
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Cpf = txtCPF.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;

                    if (cadFuncionarios.cadastrarFuncionarios())
                    {
                        MessageBox.Show($"O funcion�rio {cadFuncionarios.Nome} foi cadastrado com sucesso!");
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCPF.Clear();
                        txtEndereco.Clear();
                        txtNome.Focus();
                    }
                    else
                    {
                        MessageBox.Show("N�o foi poss�vel cadastrar Funcion�rio!");
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher todos os campos corretamente!");
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtCPF.Clear();
                    txtEndereco.Clear();
                    txtNome.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionario: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCPF.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Cpf = txtCPF.Text;

                    MySqlDataReader reader = cadFuncionarios.localizarFuncionario();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            lblId.Text = reader["id"].ToString();
                            txtNome.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtEndereco.Text = reader["endereco"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Funcion�rio n�o encontrado");
                            txtCPF.Clear();
                            txtNome.Clear();
                            txtEmail.Clear();
                            txtEndereco.Clear();
                            txtCPF.Focus();
                            lblId.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcion�rio n�o encontrado");
                        txtCPF.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtCPF.Focus();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CPF para realizar a sua pesquisa!");
                    txtCPF.Clear();
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    txtCPF.Focus();
                    lblId.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao encontar o funcion�rio: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCPF.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            lblId.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCPF.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;

                    if (cadFuncionarios.atualizarFuncionario())
                    {
                        MessageBox.Show(" os dados do funcion�rio foram atualizadas com sucesso!");
                        txtCPF.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtCPF.Focus();
                        lblId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("n�o foi poss�vel atualizar os dados do funcion�rio");
                        txtCPF.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtCPF.Focus();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor localizar o funcion�rio que desseja atualizar as informa��es");
                    txtCPF.Clear();
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    txtCPF.Focus();
                    lblId.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados do funcion�rio" + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCPF.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Equals(""))
                {
                    cadastroFuncionarios cadFuncionarios = new cadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);
                    if (cadFuncionarios.deletarFuncionario())
                    {
                        MessageBox.Show("O funcion�rio foi exclu�do com sucesso!");
                        txtCPF.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("N�o foi poss�vel excluir funcion�rio");
                        txtCPF.Clear();
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor pesquisar qual funci�nario deseja excluir");
                    txtCPF.Clear();
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    txtCPF.Focus();
                    lblId.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir funcion�rios:" + ex.Message);
            }
        }
    }
}
