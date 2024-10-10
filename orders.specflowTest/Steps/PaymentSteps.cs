using orders.Domain;
using orders.Services;
using TechTalk.SpecFlow;

namespace specflow_test.Steps;

[Binding]
public class PaymentSteps(IPaymentService service)
{
    private Payment _payment = new();

    #region Given

    [Given("id is '(.*)'")]
    public void GivenIdIs(string id)
    {
        _payment.Id = id;
    }

    [Given("value is '(.*)'")]
    public void GivenValue(string value)
    {
        _payment.Value = Double.Parse(value);
    }

    [Given("status is '(.*)'")]
    public void GivenStatus(PaymentStatus status)
    {
        _payment.Status = status;
    }

    [Given("providerId is '(.*)'")]
    public void GivenProviderId(string providerId)
    {
        _payment.ProviderId = providerId;
    }

    [Given("exists an payment with id '(.*)'")]
    public void GivenExistsAnPaymentWithId(int id)
    {
        GivenIdIs("1");
        GivenValue("9");
        GivenStatus(PaymentStatus.Started);
        GivenProviderId("1"); // O provider

        WhenSaveThisPayment();
    }

    #endregion

    #region When

    [When("save this payment")]
    public void WhenSaveThisPayment()
    {
        service.SavePayment(_payment);
    }

    #endregion
}