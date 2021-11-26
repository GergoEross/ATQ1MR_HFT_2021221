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
    class ProcessorLogicTests
    {
        [Test]
        public void CreateTestWithProperData()
        {
            //Arrange
            var processorRepo = new Mock<IProcessorRepository>();

            var pro1 = new Processor() { Id = 1, BrandId = 1, Name = "testname1", Socket = "testsocket1", BaseClock = 3.5, BoostClock = 4.1, Cores = 4, Price = 2000, Threads = 8 };

            processorRepo.Setup(x => x.Create(pro1)).Returns(pro1);

            var logic = new ProcessorLogic(null, null, processorRepo.Object);
            //Act
            var result = logic.Create(pro1);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(pro1));
        }
        [Test]
        public void CreateTestWithNull()
        {
            //Arrange
            var processorRepo = new Mock<IProcessorRepository>();

            processorRepo.Setup(x => x.Create(null)).Throws<Exception>();

            var logic = new ProcessorLogic(null, null, processorRepo.Object);
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
            var processorRepo = new Mock<IProcessorRepository>();

            var pro1 = new Processor() { Id = 1, BrandId = 1, Name = "", Socket = "testsocket1", BaseClock = 3.5, BoostClock = 4.1, Cores = 4, Price = 2000, Threads = 8 };

            var logic = new ProcessorLogic(null, null, processorRepo.Object);
            //Act
            var result1 = Assert.Throws(typeof(Exception), () => logic.Create(pro1));
            
            //Assert
            Assert.That(result1, Is.Not.Null);
            Assert.That(result1.Message, Is.EqualTo("Must contain the required data!"));
        }

        [Test]
        public void UpdateTestWithNonExistetData()
        {
            //Arrange
            var processorRepo = new Mock<IProcessorRepository>();

            var pro1 = new Processor() { Id = 1, BrandId = 1, Name = "testname1", Socket = "testsocket1", BaseClock = 3.5, BoostClock = 4.1, Cores = 4, Price = 2000, Threads = 8 };

            processorRepo.Setup(x => x.Update(pro1)).Returns(pro1);

            var logic = new ProcessorLogic(null, null, processorRepo.Object);
            //Act
            var result = Assert.Throws(typeof(Exception), () => logic.Update(pro1));
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("No entity found!"));
        }
        [Test]
        public void UpdateTestWithNull()
        {
            //Arrange
            var processorRepo = new Mock<IProcessorRepository>();

            processorRepo.Setup(x => x.Update(null)).Throws<Exception>();

            var logic = new ProcessorLogic(null, null, processorRepo.Object);
            //Act
            var result = Assert.Throws(typeof(Exception), () => logic.Update(null));
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("Must contain data!"));
        }
    }
}
