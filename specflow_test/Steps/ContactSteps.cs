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
public class ContactSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IContactService _service;
    private Contact _contact = new Contact();

    public ContactSteps(ScenarioContext scenarioContext, IContactService service)
    {
        _scenarioContext = scenarioContext;
        _service = service;
    }

    #region Given

    [Given("id is '(.*)'")]
    public async void IdIs(string id)
    {
        _contact.Id = int.Parse(id);
    }

    [Given("first name is '(.*)'")]
    public async void FirstNameIs(string firstName)
    {
        _contact.FirstName = firstName;
    }

    [Given("last name is '(.*)'")]
    public async void LastNameIs(string lastName)
    {
        _contact.LastName = lastName;
    }

    [Given("email is '(.*)'")]
    public async void EmailIs(string email)
    {
        _contact.Email = email;
    }

    [Given("phone number is '(.*)'")]
    public async void PhoneNumberIs(string phoneNumber)
    {
        _contact.PhoneNumber = phoneNumber;
    }

    [Given("exists an contact with id '(.*)'")]
    public async void ExistsAnContactWithId(int id)
    {
        IdIs("1");
        FirstNameIs("Felipe");
        LastNameIs("Costa");
        EmailIs("test@test.com");
        PhoneNumberIs("555-555-5555");
        
        SaveContact();
    }

    #endregion

    #region When

    [When("save this contact")]
    public void SaveContact()
    {
        _service.SaveContact(_contact);
    }

    [When("delete contact with id '(.*)'")]
    public void DeleteContact(int id)
    {
        _service.DeleteContact(id);
    }
    
    #endregion
    
    #region Then

    [Then("Contact's table size must be '(.*)'")]
    public async void ContactsTableSizeMustBe(int size)
    {
        var contactsCount = await _service.GetContacts();
        
        Assert.Equal(size, contactsCount.Count);
    }
    
    #endregion
}