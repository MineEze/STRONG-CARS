using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    internal class Acceso
    {
        readonly SqlConnection Conexion = new SqlConnection();

        private SqlTransaction Transaccion; 

        public void Abrir()
        {
            Conexion.ConnectionString = ConfigurationManager.ConnectionStrings["StrongCars"].ConnectionString;
            Conexion.Open();
        }

        public void Cerrar()
        {
            Conexion.Close();
        }

        public void IniciarTransaccion()
        {
            Transaccion = Conexion.BeginTransaction();
        }

        public void Commit()
        {
            Transaccion.Commit();
            Transaccion = null;
        }

        public void Rollback()
        {
            Transaccion.Rollback();
            Transaccion = null;
        }

        public DataTable Leer(string nombre, SqlParameter[] parameters = null)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();

            var comando = CrearComandoStoreProcedure(nombre, parameters);
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();

            adaptador.Fill(tabla);

            comando.Parameters.Clear();

            return tabla;
        }

        public void Escribir(string nombre, SqlParameter[] parameters)
        {
            SqlCommand comando = CrearComandoStoreProcedure(nombre, parameters);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            comando.Dispose();
        }

        public int LeerEscalar(string query, SqlParameter[] parametros = null)
        {
            SqlCommand cmd = CrearComandoStoreProcedure(query, parametros);

            var resultado = Convert.ToInt32(cmd.ExecuteScalar());

            return resultado;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            return new SqlParameter
            {
                ParameterName = nombre,
                Value = valor,
                DbType = DbType.String
            };
        }

        public SqlParameter CrearParametro(string nombre, DateTime valor)
        {
            return new SqlParameter
            {
                ParameterName = nombre,
                Value = valor,
                DbType = DbType.DateTime
            };
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            return new SqlParameter
            {
                ParameterName = nombre,
                Value = valor,
                DbType = DbType.Int32
            };
        }

        public SqlParameter CrearParametro(string nombre, float valor)
        {
            return new SqlParameter
            {
                ParameterName = nombre,
                Value = valor,
                DbType = DbType.Single
            };
        }

        public SqlParameter CrearParametroDeSalida(string nombre)
        {
            return new SqlParameter
            {
                ParameterName = nombre,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };
        }

        private SqlCommand CrearComandoStoreProcedure(string nombre, SqlParameter[] parametros = null)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = nombre;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = Conexion;

            if (Transaccion != null)
            {
                comando.Transaction = Transaccion;
            }

            if (parametros != null && parametros.Any())
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }

            return comando;
        }

        private SqlCommand CrearComando(string nombre, SqlParameter[] Parametros = null)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = nombre
            };

            if (Parametros != null)
            {
                cmd.Parameters.AddRange(Parametros);
            }

            if (Transaccion != null)
            {
                cmd.Transaction = Transaccion;
            }

            cmd.Connection = Conexion;
            return cmd;
        }
    }
}
