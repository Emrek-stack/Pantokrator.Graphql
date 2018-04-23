using Pantokrator.Graphql.Data.Context.AdventureWorks;
using Pantokrator.Repository.Contracts;

namespace Pantokrator.Graphql.Data.Repository
{
    public interface IPersonRepository : IEfRepository<Person>
    {
        
    }
}