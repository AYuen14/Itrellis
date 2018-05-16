﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using log4net;
using CarDealership.Services;
using CarDealership.Repository.Interface;
using System.Threading.Tasks;
using CarDealership.Models;
using FluentAssertions;

namespace CarDealership.Tests.Service
{
    [TestFixture(Category = "Car Dealership Service")]
    public class UnitTest1
    {
        [Test]
        public void Constructor_NullReferenceForICarDealershipRepository_ShouldThrowArgumentNullException()
        {
            //Arrange
            var mockLogger = new Mock<ILog>();

            //Act
            Action result = () =>
            {
                new CarDealershipService(mockLogger.Object, null);
            };

            //Assert
            result.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Constructor_NullReferenceForILog_ShouldThrowArgumentNullException()
        {
            //Arrange
            var carDealershipRepositoryMock = new Mock<ICarDealershipRepository>();

            //Act
            Action result = () =>
            {
                new CarDealershipService(null, carDealershipRepositoryMock.Object);
            };

            //Assert
            result.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetCarInformationAsync_PassingNullForCarOptions_ShouldThrowArgumentException()
        {
            //Arrange
            var mockLogger = new Mock<ILog>();
            var carDealershipRepositoryMock = new Mock<ICarDealershipRepository>();
            var CarDealershipService = new CarDealershipService(mockLogger.Object, carDealershipRepositoryMock.Object);

            //Act
            Func<Task> result = async () =>
            {
                await CarDealershipService.GetCarInformationAsync(null);
            };

            //Assert
            result.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GetCarInformationAsync_GivenCarOptions_ShouldCallGetCarInformationAsyncWithOptionsPassed()
        {
            //Arrange
            var mockLogger = new Mock<ILog>();
            var carDealershipRepositoryMock = new Mock<ICarDealershipRepository>();
            carDealershipRepositoryMock
                .Setup(sut => sut.GetCarInformationAsync(It.IsAny<Car>()))
                .ReturnsAsync(new Models.ViewModel.CarViewModel());

            var carOptions = new Car();

            //Act
            var CarDealershipService = new CarDealershipService(mockLogger.Object, carDealershipRepositoryMock.Object);
            var result = CarDealershipService.GetCarInformationAsync(carOptions);

            //Assert
            carDealershipRepositoryMock.Verify(repo => repo.GetCarInformationAsync(carOptions));
        }
    }
}
