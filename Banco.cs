using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AulaWebForms
{
    public class Banco
    {
        private string conec = "Data Source=localhost; Initial Catalog=desafio1; User ID=usuario; password=senha;language=Portuguese";

        private SqlConnection cn;

        private void conexao()
        {
            cn = new SqlConnection(conec);
        }

        public SqlConnection abrirconexao()
        {
            try
            {
                conexao();
                cn.Open();

                return cn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void fecharconexao()
        {
            try
            {
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public DataTable executarConsultaGenerica(string sql)
        {
            conexao();
            abrirconexao();

            try
            {
                SqlCommand sqlComm = new SqlCommand(sql, cn);
                sqlComm.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fecharconexao();
            }
        }
    }
}