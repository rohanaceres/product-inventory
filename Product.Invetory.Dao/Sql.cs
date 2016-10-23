using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Product.Invetory.Dao
{
    public class Sql
    {
        //static string strCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProductInventoryDB.mdf;Integrated Security=True";

        //SqlConnection connection = new SqlConnection(strCon);




        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();
        //    // Do work here; connection closed on following line.
        //}
        //private static void CreateCommand(string queryString,string connectionString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}


        //string strcon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Documents and Settings\\k\\Meus documentos\\banco_dados.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        //        SqlConnection conexao = new SqlConnection(strcon); /* conexao irá conectar o C# ao banco de dados */
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM tabela", conexao); /*cmd possui mais de um parâmetro, neste caso coloquei o comando SQL "SELECT * FROM tabela" que irá selecionar tudo(*) de tabela, o segundo parâmetro indica onde o banco está conectado,ou seja se estamos selecionando informações do banco precisamos dizer onde ele está localizado */
        //        Try //Tenta executar o que estiver abaixo
        //            {                                                                                                                  
        //                conexao.Open(); // abre a conexão com o banco   
        //                cmd.ExecuteNonQuery(); // executa cmd
        ///*Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, agora os passos seguintes irão exibir as informações para que o usuário possa vê-las    */                                                   SqlDataAdapter da = new SqlDataAdapter(); /* da, adapta o banco de dados ao nosso projeto */
        //        DataSet ds = new DataSet();
        //        da.SelectCommand = cmd; // adapta cmd ao projeto
        //                da.Fill(ds); // preenche todas as informações dentro do DataSet                                          
        //                dataGridView1.DataSource = ds; //Datagridview recebe ds já preenchido
        //                dataGridView1.DataMember = ds.Tables[0].TableName;  /*Agora Datagridview exibe o banco de dados*/               
        //            }
        //            catch (Exception ex)
        //            {                 
        //                MessageBox.Show("Erro "+ex.Message); /*Se ocorer algum erro será informado em um msgbox*/
        //                throw;      
        //            }

        //            finally
        //            {         
        //               conexao.Close(); /* Se tudo ocorrer bem fecha a conexão com o banco da dados, sempre é bom fechar a conexão após executar até o final o que nos interessa, isso pode evitar problemas futuros */
        //            }
    }
}
