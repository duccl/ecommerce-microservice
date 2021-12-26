using AutoMapper;

namespace Microservices.Basket.Application.Mappings
{
    public class ApplicationMappingProfile: Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Domain.Entities.BasketCheckout, EventBus.Messages.BasketCheckoutEvent>().ReverseMap();
            CreateMap<Domain.Entities.Address, EventBus.Messages.Address>().ReverseMap();
            CreateMap<Domain.Entities.Payment, EventBus.Messages.Payment>().ReverseMap();
        }
    }
}
