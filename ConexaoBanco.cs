using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios
{
    static class ConexaoBanco
    {
        
        private const string servidor = "localhost";
        private const string banco_dados = "dbfuncionarios";
        private const string user_id = "root";
        private const string password = "mysql";

        static public string bancoServidor = $"server={servidor};user id={user_id};database={banco_dados};password={password}";
        
         
    }
}
