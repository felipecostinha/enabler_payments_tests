using contacts.Domain;

namespace contacts.unitTests.Mocks;

public static class ContactMock
{
    public static Contact Create()
    {
        return new Contact(1, "Felipe", "Costa", "felipe.paltrinieri@vtex.com", "123456");
    }
}