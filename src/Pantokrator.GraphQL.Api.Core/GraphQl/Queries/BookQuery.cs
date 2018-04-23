using GraphQL.Types;
using Pantokrator.Graphql.Data.Repository;
using Pantokrator.GraphQL.Api.Core.GraphQl.Types;

namespace Pantokrator.GraphQL.Api.Core.GraphQl.Queries
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Field<PersonType>("person",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "isbn" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("isbn");
                    return personRepository.GetBy(f => f.BusinessEntityId == id);
                });

            Field<ListGraphType<PersonType>>("persons",
                resolve: context => personRepository.GetAll());
        }
    }
}