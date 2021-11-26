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
    class MBrandLogicTests
    {
        [Test]
        public void CreateTestWithProperData()
        {
            //Arrange
            var mBrandRepo = new Mock<IMBrandRepository>();

            var mBrand1 = new MBrand() { Id = 1, Name = "mBrandtest1" };

            mBrandRepo.Setup(x => x.Create(mBrand1)).Returns(mBrand1);

            var logic = new MBrandLogic(mBrandRepo.Object, null, null);
            //Act
            var result = logic.Create(mBrand1);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(mBrand1));
        }
        [Test]
        public void CreateTestWithNull()
        {
            //Arrange
            var mBrandRepo = new Mock<IMBrandRepository>();

            mBrandRepo.Setup(x => x.Create(null)).Throws<Exception>();

            var logic = new MBrandLogic(mBrandRepo.Object, null, null);
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
            var mBrandRepo = new Mock<IMBrandRepository>();

            var mBrand1 = new MBrand() { Id = 1, Name = "" };

            var logic = new MBrandLogic(mBrandRepo.Object, null, null);
            //Act
            var result1 = Assert.Throws(typeof(Exception), () => logic.Create(mBrand1));

            //Assert
            Assert.That(result1, Is.Not.Null);
            Assert.That(result1.Message, Is.EqualTo("Must contain the required data!"));
        }

        [Test]
        public void UpdateTestWithNonExistetData()
        {
            //Arrange
            var mBrandRepo = new Mock<IMBrandRepository>();

            var mBrand1 = new MBrand() { Id = 1, Name = "mBrandtest1" };

            mBrandRepo.Setup(x => x.Update(mBrand1)).Returns(mBrand1);

            var logic = new MBrandLogic(mBrandRepo.Object, null, null);
            //Act
            var result = Assert.Throws(typeof(Exception), () => logic.Update(mBrand1));
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("No entity found!"));
        }
        [Test]
        public void UpdateTestWithNull()
        {
            //Arrange
            var mBrandRepo = new Mock<IMBrandRepository>();

            mBrandRepo.Setup(x => x.Update(null)).Throws<Exception>();

            var logic = new MBrandLogic(mBrandRepo.Object, null, null);
            //Act
            var result = Assert.Throws(typeof(Exception), () => logic.Update(null));
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("Must contain data!"));
        }
    }
}
