using SystemVentas.Domain.Entities;
using SystemVentas.Infrastructure.Models;

namespace SystemVentas.Infrastructure.Extentions
{
    public static class CategoriaExtention
    {
        public static CategoriaModels ConvertCategoryEntityToModel(this Categoria categoria)
        {
            CategoriaModels categoriaModels = new CategoriaModels()
            {
                Descripcion = categoria.Descripcion,
                Estado = categoria.Estado,
                FechaRegistro = categoria.FechaRegistro
            };

            return categoriaModels;
        }
    }
}
