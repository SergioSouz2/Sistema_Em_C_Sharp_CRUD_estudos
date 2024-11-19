using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funcionarios
{
    internal class CadastroFuncionarios
    {
        private int id;
        private string nome;
        private string email;
        private string cpf;
        private string endereco;
        private string pesquisa;


        public int Id 
        {
            get { return id; } 
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        
        public string Cpf { 
            get { return cpf; }
            set { cpf = value; }
        }

        public string Endereco { 
            get { return endereco; }
            set { endereco = value; }
        }

        public string Pesquisa
        {
            get { return pesquisa; }
            set { pesquisa = value; }
        }    


        // metado para cadastrar funcionario no banco de dados.
        public bool CadastrarFuncionarios() {
            try
            {
                //conexao com o banco 
                MySqlConnection MysqlConexaoBanco = new MySqlConnection( ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string insert = $"insert into funcionarios (nome,email,cpf,endereco) values ('{Nome}','{Email}','{Cpf}','{Endereco}')";
                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();

                comandoSql.CommandText = insert;
                comandoSql.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex )
            {
                MessageBox.Show($"Erro no banco de dados - metodo cadastroFuncionario: {ex.Message}");
                return false;
            }
        
        }

        // metado para pesquisar funcionario no banco de dados.
        public MySqlDataReader LocalizarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();


                string select = $"select id, nome, email, cpf, endereco from funcionarios where cpf='{pesquisa}';";
                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();

                comandoSql.CommandText = select;
                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro no banco - metodo localizarFuncionarios {ex.Message}");
                return null;
            }
        }

        // metado para atualizar dados do funcionario no banco de dados.
        public bool AtualizarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string update = $"update funcionarios set email = '{Email}', endereco =  '{Endereco}' where id = '{Id}';";
                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = update;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error no banco de dados - metado atualizarFuncionario {ex.Message}");
                return false;
            }
        }

        // metado para apagar os dados do funcionario no banco de dados.
        public bool DeleteFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string delete = $"delete from funcionarios where id = '{Id}';";
                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = delete;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro banco de dados - metado deleteFuncionario");
                return false;
            }
        }
    
    }


}
