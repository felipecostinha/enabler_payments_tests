using contacts.Application.Exceptions;
using contacts.Domain;
using contacts.Repository;
using contacts.Services.Impl;
using contacts.unitTests.Mocks;
using JetBrains.Annotations;
using Moq;

namespace contacts.unitTests.Services.Impl;

[TestSubject(typeof(ContactServiceImpl))]
public class ContactServiceImplTest
{
    private ContactServiceImpl _service;
    private Mock<IContactRepository> _contactRepositoryMock;
    private const int IdInvalido = 999;
    private const int IdValido = 1;

    public ContactServiceImplTest()
    {
        _contactRepositoryMock = new(MockBehavior.Strict);
        _service = new(_contactRepositoryMock.Object);
    }

    [Fact]
    public async Task ShouldThrowExceptionOnGetContactById()
    {
        _contactRepositoryMock.Setup(r => r.GetContactById(IdInvalido)).Returns(() => Task.FromResult<Contact>(null!));

        var error = await Assert.ThrowsAsync<NotFoundException>(() => _service.GetContactById(IdInvalido));

        Assert.Equal("Contact not found", error.Message);
    }

    [Fact]
    public async Task ShouldReturnContactOnGetContactById()
    {
        _contactRepositoryMock.Setup(r => r.GetContactById(IdInvalido)).Returns(() => Task.FromResult<Contact>(ContactMock.Create()));

        var contact = await _service.GetContactById(IdInvalido);

        Assert.Equal(IdValido, contact.Id);
        Assert.Equal("Felipe", contact.FirstName);
        Assert.Equal("Costa", contact.LastName);
        Assert.Equal("felipe.paltrinieri@vtex.com", contact.Email);
        Assert.Equal("123456", contact.PhoneNumber);
    }
}