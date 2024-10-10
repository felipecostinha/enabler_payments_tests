using BoDi;
using Microsoft.EntityFrameworkCore;
using orders;
using orders.Repository.Impl;
using orders.Services;
using orders.Services.Impl;
using TechTalk.SpecFlow;

namespace specflow_test.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            IPaymentService _paymentService = new PaymentService(
                new PaymentRepositoryImpl(
                    new DatabaseContext(
                        new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("spec_flow_test")
                            .Options)));

            // Make this instance available to all other step definitions
            _container.RegisterInstanceAs(_paymentService);

            IProviderService _providerService = new ProviderService(
                new ProviderRepositoryImpl(
                    new DatabaseContext(
                        new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("spec_flow_test")
                            .Options)));

            // Make this instance available to all other step definitions
            _container.RegisterInstanceAs(_providerService);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            _container.Dispose();
        }
    }
}