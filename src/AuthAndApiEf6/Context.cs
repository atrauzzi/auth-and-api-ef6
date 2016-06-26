using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace AuthAndApi.Ef6 {

    public class Context<OwnerType> : DbContext, Repository.Authorization where OwnerType : AuthAndApi.Owner {

        public DbSet<AuthAndApi.Authorization<OwnerType>> Authorizations { get; set; }

        public IEnumerable<AuthorizationContract> GetForOwner(AuthAndApi.Owner owner) {
            return Authorizations
                .Where(a => a.Owner.Equals(owner))
                .AsNoTracking()
                .ToList()
            ;
        }

        public void UpdateOrCreate(AuthAndApi.AuthorizationContract authorization) {
            // I know: http://stackoverflow.com/questions/5557829/update-row-if-it-exists-else-insert-logic-with-entity-framework
            Authorizations.AddOrUpdate((Authorization<OwnerType>)authorization);
        }

    }

}
