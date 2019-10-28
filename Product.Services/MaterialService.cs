using System;
using System.Collections.Generic;
using System.Linq;
using Product.Data.Repositories;
using Product.DomainObjects.Models;

namespace Product.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public MaterialModel GetById(Int32 id)
        {
            return Transfer(_materialRepository.GetById(id));
        }

        public IList<MaterialModel> GetAll()
        {
            return _materialRepository.GetAll().Select(Transfer).ToList();
        }

        public IList<MaterialModel> GetAllExceptThisID(Int32 id)
        {
            return _materialRepository.GetAllExceptThisID(id).Select(Transfer).ToList();
        }

        public void Merge(Int32 materialIdToKeep, Int32 materialIdToDelete)
        {
            _materialRepository.Merge(materialIdToKeep, materialIdToDelete);
        }

        private MaterialModel Transfer(Data.Entities.Material entity)
        {
            return new MaterialModel
            {
                MaterialId = entity.MaterialId,
                Name = entity.Name,
                Cost = entity.Cost
            };
        }

      
    }
}