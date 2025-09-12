namespace DirectoryService.Contracts.Dtos;

public record AddressDto(
    string Country,
    string City,
    string Street,
    string Region,
    string House,
    string? PostalCode);