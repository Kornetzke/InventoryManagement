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
    class MockInventoryRepository : MockBaseRepository<Inventory>, IInventoryRepository
    {

        public MockInventoryRepository() : base(TestData.GetInventoryList()) { }

        public MockInventoryRepository(List<Inventory> inventoryList) : base(inventoryList) { }

        public override Inventory GetById(int id)
        {
            return entityList.FirstOrDefault(i => i.ID == id);
        }

        public override void Add(Inventory entity)
        {
            entity.ID = entityList.Max(e => e.ID) + 1;
            entityList.Add(new Inventory()
            {
                ID = entity.ID,
                EquipmentID = entity.EquipmentID,
                StatusID = entity.StatusID
            });
        }

        public override void Update(Inventory entity)
        {
            Inventory i = entityList.FirstOrDefault(e => e.ID == entity.ID);

            if (i != null)
            {
                i.EquipmentID = entity.EquipmentID;
                i.StatusID = entity.StatusID;
            }

        }


    }
}
