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
                .ForMember(x => x.Number, opt => opt.MapFrom(o => o.LocationIdFkNavigation.Number))
                .ForMember(x => x.Street, opt => opt.MapFrom(o => o.LocationIdFkNavigation.Street))
                .ForMember(x => x.City, opt => opt.MapFrom(o => o.LocationIdFkNavigation.City))
                .ForMember(x => x.State, opt => opt.MapFrom(o => o.LocationIdFkNavigation.State));

            CreateMap<Pet, PetViewModel>()
               .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id))
               .ForMember(x => x.Name, opt => opt.MapFrom(o => o.PetName))
               .ForMember(x => x.Bio, opt => opt.MapFrom(o => o.Bio))
               .ForMember(x => x.Breed, opt => opt.MapFrom(o => o.BreedIdFkNavigation.Breed1))
               .ForMember(x => x.Sex, opt => opt.MapFrom(o => o.Sex))
               .ForMember(x => x.Age, opt => opt.MapFrom(o => o.Age))
               .ForMember(x => x.Weight, opt => opt.MapFrom(o => o.PetWeight))
               .ForMember(x => x.Color, opt => opt.MapFrom(o => o.ColorIdFk))
               .ForMember(x => x.Is_adopted, opt => opt.MapFrom(o => o.IsAdopted))
               .ForMember(x => x.PetType, opt => opt.MapFrom(o => o.PetTypeIdFkNavigation.PetType1))
               .ForMember(x => x.Username, opt => opt.MapFrom(o => o.UserIdFkNavigation.Username))
               .ForMember(x => x.UserId, opt => opt.MapFrom(o => o.UserIdFk))
               .ForMember(x => x.Number, opt => opt.MapFrom(o => o.LocationIdFkNavigation.Number))
               .ForMember(x => x.Street, opt => opt.MapFrom(o => o.LocationIdFkNavigation.Street))
               .ForMember(x => x.City, opt => opt.MapFrom(o => o.LocationIdFkNavigation.City))
               .ForMember(x => x.State, opt => opt.MapFrom(o => o.LocationIdFkNavigation.State))
               .ForMember(x => x.Timestamps, opt => opt.MapFrom(o => o.Timestamps));

            CreateMap<Pet, PetDates>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(x => x.petCreation, opt => opt.MapFrom(o => o.Timestamps));
        }
    }
}
