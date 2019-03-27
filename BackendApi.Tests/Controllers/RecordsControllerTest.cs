using BackendApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using BackendApi.Models;
using BackendApi.Services;
using Moq;
using System;
using System.Net;

namespace BackendApi.Tests
{
    [TestClass]
    public class RecordsControllerTest
    {

        Mock<IRecordsService> _recordsService;
        RecordsController _controller;

        [TestInitialize]
        public void Init()
        {
           _recordsService = new Mock<IRecordsService>();
           _controller = new RecordsController(_recordsService.Object);

        }

        [TestMethod]
        public void Has_GetRecords()
        {
            // arrange
            // act
            var result = _controller.GetRecords();
            // assert
            result.Should().NotBeNull();
        }


        [TestMethod]
        public void Calls_IRecordsService()
        {
            // arrange
            // act
            var result = _controller.GetRecords();

            // assert
            _recordsService.Verify(mq => mq.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Has_SaveRecords()
        {
            // arrange
            var record = new Record();
            // act
            var result = _controller.SaveRecord(record);
            // assert
            result.Should().NotBeNull();
        }

        // HTTP Status Codes
        // 200 - Success
        // 404 - Resource not found
        // 500 - Internal Server Error
        // 503 - Server Unavailable


        [TestMethod]
        public void Return_503_When_IRecordsService_Throws_Exception()
        {
            // arrange
            _recordsService.Setup(mq => mq.GetAll()).Throws(new Exception("Db Down"));
            // act
            var result = _controller.GetRecords();
            // assert
            Assert.IsTrue(result is StatusCodeResult);
            var statusCode = (StatusCodeResult)result;
            statusCode.StatusCode.Should().Be((int)HttpStatusCode.ServiceUnavailable);
        }

        [TestMethod]
        public void Return_BadRequest_When_RequeredFields_Missing()
        {
            // arrange
            var emptyRecord = new Record();
            // act
            var result = _controller.SaveRecord(emptyRecord);
            // assert
            //Assert.IsTrue(result is ModelState);
            //var modelState = (ModelState)result;
            //modelState.Should().Be((int)HttpStatusCode.BadRequest);

            Assert.IsTrue(result is StatusCodeResult);
            var statusCode = (StatusCodeResult)result;
            statusCode.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
