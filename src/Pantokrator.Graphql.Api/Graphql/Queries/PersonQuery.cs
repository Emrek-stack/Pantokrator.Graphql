using GraphQL.Types;
using Pantokrator.Graphql.Api.Graphql.Types;
using Pantokrator.Graphql.Data.Repository;

namespace Pantokrator.Graphql.Api.Graphql.Queries
{
    public class PersonQuery : ObjectGraphType
    {
        IPersonRepository _personRepository;

        public PersonQuery(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

            Field<PersonType>("person",
                resolve: context => _personRepository.GetAll());
        }
    }
}