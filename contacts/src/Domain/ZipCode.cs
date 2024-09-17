using Lombok.NET;

namespace contacts.Domain;

public record class ZipCode(
     string Cep,
     string Logradouro,
     string Complemento,
     string Unidade,
     string Bairro,
     string Localidade,
     string Uf,
     string Estado,
     string Regiao,
     string Ibge,
     string Gia,
     string Ddd,
     string Siafi
     );