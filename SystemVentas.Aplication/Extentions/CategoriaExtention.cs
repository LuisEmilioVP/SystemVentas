using SystemVentas.Application.DTos.Categoria;
using SystemVentas.Domain.Entities;

namespace SystemVentas.Application.Extention
{
    public static class CategoriaExtention
    {
       public static Categoria ConvertDtoAddToEntity (this CategoriaAddDTo categoriaAddDTo)
        {
            return new Categoria()
            {
                Descripcion = categoriaAddDTo.Descripcion,
                Estado = categoriaAddDTo.State,
                FechaRegistro = categoriaAddDTo.RegisterDateAndTime,
                UserCreation = categoriaAddDTo.ChangeUser,
                DateCreation = categoriaAddDTo.ChangeDate
            };
        }

        public static Categoria ConvertDtoUpdateToEntity (this CategoriaUpdateDTo categoriaUpdateDTo)
        {
            return new Categoria()
            {
                IdCategoria = categoriaUpdateDTo.IdCategoria,
                Descripcion = categoriaUpdateDTo.Descripcion,
                Estado = categoriaUpdateDTo.State,
                FechaRegistro = categoriaUpdateDTo.RegisterDateAndTime,
                UserModify = categoriaUpdateDTo.ChangeUser,
                DateModify = categoriaUpdateDTo.ChangeDate
            };
        }
    }
}
