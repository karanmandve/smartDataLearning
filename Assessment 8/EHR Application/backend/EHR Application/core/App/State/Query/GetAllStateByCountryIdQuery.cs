
using core.Interface;
using Dapper;
using domain.Model.CountryState;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Core.Apps.State.Query
{
    public class GetAllStateByCountryIdQuery : IRequest<List<domain.Model.CountryState.State>>
    {
        public int CountryId { get; set; }
    }


    public class GetAllStateByCountryIdQueryHandler : IRequestHandler<GetAllStateByCountryIdQuery, List<domain.Model.CountryState.State>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllStateByCountryIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<domain.Model.CountryState.State>> Handle(GetAllStateByCountryIdQuery request, CancellationToken cancellationToken)
        {
            var connection = _appDbContext.GetConnection();
            var query = "SELECT * FROM States WHERE CountryId = @CountryId";
            var allStateByCountryId = await connection.QueryAsync<domain.Model.CountryState.State>(query, new { CountryId = request.CountryId });
            return allStateByCountryId.ToList();
        }
    }




}
