using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Core.Queries;

namespace CleanArchitecture.Application.Sales.Queries.GetSaleDetails
{
    public class GetSaleDetailQuery : IQuery<SaleDetailDto>
    {
        private readonly int _saleId;
        
        public GetSaleDetailQuery(int saleId)
        {
            _saleId = saleId;
        }

        public int SaleId
        {
            get { return _saleId; }
        }
    }
}
