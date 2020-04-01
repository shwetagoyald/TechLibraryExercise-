using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechLibrary.Services;
using TechLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace TechLibrary.Controllers.Tests
{
    [TestFixture()]
    [Category("ControllerTests")]
    public class BooksControllerTests
    {

        private  Mock<ILogger<BooksController>> _mockLogger;
        private  Mock<IBookService> _mockBookService;
        private  Mock<IMapper> _mockMapper;
        private NullReferenceException _expectedException;


        [OneTimeSetUp]
        public void TestSetup()
        {
            _expectedException = new NullReferenceException("Test Failed...");
            _mockLogger = new Mock<ILogger<BooksController>>();
            _mockBookService = new Mock<IBookService>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test()]
        public async Task GetAllTest()
        {
            //  Arrange
            _mockBookService.Setup(b => b.GetBooksAsync()).Returns(Task.FromResult(It.IsAny<List<Domain.Book>>()));
             var sut = new BooksController(_mockLogger.Object, _mockBookService.Object, _mockMapper.Object);

            //  Act
            var result = await sut.GetAll();

            //  Assert
            _mockBookService.Verify(s => s.GetBooksAsync(), Times.Once, "Expected GetBooksAsync to have been called once");
        }

        [Test]
        public async Task GetBooksFilteredPagedTest()
        {
            //  Arrange
            _mockBookService.Setup(b => b.GetBooksFilteredPagedAsync(10, 0, "android")).Returns(Task.FromResult(It.IsAny<List<Domain.Book>>()));
             var sut = new BooksController(_mockLogger.Object, _mockBookService.Object, _mockMapper.Object);

            //  Act
            var result = await sut.GetBooksFiltered(10, 0, "android");

            //  Assert
            _mockBookService.Verify(s => s.GetBooksFilteredPagedAsync(10, 0, "android"), Times.Once, "Expected GetBooksFilteredPagedAsync to have been called once");


            //Assert.IsInstanceOf<OkObjectResult>(result);
            //var resultResponse = result as OkObjectResult;
            //Assert.IsTrue(resultResponse.ContentTypes.Count > 0, "No records found");
        }
    }
}