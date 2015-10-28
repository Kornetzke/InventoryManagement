﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.Service;
using InventoryManagement.Test.MockObjects;

namespace InventoryManagement.Test.ServiceTests
{
    [TestFixture]
    class ReservationServiceTest
    {

        IReservationService reservationService;
        IEquipmentRepository equipmentRepository;
        IInventoryRepository inventoryRepository;
        IReservationRepository reservationRepository;
        IUnitOfWork unitOfWork;

        List<Reservation> reservationList;
        List<Equipment> equipmentList;
        List<Inventory> inventoryList;

        [SetUp]
        public void Setup()
        {
            reservationList = TestData.GetReservationList();
            equipmentList = TestData.GetEquipmentList();
            inventoryList = TestData.GetInventoryList();

            unitOfWork = new MockUnitOfWork();
            reservationRepository = new MockReservationRepository(reservationList);
            equipmentRepository = new MockEquipmentRepository(equipmentList);
            inventoryRepository = new MockInventoryRepository(inventoryList);

            reservationService = new ReservationService(reservationRepository, equipmentRepository, inventoryRepository, unitOfWork);
        }


        [Test]
        public void ServiceShouldReturnReservationWithMatchingID()
        {
            int ID = 2;
            Reservation res = reservationService.GetByID(ID);
            Assert.That(res.ID, Is.EqualTo(ID));
            Assert.That(res, Is.EqualTo(reservationRepository.GetById(ID)));
        }

        [Test]
        public void ServiceShouldReturnAllReservations()
        {
            var resList = reservationService.GetAll();

            Assert.That(resList, Is.EquivalentTo(reservationList));
        }


        [Test]
        public void ServiceShouldValidateReservations()
        {
            Assert.That(reservationService.Validate(null).IsValid(), Is.EqualTo(false),"Null Reservation Failed");

            Reservation res = new Reservation();
            Assert.That(reservationService.Validate(res).IsValid(), Is.EqualTo(false),"Reservation with Null values");

            res.InventoryID = 1;
            res.CustomerNameFirst = res.CustomerNameLast = "name";
            res.CustomerNameFirst = "newName";
            res.CustomerEmail = "Email@eamil.com";
            res.CustomerPhone = "6086585015";
            res.CreationDate = DateTime.Now;
            res.StartDate = DateTime.Now;
            res.EndDate = DateTime.Now.AddHours(1);

            Assert.That(reservationService.Validate(res).IsValid(), Is.EqualTo(true), "Reservation with required values");

            // Add required business properties    
            //Assert.Fail("Not Complete");        
        }

        [Test]
        public void ServiceShouldDeleteReservationFromRepository()
        {

            Reservation res = reservationService.GetByID(2);
            Assert.That(res, Is.Not.Null);

            reservationService.Delete(res);

            Assert.That(reservationService.GetByID(2), Is.Null);
            Assert.That(reservationRepository.GetById(2), Is.Null);
        }

        [Test]
        public void ServiceShouldDeleteReservationWhere()
        {
            reservationService.DeleteWhere(r => true);
            Assert.That(reservationService.GetAll().Count(), Is.EqualTo(0));
        }

        [Test]
        public void ServiceShouldReturnConflictingReservations()
        {
            List<Reservation> rList = reservationRepository.GetAll() as List<Reservation>;

            for (int i = rList.Count - 1; i >= 0; i--)
            {
                reservationRepository.Delete(rList[i]);
            }

            Assert.That(reservationService.GetAll().Count, Is.EqualTo(0));

            int InventoryID = 1;
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddHours(1);


            reservationService.GetConflictingReservations(InventoryID, startTime, endTime);
            //Assert.Fail("Not Complete");
        }

    }
}
