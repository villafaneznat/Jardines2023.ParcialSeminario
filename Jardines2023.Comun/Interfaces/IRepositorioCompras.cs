using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Comun.Interfaces
{
    public interface IRepositorioCompras
    {
        void Agregar(Compra compra);
        void Borrar(int compraId);
        void Editar(Compra compra);
        bool Existe(Compra compra);
        int GetCantidad();
        List<Compra> GetCompras();
        List<Compra> GetComprasPorPagina(int cantidad, int pagina);
    }
}
