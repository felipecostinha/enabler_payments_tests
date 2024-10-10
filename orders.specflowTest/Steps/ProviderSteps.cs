using orders.Domain;
using orders.Services;
using TechTalk.SpecFlow;

namespace specflow_test.Steps;

[Binding]
public class ProviderSteps(IProviderService service)
{
    private Provider _provider = new();

    #region Given

    [Given("id is '(.*)'")]
    public void GivenIdIs(string id)
    {
        _provider.Id = id;
    }

    [Given("name is '(.*)'")]
    public void GivenNameIs(string name)
    {
        _provider.Name = name;
    }

    [Given("exists an contact with id '(.*)'")]
    public void GivenExistsAnProviderWithId(int id)
    {
        GivenIdIs("1");
        GivenNameIs("FakeProvider");

        WhenSaveThisProvider();
    }

    #endregion

    #region When

    [When("save this provider")]
    public void WhenSaveThisProvider()
    {
        service.SaveProvider(_provider);
    }

    #endregion
}