using ATQ1MR_HFT_2021221.Logic.Services;
using ATQ1MR_HFT_2021221.Models.Entities;
using ATQ1MR_HFT_2021221.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATQ1MR_HFT_2021221.Test
{
    [TestFixture]
    public class MotherboardLogicTests
    {
        [Test]
        public void CreateTestWithProperData()
        {
            //Arrange
            var motherboardRepo = new Mock<IMotherboardRepository>();

            var mboard1 = new Motherboard() { Id = 1, Chipset = "B450", Price = 30000, Socket = "AM4", Type = "TOMAHAWK MAX" };

            motherboardRepo.Setup(x => x.Create(It.IsAny<Motherboard>())).Returns(mboard1);

            var logic = new MotherboardLogic(null, motherboardRepo.Object, null);
            //Act
            var result = logic.Create(mboard1);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(mboard1));
        }
        [Test]
        public void CreateTestWithNull()
        {
            //Arrange
            var motherboardRepo = new Mock<IMotherboardRepository>();

            motherboardRepo.Setup(x => x.Create(null)).Throws<Exception>();

            var logic = new MotherboardLogic(null, motherboardRepo.Object, null);
            //Act
            var result = Assert.Throws(typeof(Exception), () => logic.Create(null));
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("Must contain the required data!"));
        }

        [Test]
        public void CreateTestWithEmptyString()
        {
            //Arrange
            var motherboardRepo = new Mock<IMotherboardRepository>();

            var mboard1 = new Motherboard() { Id = 2, Price = 1050, Socket="", Chipset = "testset", Type = "asd" };
            var mboard2 = new Motherboard() { Id = 2, Price = 1050, Socket="testsocket", Chipset = "", Type = "asd" };
            var mboard3 = new Motherboard() { Id = 2, Price = 1050, Socket="testsocket", Chipset = "testset", Type = "" };

            motherboardRepo.Setup(x => x.Create(It.Is<Motherboard>(x => x.Socket == ""))).Throws<Exception>();
            motherboardRepo.Setup(x => x.Create(It.Is<Motherboard>(x => x.Chipset == ""))).Throws<Exception>();
            motherboardRepo.Setup(x => x.Create(It.Is<Motherboard>(x => x.Type == ""))).Throws<Exception>();

            var logic = new MotherboardLogic(null, motherboardRepo.Object, null);
            //Act
            var result1 = Assert.Throws(typeof(Exception), () => logic.Create(mboard1));
            var result2 = Assert.Throws(typeof(Exception), () => logic.Create(mboard2));
            var result3 = Assert.Throws(typeof(Exception), () => logic.Create(mboard3));
            //Assert
            Assert.That(result1, Is.Not.Null);
            Assert.That(result1.Message, Is.EqualTo("Must contain the required data!"));
            Assert.That(result2, Is.Not.Null);
            Assert.That(result2.Message, Is.EqualTo("Must contain the required data!"));
            Assert.That(result3, Is.Not.Null);
            Assert.That(result3.Message, Is.EqualTo("Must contain the required data!"));
        }
        //[Test]
        //public void UpdateWithProperData()
        //{
        //    //Arrange
        //    var motherboardRepo = new Mock<IMotherboardRepository>();

        //    var mboard1 = new Motherboard() { Id = 1, Chipset = "B450", Price = 30000, Socket = "AM4", Type = "TOMAHAWK MAX" };
        //    var mboard2 = new Motherboard() { Id = 1, Chipset = "B450", Price = 3000, Socket = "AM4", Type = "TOMAHAWK MAX" };

        //    motherboardRepo.Setup(x => x.Update(It.IsAny<Motherboard>())).Returns(mboard1);
        //    //motherboardRepo.Setup(x => x.Create(It.IsAny<Motherboard>())).Returns(mboard2);
        //    //motherboardRepo.SetupProperty<Motherboard>(x => x.Create(mboard2),mboard2);

        //    var logic = new MotherboardLogic(null, motherboardRepo.Object, null);
        //    //var create = logic.Create(mboard2);
        //    //Act
        //    var result = logic.Update(mboard1);
        //    //Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.EqualTo(mboard1));
        //}
        [Test]
        public void UpdateTestWithNonExistetData()
        {
            //Arrange
            var motherboardRepo = new Mock<IMotherboardRepository>();

            var mboard1 = new Motherboard() { Id = 1, Chipset = "B450", Price = 30000, Socket = "AM4", Type = "TOMAHAWK MAX" };

            motherboardRepo.Setup(x => x.Update(It.IsAny<Motherboard>())).Returns(mboard1);

            var logic = new MotherboardLogic(null, motherboardRepo.Object, null);
            //Act
            var result = Assert.Throws(typeof(Exception), () => logic.Update(mboard1));
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("No entity found!"));
        }
        [Test]
        public void UpdateTestWithNull()
        {
            //Arrange
            var motherboardRepo = new Mock<IMotherboardRepository>();

            motherboardRepo.Setup(x => x.Update(null)).Throws<Exception>();

            var logic = new MotherboardLogic(null, motherboardRepo.Object, null);
            //Act
            var result = Assert.Throws(typeof(Exception), () => logic.Update(null));
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("Must contain data!"));
        }
        [Test]
        public void MotherboardsWhitItsProcessorsTest()
        {

        }
        [Test]
        public void MotherboardProcessorAvaragePricesTest()
        {

        }
        [Test]
        public void BestPPPForMotherboardTest()
        {

        }

        #region Utils
        
        static List<TestCaseData> GetCreateData()
        {
            var result = new List<TestCaseData>();

            

            return result;
        }
        #endregion
    }
}
