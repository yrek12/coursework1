using DAL.Models;
using DAL.Repository;
using Ninject.Modules;

namespace DAL.Dependencies
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            var agencyContext = new Context();

            Bind<IGenericRepository<User>>().ToConstructor(x => new ContextRepository<User>(agencyContext));
            Bind<IGenericRepository<Role>>().ToConstructor(x => new ContextRepository<Role>(agencyContext));
            Bind<IGenericRepository<Vacansy>>().ToConstructor(x => new ContextRepository<Vacansy>(agencyContext));
            Bind<IGenericRepository<Resume>>().ToConstructor(x => new ContextRepository<Resume>(agencyContext));

            Bind<IUnitOfWork>().ToConstructor
                (x => new UnitOfWork(agencyContext, x.Inject<IGenericRepository<Role>>(), x.Inject<IGenericRepository<User>>(), x.Inject<IGenericRepository<Resume>>(), x.Inject<IGenericRepository<Vacansy>>()));
        }
    }
}
