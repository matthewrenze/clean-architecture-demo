using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Sales.Commands.CreateSale;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitecture.Presentation.Sales.Models
{
    public class CreateSaleViewModel
    {
        public List<SelectListItem> Customers { get; set; }

        public List<SelectListItem> Employees { get; set; }

        public List<SelectListItem> Products { get; set; }

        public CreateSaleModel Sale { get; set; }
    }
}