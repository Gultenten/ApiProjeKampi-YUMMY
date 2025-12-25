using ApiProjeKampi_YUMMY.WebApi.Dtos.AboutDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.CategoryDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.GroupReservationDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.ImageDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.MessageDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.NotificationDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.ProductDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.ReservationDtos;
using ApiProjeKampi_YUMMY.WebApi.Entities;
using AutoMapper;
using AutoMapper.Features;

namespace ApiProjeKampi_YUMMY.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();



            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x=>x.CategoryName,y=>y.MapFrom(z=>z.Category.CategoryName)).ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();


            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutByIdDto>().ReverseMap();


            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetReservationByIdDto>().ReverseMap();

            CreateMap<Image, CreateImageDto>().ReverseMap();
            CreateMap<Image, ResultImageDto>().ReverseMap();
            CreateMap<Image, UpdateImageDto>().ReverseMap();
            CreateMap<Image, GetImageByIdDto>().ReverseMap();

            CreateMap<GroupReservation, CreateGroupReservationDto>().ReverseMap();
            CreateMap<GroupReservation, ResultGroupReservationDto>().ReverseMap();
            CreateMap<GroupReservation, UpdateGroupReservationDto>().ReverseMap();
            CreateMap<GroupReservation, GetByIdGroupReservationDto>().ReverseMap();

        }
    }
}
