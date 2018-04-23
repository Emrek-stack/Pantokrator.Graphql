using Pantokrator.Graphql.Data.Context.AdventureWorks;
using Pantokrator.Repository.Contracts.Impl;

namespace Pantokrator.Graphql.Data.Repository.Impl
{
    public class PersonRepository : EfRepository<Person, AdventureWorks>, IPersonRepository
    {
        public PersonRepository(AdventureWorks context) : base(context)
        {
        }
    }
}