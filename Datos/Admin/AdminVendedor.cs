using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Datos.Admin
{
    public class AdminVendedor
    {
        public static List<Vendedor> Listar()
        {
            //una variable con la consulta de SQL
            string consultaSQL = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor";

            //Crear un objeto SqlCommand
            SqlCommand comando = new SqlCommand(consultaSQL, AdminDB.ConetarDB());

            //declarar un objeto SqlDataReader
            SqlDataReader reader;

            //crear el reader
            reader = comando.ExecuteReader();

            //Recorrer leer los datos hacia adelante
            List<Vendedor> lista = new List<Vendedor>();

            while (reader.Read())
            {
                lista.Add(
                    new Vendedor(
                        (int)reader["Id"],
                        reader["Nombre"].ToString(),
                        reader["Apellido"].ToString(),
                        reader["DNI"].ToString(),
                        (decimal)reader["Comision"]
                        )
                    );
            }
            AdminDB.ConetarDB().Close();//cerramos la conexión
            reader.Close();
            return lista;

        }
        public static DataTable TraerPorID(int id)
        {
            // query
            string consultaSQL = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor WHERE Id=@Id";

            // declarar y crear un SQLDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminDB.ConetarDB());

            // declarar parámetros
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            // declarar y crear un DataSet
            DataSet dataSet = new DataSet();

            // invocar al método Fill --> conecta a la base, ejecuta el SELECT, crea el DataTable y se desconecta
            adapter.Fill(dataSet, "Id");

            // devolver la tabla por índice o nombre (recomendado)
            return dataSet.Tables["Id"];
        }
        public static int Insertar(Vendedor vendedor)
        {
            string insertSql = "INSERT into dbo.Vendedor (Nombre, Apellido, DNI, Comision) VALUES (@Nombre, @Apellido, @DNI, @Comision)";

            SqlCommand command = new SqlCommand(insertSql, AdminDB.ConetarDB());
            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;//SET del UPDATE
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;//SET del UPDATE
            command.Parameters.Add("@DNI", SqlDbType.Char,11).Value = vendedor.DNI;//SET del UPDATE

            command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;//SET del UPDATE

            int filasAfectadas = command.ExecuteNonQuery();

            return filasAfectadas;
        }
        public static DataTable TraerPorComision(decimal comision)
        {
            // query
            string consultaSQL = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor WHERE Comision=@Comision";

            // declarar y crear un SQLDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminDB.ConetarDB());

            // declarar parámetros
            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Decimal).Value = comision;

            // declarar y crear un DataSet
            DataSet dataSet = new DataSet();

            // invocar al método Fill --> conecta a la base, ejecuta el SELECT, crea el DataTable y se desconecta
            adapter.Fill(dataSet, "Comision");

            // devolver la tabla por índice o nombre (recomendado)
            return dataSet.Tables["Comision"];
        }
        public static int Eliminar(int id)
        {
            string insertSQL = "DELETE FROM dbo.Vendedor WHERE Id=@Id";

            SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConetarDB());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConetarDB().Close();
            return filasAfectadas;
        }
        public static int Modificar(Vendedor vendedor)
        {
            string insertSQL = "UPDATE dbo.Vendedor SET Nombre=@Nombre,Apellido=@Apellido, DNI=@DNI, Comision=@Comision WHERE Id=@Id ";

            SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConetarDB());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;//SET del UPDATE
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;//SET del UPDATE
            command.Parameters.Add("@DNI", SqlDbType.Char,11).Value = vendedor.DNI;//SET del UPDATE

            command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;//SET del UPDATE
            command.Parameters.Add("@Id", SqlDbType.Int).Value = vendedor.Id;//en where de la consulta SQL

            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConetarDB().Close();
            return filasAfectadas;
        }

    }
}
