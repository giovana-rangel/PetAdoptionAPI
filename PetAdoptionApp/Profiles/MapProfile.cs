using AutoMapper;
using PetAdoptionApp.Models;
using PetAdoptionApp.Models.DTO;

namespace PetAdoptionApp.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserClient, UserViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.Username, opt => opt.MapFrom(o => o.Username))
                .ForMember(x => x.Bio, opt => opt.MapFrom(o => o.Bio))
                .ForMember(x => x.Email, opt => opt.MapFrom(o => o.Email))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(o => o.IsActive))
                .ForMember(x => x.Role, opt => opt.MapFrom(o => o.RollIdFkNavigation.ClientRole))
                .ForMember(x => x.ImagePath, opt => opt.MapFrom(o => o.ImageIdFkNavigation.PicturePath))
                .ForMember(x => x.Location, opt => opt.MapFrom(o => o.LocationIdFkNavigation))
                .ForMember(x => x.FavPets, opt => opt.MapFrom(o => o.FavPets))
                .ForMember(x => x.Pets, opt => opt.MapFrom(o => o.Pets))
                .ForMember(x => x.WebsiteLinks, opt => opt.MapFrom(o => o.WebsiteLinks));

            CreateMap<Pet, PetViewModel>()
               .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id))
               .ForMember(x => x.PetName, opt => opt.MapFrom(o => o.PetName))
               .ForMember(x => x.Bio, opt => opt.MapFrom(o => o.Bio))
               .ForMember(x => x.Breed, opt => opt.MapFrom(o => o.Breed))
               .ForMember(x => x.Sex, opt => opt.MapFrom(o => o.Sex))
               .ForMember(x => x.Age, opt => opt.MapFrom(o => o.Age))
               .ForMember(x => x.PetWeight, opt => opt.MapFrom(o => o.PetWeight))
               .ForMember(x => x.Color, opt => opt.MapFrom(o => o.Color))  
               .ForMember(x => x.Username, opt => opt.MapFrom(o => o.UserIdFkNavigation.Username))
               .ForMember(x => x.UserId, opt => opt.MapFrom(o => o.UserIdFkNavigation))
               .ForMember(x => x.Location, opt => opt.MapFrom(o => o.LocationIdFkNavigation))
               .ForMember(x => x.Treatments, opt => opt.MapFrom(o => o.Treatments))
               .ForMember(x => x.Vacines, opt => opt.MapFrom(o => o.Vacines));

            CreateMap<Pet, PetLiteViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.PetName, opt => opt.MapFrom(o => o.PetName))
                .ForMember(x => x.Sex, opt => opt.MapFrom(o => o.Sex))
                .ForMember(x => x.PetType, opt => opt.MapFrom(o => o.PetTypeIdFkNavigation.PetType1))
                .ForMember(x => x.Location, opt => opt.MapFrom(o => o.LocationIdFkNavigation));
        }
    }
}
