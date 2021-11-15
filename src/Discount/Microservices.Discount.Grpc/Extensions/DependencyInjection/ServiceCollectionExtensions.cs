using Microservices.Discount.Domain.Entities;
using Microservices.Discount.Grpc.Protos;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Discount.Grpc.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<VoucherContract, Voucher>().ReverseMap();
            });
            return services;
        }
    }
}
