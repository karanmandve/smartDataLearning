
using core.Interface;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Core.Apps.Country.Query
{
    public class GetAllCountryQuery : IRequest<List<domain.Model.CountryState.Country>>
    {
    }

    public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, List<domain.Model.CountryState.Country>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllCountryQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<domain.Model.CountryState.Country>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            var connection = _appDbContext.GetConnection();
            var query = "SELECT * FROM Countries";
            var allCountry = await connection.QueryAsync<domain.Model.CountryState.Country>(query);
            return allCountry.ToList();
        }
    }


}
