
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

namespace App.Core.Apps.State.Query
{
    public class GetAllState : IRequest<List<domain.Model.CountryState.State>>
    {
    }


    public class GetAllStateQueryHandler : IRequestHandler<GetAllState, List<domain.Model.CountryState.State>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllStateQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<domain.Model.CountryState.State>> Handle(GetAllState request, CancellationToken cancellationToken)
        {
            var connection = _appDbContext.GetConnection();
            var query = "SELECT * FROM States";
            var allState = await connection.QueryAsync<domain.Model.CountryState.State>(query);
            return allState.ToList();
        }
    }






}
