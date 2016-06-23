using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using AuthorizationRepository = AuthAndApi.Repository.Authorization;


namespace AuthAndApi.Ef6 {

    public class Context : DbContext, AuthorizationRepository {

        public DbSet<Authorization> Authorizations { get; set; }

        public IEnumerable<Authorization> GetForOwner(Owner owner) {
            return Authorizations
                .Where(a => a.Owner == owner)
                .AsNoTracking()
                .ToList()
            ;
        }

        void AuthorizationRepository.UpdateOrCreate(Authorization authorization) {
            // I know: http://stackoverflow.com/questions/5557829/update-row-if-it-exists-else-insert-logic-with-entity-framework
            Authorizations.AddOrUpdate(authorization);
        }

    }

}
