﻿using System;
using System.Collections.Generic;
using Product.Data.Entities;

namespace Product.Data.Repositories
{
    public interface IMaterialRepository
    {
        Material GetById(Int32 id);
        IList<Material> GetAll();
        void Update(Int32 id, String name, Decimal cost);
        void Delete(Int32 id);
        IList<Material> GetAllExceptThisID(int id);
        void Merge(Int32 materialIdToKeep, Int32 materialIdToDelete);
    }
}