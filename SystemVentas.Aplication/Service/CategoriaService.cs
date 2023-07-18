using System;
using Microsoft.Extensions.Logging;
using SystemVentas.Application.Contract;
using SystemVentas.Application.Core;
using SystemVentas.Application.DTos.Categoria;
using SystemVentas.Application.Extention;
using SystemVentas.Application.Helpers;
using SystemVentas.Domain.Entities;
using SystemVentas.Infrastructure.Interfaces;

namespace SystemVentas.Application.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;
        private readonly ILogger<CategoriaService> logger;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                ILogger<CategoriaService> logger)
        {
            this.categoriaRepository = categoriaRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var cat = this.categoriaRepository.GetAllCategories();
                result.Data = cat;
                result.Message = "Categorías obtenidas exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorías";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var cat = this.categoriaRepository.GetCategoryById(id);
                result.Data = cat;
                result.Message = "Categoría obtenida exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetInactive()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var cat = this.categoriaRepository.GetCategoryByInactuve();
                result.Data = cat;
                result.Message = "Categoría inactivas obtenidas exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo categorías inactivas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(CategoriaAddDTo model)
        {
            ServiceResult result = CategoryValidationHelper.ValidateCategoryData(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var category = model.ConvertDtoAddToEntity();
                this.categoriaRepository.Add(category);

                result.Message = "Categoría agregado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(CategoriaUpdateDTo model)
        {
            ServiceResult result = CategoryValidationHelper.ValidateCategoryData(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var category = model.ConvertDtoUpdateToEntity();
                this.categoriaRepository.Update(category);

                result.Message = "Categoría actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(CategoriaRemoveDTo model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.categoriaRepository.Remove(new Categoria()
                {
                    IdCategoria = model.IdCategoria,
                    UserDelete = model.ChangeUser,
                    DateDelete = model.ChangeDate,
                    Deleted = model.Deleted
                });

                result.Message = "Categoría eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al intentar eliminar categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
