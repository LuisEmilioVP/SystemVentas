using System.Collections.Generic;
using SystemVentas.Domain.Entities;
using SystemVentas.Domain.Repository;
using SystemVentas.Infrastructure.Models;

namespace SystemVentas.Infrastructure.Interfaces
{
    public interface ICategoriaRepository : IBaseRepositor<Categoria>
    {
        List<CategoriaModels> GetAllCategories();

        CategoriaModels GetCategoryById(int categoryId);

        List<CategoriaModels> GetCategoryByActive();

        List<CategoriaModels> GetCategoryByInactuve();
    }
}
