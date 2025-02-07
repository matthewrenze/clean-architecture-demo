using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;
using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;
using CleanArchitecture.Application.Products.Queries.GetProductsList;
using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Presentation.Sales.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.Presentation.Sales.Services
{
    public class CreateSaleViewModelFactory : ICreateSaleViewModelFactory
    {
        private readonly IGetCustomersListQuery _customersQuery;
        private readonly IGetEmployeesListQuery _employeesQuery;
        private readonly IGetProductsListQuery _productsQuery;

        public CreateSaleViewModelFactory(
            IGetCustomersListQuery customersQuery,
            IGetEmployeesListQuery employeesQuery,
            IGetProductsListQuery productsQuery)
        {
            _customersQuery = customersQuery;
            _employeesQuery = employeesQuery;
            _productsQuery = productsQuery;
        }

        public CreateSaleViewModel Create()
        {
            var employees = _employeesQuery.Execute();

            var customers = _customersQuery.Execute();

            var products = _productsQuery.Execute();

            var viewModel = new CreateSaleViewModel();

            viewModel.Employees = employees
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            viewModel.Customers = customers
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            viewModel.Products = products
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name + " ($" + p.UnitPrice + ")"
                })
                .ToList();

            viewModel.Sale = new CreateSaleModel();

            return viewModel;
        }
    }
}