using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.DAL.Infrastructure;

namespace InventoryManagement.Test.MockObjects
{
    class MockEquipmentRepository : MockBaseRepository<Equipment>, IEquipmentRepository
    {

        public MockEquipmentRepository() : base(TestData.GetEquipmentList()) { }

        public MockEquipmentRepository(List<Equipment> equipmentList) : base(equipmentList) { }

        public override Equipment GetById(int id)
        {
            return entityList.FirstOrDefault(e => e.ID == id);
        }

        public override void Add(Equipment entity)
        {
            entity.ID = entityList.Max(e => e.ID) + 1;
            entityList.Add(new Equipment()
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                Cost = entity.Cost
            });
        }

        public override void Update(Equipment entity)
        {
            Equipment eq = entityList.FirstOrDefault(e => e.ID == entity.ID);

            if (eq != null)
            {
                eq.Name = entity.Name;
                eq.Description = entity.Description;
                eq.Cost = entity.Cost;
            }

        }


    }
}
