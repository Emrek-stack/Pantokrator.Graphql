using GraphQL.Types;
using Pantokrator.Graphql.Data.Context.AdventureWorks;

namespace Pantokrator.GraphQL.Api.Core.GraphQl.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.FirstName).Description("The isbn of the book.");
            Field(x => x.LastName).Description("The name of the book.");
            //Field<ListGraphType<EmailAddress>("emails");
        }
    }
}