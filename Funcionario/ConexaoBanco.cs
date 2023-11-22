using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionario
{
    static class ConexaoBanco
    {
        //4 variaveis declaradas passando as informações do banco de dados
        private const string servidor = "localhost";
        private const string bancoDados = "dbFuncionarios";
        private const string usuario = "root";
        private const string senha = "Epilefipp.9150";

        //declarando variavel conexaoBanco para fazer a conexao com o banco de dados
        static public string bancoServidor = $"server={servidor}; user id ={usuario}; database={bancoDados}; password={senha}";
    }
}
