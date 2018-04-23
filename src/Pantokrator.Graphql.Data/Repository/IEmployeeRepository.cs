using System.Collections.Generic;
using System.Threading.Tasks;
using Pantokrator.Graphql.Data.Context.AdventureWorks;
using Pantokrator.GraphQL.Core.Models.Responses;
using Pantokrator.Repository.Contracts;

namespace Pantokrator.Graphql.Data.Repository
{
    public interface IEmployeeRepository : IEfRepository<Employee>
    {
        Task<BaseResponse<IReadOnlyCollection<Employee>>> GetAllEmployees();
    }
}