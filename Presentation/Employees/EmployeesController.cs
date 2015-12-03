using System;
using System.Web.Mvc;
using CleanArchitecture.Application.Core.MessageBus;
using CleanArchitecture.Application.Employees.Queries.GetEmployeeList;

namespace CleanArchitecture.Presentation.Employees
{
    public class EmployeesController : Controller
    {
        private readonly IMessageBus _messageBus;

        public EmployeesController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public ActionResult Index()
        {
            var employees = _messageBus.Execute(new GetEmployeesListQuery());

            return View(employees);
        }
    }
}