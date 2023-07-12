using Jardines2023.Comun.Interfaces;
using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Servicios.Servicios
{
    public class ServicioCompras : IServicioCompras
    {
        private readonly IRepositorioCompras _repositorio;

        public ServicioCompras()
        {
            _repositorio = new RepositorioCompras();
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
                return _repositorio.GetCantidad();
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
           
            try
            {
                return _repositorio.GetComprasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
