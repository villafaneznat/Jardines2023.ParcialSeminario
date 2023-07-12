using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioCompras : IRepositorioCompras
    {

        private readonly string cadenaDeConexion;
        public RepositorioCompras()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Compra compra)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int compraId)
        {
            throw new NotImplementedException();
        }

        public void Editar(Compra compra)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Compra compra)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                int cantidad = 0;
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Compras";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return cantidad;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Compra> GetCompras()
        {
            throw new NotImplementedException();
        }

        public List<Compra> GetComprasPorPagina(int cantidad, int pagina)
        {
            List<Compra> lista = new List<Compra>();
            try
            {
                using (var conn = new SqlConnection(cadenaDeConexion))
                {
                    conn.Open();
                    string selectQuery = @"SELECT c.CompraId, c.FechaCompra, p.NombreProveedor, c.Total
                        FROM Compras c INNER JOIN Proveedores p ON c.ProveedorId = p.ProveedorId
                        ORDER BY CompraId
                        OFFSET @cantidadRegistros ROWS 
                        FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        comando.Parameters.Add("@cantidadRegistros", SqlDbType.Int);
                        comando.Parameters["@cantidadRegistros"].Value = cantidad * (pagina - 1);

                        comando.Parameters.Add("@cantidadPorPagina", SqlDbType.Int);
                        comando.Parameters["@cantidadPorPagina"].Value = cantidad;
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var cliente = ConstruirCompra(reader);
                                lista.Add(cliente);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Compra ConstruirCompra(SqlDataReader reader)
        {
            return new Compra()
            {
                CompraId = reader.GetInt32(0),
                FechaCompra = reader.GetDateTime(1),
                NombreProveedor = reader.GetString(2),
                Total = reader.GetDecimal(3)
            };
        }
    }
}
