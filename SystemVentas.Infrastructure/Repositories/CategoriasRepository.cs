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
using SystemVentas.Infrastructure.Extentions;

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
                    .Where(ca => ca.Estado == true && !ca.Deleted)
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
                if (!base.Exists(ca => ca.IdCategoria == categoryId))
                    throw new DataNotFoundException(
                        "Categoría no encontrado en la base de datos");
                

                categoriaModels = base.GetEntity(categoryId).ConvertCategoryEntityToModel();
                this.logger.LogInformation($"Obteniendo una Categoría: {categoryId}");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Categoria {ex.Message}", ex.ToString());
                throw new DataExceptions("Categoría no existe...");
                throw new DatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return categoriaModels;
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

        public override void Add(Categoria entity)
        {
            try
            {
                if (this.Exists(ca => ca.Descripcion == entity.Descripcion))
                    throw new DataExceptions("¡La Categoría ya existe!");

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nueva Categoría insertada: {entity.Descripcion}");
            }
            catch (DataExceptions dex)
            {
                this.logger.LogError($"Error al agregar Categoría: {dex.Message}", dex.ToString());
                throw;
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al cargar Categoría {ex.Message}", ex.ToString());
                throw new DatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }
        }

        public override void Update(Categoria entity)
        {
            try
            {
                Categoria categoriaToUpdate = this.GetEntity(entity.IdCategoria)
                    ?? throw new DataNotFoundException(
                        "Categoría no encontrada en la base de datos");

                categoriaToUpdate.IdCategoria = entity.IdCategoria;
                categoriaToUpdate.Descripcion = entity.Descripcion;
                categoriaToUpdate.Estado = entity.Estado;
                categoriaToUpdate.FechaRegistro = entity.FechaRegistro;
                categoriaToUpdate.UserModify = entity.UserModify;
                categoriaToUpdate.DateModify = entity.DateModify;

                this.context.Categoria.Update(categoriaToUpdate);
                this.SaveChanges();
                this.logger.LogInformation("Actualización de Categoría exitosa.");
            }
            catch (DataExceptions dex)
            {
                this.logger.LogError($"Error al actualizar Categoría: {dex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar Categoría: {ex.Message}", ex.ToString());
                throw new DatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }
        }

        public override void Remove(Categoria entity)
        {
            try
            {
                Categoria categoriaToRemove = this.GetEntity(entity.IdCategoria)
                 ?? throw new DataNotFoundException(
                     "Categoría no encontrada en la base de datos");

                categoriaToRemove.IdCategoria = entity.IdCategoria;
                categoriaToRemove.UserDelete = entity.UserDelete;
                categoriaToRemove.DateDelete = entity.DateDelete;
                categoriaToRemove.Deleted = entity.Deleted;

                this.context.Update(categoriaToRemove);
                this.SaveChanges();
                this.logger.LogInformation("Eliminación de categoría exitosa.");
            }
            catch (DataExceptions dex)
            {
                this.logger.LogError($"Error al eliminar categoría: {dex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al eliminar categoría: {ex.Message}", ex.ToString());
                throw new DatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }
    }
}
