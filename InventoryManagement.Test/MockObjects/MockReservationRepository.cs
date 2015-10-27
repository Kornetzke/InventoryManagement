using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.Model.DomainModels;

namespace InventoryManagement.Test.MockObjects
{
    public class MockReservationRepository : MockBaseRepository<Reservation>, IReservationRepository
    {

        public MockReservationRepository() : base(TestData.GetReservationList()) { }

        public MockReservationRepository(List<Reservation> reservationList)
            : base(reservationList) { }

        public override void Add(Reservation entity)
        {
            entity.ID = entityList.Max(r => r.ID) + 1;
            entityList.Add(new Reservation()
            {
                ID = entity.ID,
                CustomerNameFirst = entity.CustomerNameFirst,
                CustomerNameLast = entity.CustomerNameLast,
                CustomerEmail = entity.CustomerEmail,
                CustomerPhone = entity.CustomerPhone,
                InventoryID = entity.InventoryID,
                CreationDate = entity.CreationDate,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                StudentOrg = entity.StudentOrg,
                Comment = entity.Comment,
                ConferenceGroup = entity.ConferenceGroup

            });
        }

        public override void Update(Reservation entity)
        {
            Reservation r = entityList.Find(e => e.ID == entity.ID);
            if (r != null)
            {
                r.CustomerNameFirst = entity.CustomerNameFirst;
                r.CustomerNameLast = entity.CustomerNameLast;
                r.CustomerEmail = entity.CustomerEmail;
                r.CustomerPhone = entity.CustomerPhone;
                r.InventoryID = entity.InventoryID;
                r.CreationDate = entity.CreationDate;
                r.StartDate = entity.StartDate;
                r.EndDate = entity.EndDate;
                r.StudentOrg = entity.StudentOrg;
                r.Comment = entity.Comment;
                r.ConferenceGroup = entity.ConferenceGroup;
            }
        }


        public override Reservation GetById(int id)
        {
            return entityList.FirstOrDefault(r => r.ID == id);
        }
    }
}
