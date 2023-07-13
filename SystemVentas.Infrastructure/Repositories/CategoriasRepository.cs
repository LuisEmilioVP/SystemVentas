using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SystemVentas.Domain.Entities;
using SystemVentas.Infrastructure.Context;
using SystemVentas.Infrastructure.Core;
using SystemVentas.Infrastructure.Interfaces;
using SystemVentas.Infrastructure.Models;
using SystemVentas.Infrastructure.Exceptions;

namespace SystemVentas.Infrastructure.Repositories
{
    public class CategoriasRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly ILogger<CategoriasRepository> logger;
        private readonly SystemVentasContext context;

        public CategoriasRepository(ILogger<CategoriasRepository> logger, 
            SystemVentasContext systemVentas) : base(systemVentas)
        {
            this.logger = logger;
            this.context = systemVentas;
        }

        public List<CategoriaModels> GetAllCategories()
        {
            List<CategoriaModels> categorias = new List<CategoriaModels>();
            try
            {
                this.logger.LogInformation("Obteniendo categorías…");
                categorias = this.context.Categoria
                    .Where(ca => !ca.Deleted)
                    .Select(ca => new CategoriaModels()
                    {
                        Descripcion = ca.Descripcion,
                        Estado = ca.Estado,
                        FechaRegistro = ca.FechaRegistro
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar las categorías {ex.Message}", ex.ToString());
                throw new DatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return categorias;
        }

        public CategoriaModels GetCategoryById(int categoryId)
        {
            CategoriaModels categoriaModels = new CategoriaModels();
            try
            {
                this.logger.LogInformation("Obteniendo categoría…");
                Categoria categoria = this.GetEntity(categoryId);

                categoriaModels.Descripcion = categoria.Descripcion;
                categoriaModels.Estado = categoria.Estado;
                categoriaModels.FechaRegistro = categoria.FechaRegistro;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Categoria {ex.Message}", ex.ToString());
                throw new DatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return categoriaModels;
        }

        public List<CategoriaModels> GetCategoryByActive()
        {
            List<CategoriaModels> activeCategory = new List<CategoriaModels>();
            try
            {
                this.logger.LogInformation("Obteniendo categorías activas…");
                activeCategory = this.context.Categoria
                    .Where(ca => ca.Estado == true && !ca.Deleted)
                    .Select(c => new CategoriaModels()
                    {
                        Descripcion = c.Descripcion,
                        Estado = c.Estado,
                        FechaRegistro = c.FechaRegistro
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar las categorías activas {ex.Message}", ex.ToString());
                throw new DatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return activeCategory;
        }

        public List<CategoriaModels> GetCategoryByInactuve()
        {
            List<CategoriaModels> inactiveCategory = new List<CategoriaModels>();
            try
            {
                this.logger.LogInformation("Obteniendo categorías inactivas…");
                inactiveCategory = this.context.Categoria
                    .Where(ca => ca.Estado == false && !ca.Deleted)
                    .Select(c => new CategoriaModels()
                    {
                        Descripcion = c.Descripcion,
                        Estado = c.Estado,
                        FechaRegistro = c.FechaRegistro
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar las categorías inactivas {ex.Message}", ex.ToString());
                throw new DatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return inactiveCategory;
        }
    }
}
