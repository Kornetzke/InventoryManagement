namespace InventoryManagement.DAL.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using InventoryManagement.Model.DomainModels;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class InventoryManagementContext : DbContext
    {

        public InventoryManagementContext()
            : base("name=InventoryManagementContext")
        {
            Database.SetInitializer<InventoryManagementContext>(new DataBaseInitializer());
            //Configuration.ProxyCreationEnabled = false;
        }


        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<CheckIn> CheckedIns { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Status> Status { get; set; }


        internal void Commit()
        {
            var entries = this.ChangeTracker.Entries();
            Debug.WriteLine("Planned Changes");
            Debug.WriteLine("");
            foreach (var entry in entries)
            {
                Debug.WriteLine("Entity Name: "+ entry.Entity.GetType().FullName);
                Debug.WriteLine("State: {0}", entry.State);
            }
            Debug.WriteLine("");
            Debug.WriteLine("---------------------------------------");
            this.SaveChanges();
        }
    }

    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<InventoryManagementContext>
    {
        public override void InitializeDatabase(InventoryManagementContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(InventoryManagementContext context)
        {
            context.Status.Add(new Status()
            {
                ID = 1,
                Description = "Okay",
                IsDisabling = false
            });

            context.Status.Add(new Status()
            {
                ID = 2,
                Description = "Broken",
                IsDisabling = true
            });
            context.Commit();

            context.Equipments.Add(new Equipment()
            {
                ID = 1,
                Name = "TestEquipment",
                Description = "TestDes",
                Cost = 1.1m,
            });
            context.Commit();

            context.Inventory.Add(new Inventory()
            {
                ID = 1,
                Status = context.Status.First(),
                Equipment = context.Equipments.First()
            });
            context.Commit();
            context.Groups.Add(new Group()
            {
                ID = 1,
                Name = "TestGroup",
                Sequence = 1,
                Page = 1,
                Description = "TestGroupDesc",
                IsDisplayable = true,
                Equipments = context.Equipments.ToList()
            });
            context.Commit();
            context.Properties.Add(new Property()
            {
                ID = 1,
                PropertyText = "Is this Test",
                Value = "Yes",
                Inventories = context.Inventory.ToList()

            });
            context.Commit();

            context.Reservations.Add(new Reservation()
            {
                ID = 1,
                CustomerNameFirst = "CustomerFirst",
                CustomerNameLast = "CustomerLast",
                CustomerEmail = "Customer@email.com",
                CustomerPhone = "6586559856",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(3),
                StudentOrg = "StudentOrg",
                ConferenceGroup = "ConferenceGroup",
                Comment = "Comment",
                CreationDate = DateTime.Now,
                Inventory = context.Inventory.First()
            });
            context.Commit();
            context.Reservations.Add(new Reservation()
            {
                ID = 2,
                CustomerNameFirst = "CustomerFirst",
                CustomerNameLast = "CustomerLast",
                CustomerEmail = "Customer@email.com",
                CustomerPhone = "6586559856",
                StartDate = DateTime.Now.AddHours(-3),
                EndDate = DateTime.Now,
                StudentOrg = "StudentOrg",
                ConferenceGroup = "ConferenceGroup",
                Comment = "CheckIn",
                CreationDate = DateTime.Now.AddHours(-3),
                Inventory = context.Inventory.First()
            });
            context.Commit();

            context.CheckedIns.Add(new CheckIn()
            {
                Reservation = context.Reservations.Where(r => r.Comment == "CheckIn").FirstOrDefault(),
                Comment = "All Good",
                OperatorEmplid = "3067083",
                CheckInDate = DateTime.Now.AddMinutes(-5)
            });
            context.Commit();
        }

    }
    public static class TestData
    {
        public static List<Status> GetStatusList()
        {
            List<Status> statusList = new List<Status>();

            statusList.Add(new Status() { ID = 1, Description = "Okay", IsDisabling = false });
            statusList.Add(new Status() { ID = 2, Description = "Broken", IsDisabling = true });
            statusList.Add(new Status() { ID = 3, Description = "Lost", IsDisabling = true });

            return statusList;
        }

        public static List<Equipment> GetEquipmentList()
        {
            List<Equipment> equipmentList = new List<Equipment>();

            equipmentList.Add(new Equipment() { ID = 1, Name = "Test Equipment 1", Description = "Test Equipment 1 Description", Cost = 1m });
            equipmentList.Add(new Equipment() { ID = 2, Name = "Test Equipment 2", Description = "Test Equipment 2 Description", Cost = 2m });
            equipmentList.Add(new Equipment() { ID = 3, Name = "Test Equipment 3", Description = "Test Equipment 3 Description", Cost = 3m });

            return equipmentList;
        }

        public static List<Inventory> GetInventoryList()
        {
            List<Inventory> inventoryList = new List<Inventory>();

            inventoryList.Add(new Inventory() { ID = 1, EquipmentID = 1, StatusID = 1, Equipment = GetEquipmentList().Where(e => e.ID == 1).FirstOrDefault(), Status = GetStatusList().Where(s => s.ID == 1).FirstOrDefault() });
            inventoryList.Add(new Inventory() { ID = 2, EquipmentID = 1, StatusID = 2, Equipment = GetEquipmentList().Where(e => e.ID == 1).FirstOrDefault(), Status = GetStatusList().Where(s => s.ID == 2).FirstOrDefault() });
            inventoryList.Add(new Inventory() { ID = 3, EquipmentID = 2, StatusID = 1, Equipment = GetEquipmentList().Where(e => e.ID == 2).FirstOrDefault(), Status = GetStatusList().Where(s => s.ID == 1).FirstOrDefault() });
            inventoryList.Add(new Inventory() { ID = 4, EquipmentID = 3, StatusID = 3, Equipment = GetEquipmentList().Where(e => e.ID == 3).FirstOrDefault(), Status = GetStatusList().Where(s => s.ID == 3).FirstOrDefault() });

            return inventoryList;
        }

        public static List<Reservation> GetReservationList()
        {
            List<Reservation> reservationList = new List<Reservation>();

            reservationList.Add(new Reservation() { ID = 1, CustomerNameFirst = "FName", CustomerNameLast = "LName", CustomerEmail = "Customer@email.com", CustomerPhone = "6589875462", CreationDate = DateTime.Now, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(1), InventoryID = 1, ConferenceGroup = "ConfGroup", StudentOrg = "StudORg", Comment = "OutTest", Inventory = GetInventoryList().Where(e => e.ID == 1).FirstOrDefault(), CheckIn = GetCheckInList().Where(c => c.ReservationID == 1).FirstOrDefault() });

            reservationList.Add(new Reservation() { ID = 2, CustomerNameFirst = "FName2", CustomerNameLast = "LName2", CustomerEmail = "Customer2@email.com", CustomerPhone = "6589875462", CreationDate = DateTime.Now.AddHours(-1.1), StartDate = DateTime.Now.AddHours(-1.1), EndDate = DateTime.Now.AddHours(-.1), InventoryID = 3, ConferenceGroup = "ConfGroup", StudentOrg = "StudORg", Comment = "OverDueTest", Inventory = GetInventoryList().Where(e => e.ID == 3).FirstOrDefault(), CheckIn = GetCheckInList().Where(c => c.ReservationID == 2).FirstOrDefault() });

            reservationList.Add(new Reservation() { ID = 3, CustomerNameFirst = "FName3", CustomerNameLast = "LName3", CustomerEmail = "Customer3@email.com", CustomerPhone = "6589875462", CreationDate = DateTime.Now.AddHours(-2), StartDate = DateTime.Now.AddHours(-2), EndDate = DateTime.Now.AddHours(-1), InventoryID = 1, ConferenceGroup = "ConfGroup", StudentOrg = "StudORg", Comment = "ReturnedTest", Inventory = GetInventoryList().Where(e => e.ID == 1).FirstOrDefault(), CheckIn = GetCheckInList().Where(c => c.ReservationID == 3).FirstOrDefault() });

            return reservationList;
        }

        public static List<CheckIn> GetCheckInList()
        {
            List<CheckIn> checkInList = new List<CheckIn>();

            checkInList.Add(new CheckIn()
            {
                ReservationID = 3,
                CheckInDate = DateTime.Now.AddHours(-1),
                OperatorEmplid = "6589785",
                Comment = "Comment"
                //,Reservation = GetReservationList().Where(r => r.ID == 3).FirstOrDefault() 
            });

            return checkInList;
        }
    }

}