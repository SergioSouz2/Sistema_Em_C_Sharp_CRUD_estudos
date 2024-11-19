using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funcionarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SubmitCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtName.Text.Equals("") && !txtEmail.Text.Equals("") && !txtCpf.Text.Equals("") && !txtEndereco.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionarios = new CadastroFuncionarios();
                    cadFuncionarios.Nome = txtName.Text;
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Cpf = txtCpf.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;


                    if (cadFuncionarios.CadastrarFuncionarios())
                    {
                        MessageBox.Show($"O funcionario {cadFuncionarios.Nome} foi cadastrado com sucesso!");
                        txtName.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel cadastrar Funcionario!");
                    }
                }
                else
                {
                    MessageBox.Show($"Por Favor preencha todos os campos corretamente!");
                    txtName.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar funcionario: {ex.Message}");
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtPesquisa.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionarios = new CadastroFuncionarios();
                    cadFuncionarios.Pesquisa = txtPesquisa.Text;


                    MySqlDataReader reader = cadFuncionarios.LocalizarFuncionario();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            lstPesquisa.Items.Add(reader["nome"]);
                            lblId.Text = reader["id"].ToString();
                            txtName.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtCpf.Text = reader["cpf"].ToString();
                            txtEndereco.Text = reader["endereco"].ToString();
                            txtPesquisa.Clear();
                        }
                        else
                        {
                            MessageBox.Show($"Funcionario não encontrado");

                            txtName.Clear();
                            txtEmail.Clear();
                            txtCpf.Clear();
                            txtEndereco.Clear();
                            txtPesquisa.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Funcionario não encontrado");

                        txtName.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtPesquisa.Focus();
                    }
                }
                else
                {
                    MessageBox.Show($"Por favor informe um cpf para realizar a pesquisa!");
                    txtName.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtPesquisa.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar funcionario: {ex.Message}");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtName.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionario = new CadastroFuncionarios();
                    cadFuncionario.Id = int.Parse(lblId.Text);
                    cadFuncionario.Email = txtEmail.Text;
                    cadFuncionario.Endereco = txtEndereco.Text;

                    if (cadFuncionario.AtualizarFuncionario())
                    {
                        MessageBox.Show($"Os dados do funcionario foram atualizado com sucesso!");
                        txtName.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        lblId.Text = "";
                        txtEndereco.Clear();
                        txtPesquisa.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Não foi possivel atualizar as informacões dos funcionarios");
                        txtName.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                        txtPesquisa.Focus();
                    }

                }
                else
                {
                    MessageBox.Show($"Por favor localize o funcionario que deseja atualizar as informacões");
                    txtName.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    lblId.Text = "";
                    txtPesquisa.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao atualizar dados do funcionarios {ex.Message}");
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

            try
            {

                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtName.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionarios = new CadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblId.Text);
                    if (cadFuncionarios.DeleteFuncionario())
                    {
                        MessageBox.Show($"Ofuncionario foi excluido com sucesso!");
                        txtCpf.Clear();
                        txtName.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                        lstPesquisa.Items.Clear();
                    }
                    else
                    {
                        MessageBox.Show($"Não foi possivel excluir o funcionarios");
                        txtCpf.Clear();
                        txtName.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        lblId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show($"Por favor pesquise um funcionario que deseja excluir");
                    txtCpf.Clear();
                    txtName.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    lblId.Text = "";
                    txtPesquisa.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir funcionario");

            }

        }

       
    }
}
