using System.Web.Http.Dependencies;
using Ninject;
using ResumesAndVacancies.Dependencies;

namespace ResumesAndVacancies.Dependencies
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        /// <returns>Range of the dependencies</returns>
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}