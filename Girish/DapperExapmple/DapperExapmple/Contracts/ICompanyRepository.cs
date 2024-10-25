using DapperExapmple.Dto;
using DapperExapmple.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExapmple.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task<Company> CreateCompany(CompanyForCreationDto company);
        public Task UpdateCompany(int id, CompanyForUpdateDto company);
        public Task DeleteCompany(int id);

        public Task<Company> GetCompanyByEmployeeId(int id);
    }
}
