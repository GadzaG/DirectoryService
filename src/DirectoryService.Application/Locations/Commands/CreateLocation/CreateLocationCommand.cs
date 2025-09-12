using DirectoryService.Application.Abstractions.Core;
using DirectoryService.Contracts.Dtos;

namespace DirectoryService.Application.Locations.Commands.CreateLocation;


public record CreateLocationCommand(string Name, AddressDto Address, string Timezone) : ICommand;