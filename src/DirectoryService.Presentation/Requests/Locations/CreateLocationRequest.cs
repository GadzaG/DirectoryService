using DirectoryService.Application.Locations.Commands.CreateLocation;
using DirectoryService.Contracts.Dtos;

namespace DirectoryService.Presentation.Requests.Locations;

public record CreateLocationRequest(string LocationName, AddressDto AddressDto, string Timezone)
{
    public CreateLocationCommand ToCommand()
    {
        return new CreateLocationCommand(LocationName, AddressDto, Timezone);
    }
}