using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;

namespace CleanArchitecture.Service.Sales
{
    public class SalesController : ApiController
    {
        private readonly IGetSalesListQuery _listQuery;
        private readonly IGetSaleDetailQuery _detailQuery;
        private readonly ICreateSaleCommand _createCommand;

        public SalesController(
            IGetSalesListQuery listQuery,
            IGetSaleDetailQuery detailQuery,
            ICreateSaleCommand createCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
        }

        public IEnumerable<SalesListItemModel> Get()
        {
            return _listQuery.Execute();
        }

        public SaleDetailModel Get(int id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateSaleModel sale)
        {
            _createCommand.Execute(sale);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
