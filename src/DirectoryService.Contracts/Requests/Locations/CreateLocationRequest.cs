using DirectoryService.Contracts.Dtos;

namespace DirectoryService.Contracts.Requests.Locations;

public record CreateLocationRequest(string LocationName, AddressDto AddressDto, string Timezone);