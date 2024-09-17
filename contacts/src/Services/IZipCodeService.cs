using contacts.Domain;

namespace contacts.Services;

public interface IZipCodeService
{
    Task<ZipCode> Consult(String zipCode);
}