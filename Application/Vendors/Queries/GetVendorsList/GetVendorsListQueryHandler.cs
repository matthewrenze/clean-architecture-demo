using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Core.Queries;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Vendors.Queries.GetVendorsList
{
    public class GetVendorsListQueryHandler 
        : IQueryHandler<GetVendorsListQuery, List<VendorsListItemDto>>
    {
        private readonly IDatabaseContext _database;

        public GetVendorsListQueryHandler(IDatabaseContext database)
        {
            _database = database;
        }

        public List<VendorsListItemDto> Execute(GetVendorsListQuery query)
        {
            var vendors = _database.Vendors
                .Select(p => new VendorsListItemDto
                {
                    Id = p.Id, 
                    Name = p.Name
                });

            return vendors.ToList();
        }
    }
}
