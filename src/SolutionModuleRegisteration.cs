using DNA.Web;
using System.Data.Entity;

namespace SharedContextTest
{
    public class SharedContextTestRegisteration : SolutionModule
    {
        public override string Name
        {
            get { return "SharedContextTest"; }
        }

        public override void OnAppStart(System.Web.HttpApplication app)
        {
            Database.SetInitializer<SharedDbContext>(null);
        }
    }
}
