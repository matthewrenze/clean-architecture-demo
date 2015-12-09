using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMoq;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.Home
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<HomeController>();
        }

        [Test]
        public void TestGetIndexShouldReturnView()
        {
            var result = _controller.Index();

            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}