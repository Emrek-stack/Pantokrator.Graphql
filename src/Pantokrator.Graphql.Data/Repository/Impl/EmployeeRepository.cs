using System.Collections.Generic;
using System.Threading.Tasks;
using Pantokrator.Graphql.Data.Context.AdventureWorks;
using Pantokrator.GraphQL.Core.Models.Responses;
using Pantokrator.Repository.Contracts.Impl;

namespace Pantokrator.Graphql.Data.Repository.Impl
{
    public class EmployeeRepository : EfRepository<Employee, AdventureWorks>, IEmployeeRepository
    {
        public EmployeeRepository(AdventureWorks context) : base(context)
        {
        }


        public async Task<BaseResponse<IReadOnlyCollection<Employee>>> GetAllEmployees()
        {
            var response = new BaseResponse<IReadOnlyCollection<Employee>> { Data = await GetAllAsync() };
            response.Total = response.Data.Count;
            return response;
        }
    }
}