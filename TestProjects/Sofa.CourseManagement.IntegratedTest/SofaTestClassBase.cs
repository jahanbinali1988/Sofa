using Xunit;

namespace Sofa.CourseManagement.IntegratedTest
{
    [Collection("TestContext collection")]
    public class SofaTestClassBase
    {
        protected readonly TestContextFixture testContext;

        public SofaTestClassBase(TestContextFixture testContext)
        {
            this.testContext = testContext;
        }
    }
}
