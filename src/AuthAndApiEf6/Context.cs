using System;
using System.Collections.Generic;
using System.Data.Entity;
using AuthorizationRepository = AuthAndApi.Repository.Authorization<int>;


namespace AuthAndApi.Ef6 {

    public class Context : DbContext, AuthorizationRepository {

        public DbSet<Authorization> Authorizations { get; set; }

        public Authorization Get(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Authorization> GetForOwner(Owner owner) {
            throw new NotImplementedException();
        }

        public IEnumerable<Authorization> UpdateOrCreate() {
            throw new NotImplementedException();
        }

    }

}
