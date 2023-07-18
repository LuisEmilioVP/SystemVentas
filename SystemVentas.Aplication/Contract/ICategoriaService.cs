using SystemVentas.Application.Core;
using SystemVentas.Application.DTos.Categoria;

namespace SystemVentas.Application.Contract
{
    public interface ICategoriaService : IBaseService<CategoriaAddDTo,
                                                       CategoriaUpdateDTo,
                                                       CategoriaRemoveDTo>
    {
    }
}
