using contacts;
using contacts.Application.Context;
using contacts.Domain;
using contacts.Services;
using contacts.Services.Impl;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;
using Xunit;

namespace specflow_test.Steps;

[Binding]
public class ContactSteps(IContactService service)
{
    private Contact _contact = new Contact();

    #region Given

    [Given("id is '(.*)'")]
    public void GivenIdIs(string id)
    {
        _contact.Id = int.Parse(id);
    }

    [Given("first name is '(.*)'")]
    public void GivenFirstNameIs(string firstName)
    {
        _contact.FirstName = firstName;
    }

    [Given("last name is '(.*)'")]
    public void GivenLastNameIs(string lastName)
    {
        _contact.LastName = lastName;
    }

    [Given("email is '(.*)'")]
    public void GivenEmailIs(string email)
    {
        _contact.Email = email;
    }

    [Given("phone number is '(.*)'")]
    public void GivenPhoneNumberIs(string phoneNumber)
    {
        _contact.PhoneNumber = phoneNumber;
    }

    [Given("exists an contact with id '(.*)'")]
    public void GivenExistsAnContactWithId(int id)
    {
        GivenIdIs("1");
        GivenFirstNameIs("Felipe");
        GivenLastNameIs("Costa");
        GivenEmailIs("test@test.com");
        GivenPhoneNumberIs("555-555-5555");

        WhenSaveThisContact();
    }

    #endregion

    #region When

    [When("save this contact")]
    public void WhenSaveThisContact()
    {
        service.SaveContact(_contact);
    }

    [When("delete contact with id '(.*)'")]
    public void WhenDeleteContactWithId(int id)
    {
        service.DeleteContact(id);
    }

    #endregion

    #region Then

    [Then("Contact's table size must be '(.*)'")]
    public async void ThenContact(int size)
    {
        var contactsCount = await service.GetContacts();

        Assert.Equal(size, contactsCount.Count);
    }

    #endregion
}