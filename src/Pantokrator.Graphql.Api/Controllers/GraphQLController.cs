using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Pantokrator.Graphql.Api.Graphql.Models;
using Pantokrator.Graphql.Api.Graphql.Queries;
using Pantokrator.Graphql.Data.Repository;
using Pantokrator.GraphQL.Api.Core.Controllers;

namespace Pantokrator.Graphql.Api.Controllers
{
    [Route("api/[controller]")]
    public class GraphqlController : BaseController
    {
        private readonly IPersonRepository _personRepository;

        public GraphqlController(IPersonRepository personRepository)
        {

            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var schema = new Schema { Query = new PersonQuery(_personRepository) };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = "query";

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}