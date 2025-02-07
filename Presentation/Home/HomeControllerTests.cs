using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.Home
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private AutoMocker _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _controller = _mocker.CreateInstance<HomeController>();
        }

        [Test]
        public void TestGetIndexShouldReturnView()
        {
            var result = _controller.Index();

            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}