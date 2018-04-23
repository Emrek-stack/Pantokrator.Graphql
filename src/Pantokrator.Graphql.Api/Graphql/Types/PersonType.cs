using GraphQL.Types;
using Pantokrator.Graphql.Data.Context.AdventureWorks;

namespace Pantokrator.Graphql.Api.Graphql.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.FirstName).Description("Firstname");
            Field(x => x.LastName).Description("Lastname");
        }
        
    }
}