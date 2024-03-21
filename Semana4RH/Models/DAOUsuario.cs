using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;


namespace Semana4RH.Models
{
    public class DAOUsuario
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DAOUsuario() {
            // ----------------------------Sourse ----------------------------------------------------------------------
            this.con.ConnectionString = @"Data Source = MAKIMA\SQLEXPRESSR; initial catalog=temporal; integrated security=true";
            //----------------------------------------------------------------------------------------------------------

        }

        public List<Usuarios> GetTabla()
        {
            List<Usuarios> data = new List<Usuarios>();
            cmd.Connection = con;
            cmd.CommandText = "select * from usuarios";
            cmd.Connection.Open();
            SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                data.Add(new Usuarios(
                    int.Parse(lector[0].ToString()),
                    lector[1].ToString(),
                    lector[2].ToString(),
                    lector[3].ToString()));
            }
            cmd.Connection.Close();
            lector.Close();
            return data;
        }

        public bool insertar(Usuarios u)
        {
            string sql = "insert into usuarios values("+u.userid+",'"+u.username+"','"+u.pass+"','"+u.nivel+"')";
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();

            if (r == 1) 
            { 
                return true;

            }
            else 
            {
                return false;
            }
        }
        //------------------ Actualizar y eliminar  ------------------------
        public bool actualizar(Usuarios u)
        {
            string sql = "UPDATE Usuarios SET username='" + u.username + "', pass='" + u.pass + "', nivel='" + u.nivel + "' WHERE userid=" + u.userid;
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }
        public bool eliminar(int userId)
        {
            string sql = "DELETE FROM Usuarios WHERE userid=" + userId;
            cmd.Connection = this.con;
            cmd.CommandText = sql;
            cmd.Connection.Open();
            int r = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return r == 1;
        }



    }
}