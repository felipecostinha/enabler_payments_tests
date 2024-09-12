using System;
using BoDi;
using contacts.Application.Context;
using contacts.Repository.Impl;
using contacts.Services;
using contacts.Services.Impl;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;

namespace specflow_test.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer container;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            IContactService service = new ContactServiceImpl(
                new ContactRepositoryImpl(
                    new DatabaseContext(
                        new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("spec_flow_test")
                            .Options)));

            // Make this instance available to all other step definitions
            container.RegisterInstanceAs(service);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            container.Dispose();
        }
    }
}