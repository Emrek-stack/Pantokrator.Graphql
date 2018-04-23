using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pantokrator.Graphql.Data.Context.AdventureWorks;
using Pantokrator.Graphql.Data.Repository;
using Pantokrator.GraphQL.Api.Core.Controllers;
using Pantokrator.GraphQL.Core.Models.Responses;

namespace Pantokrator.Graphql.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ValuesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<BaseResponse<IReadOnlyCollection<Employee>>> Get()
        {
            var data = await _employeeRepository.GetAllEmployees();
            return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
