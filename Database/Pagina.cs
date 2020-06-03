using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace Database
{
    public class Pagina
    {
        private string sqlconn()
        {
           return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlconn()))
            {
                string queryString = "select * from paginas";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar( int id ,string nome, string conteudo, DateTime data)
        {
            
            using (SqlConnection connection = new SqlConnection(sqlconn()))
            {
                string queryString = "insert into paginas (nome, data, conteudo) values('"+nome+"','"+ DateTime.Parse(data.ToString("yyyy-MM-dd HH:mm:ss")) + "','"+conteudo+"')";

                if (id != 0)
                {
                    queryString = "update paginas  set nome ='" + nome + "',data='" + DateTime.Parse(data.ToString("yyyy-MM-dd HH:mm:ss")) + "',conteudo='" + conteudo + "'where id="+id;
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public  void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn()))
            {
                string queryString = "DELETE FROM paginas WHERE id = "+id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn()))
            {
                string queryString = "select * from paginas where id= " +id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
