using AutoMapper;
using Grpc.Core;
using Microservices.Discount.Domain.Entities;
using Microservices.Discount.Domain.Interfaces.Repositories;
using Microservices.Discount.Grpc.Protos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Microservices.Discount.Grpc.Services
{
    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        #region .: Properties :.

        private readonly ILogger<DiscountService> _logger;
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        #endregion

        #region .: Constructor :.

        public DiscountService(ILogger<DiscountService> logger, IDiscountRepository discountRepository, IMapper mapper)
        {
            _logger = logger;
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        #endregion

        #region  .: Grpc Methods :.

        public override async Task<CreateDiscountResponse> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Received: {context}");
            var success = await _discountRepository.CreateVoucher(
                _mapper.Map<Voucher>(request.VoucherToCreate)
            );

            return new CreateDiscountResponse { 
                Success = success
            };
        }

        public override async Task<VoucherContract> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            return _mapper.Map<VoucherContract>(await _discountRepository.GetVoucher(request.ProductName));
        }

        public override async Task<UpdateDiscountResponse> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Received: {context}");
            var isVoucherCreated = await _discountRepository.CreateVoucher(_mapper.Map<Voucher>(request.VoucherToUpdate));
            return new UpdateDiscountResponse
            {
                Success = isVoucherCreated
            };
        }

        public override async Task<DeleteVoucherResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var isVoucherDeleted = await _discountRepository.DeleteVoucher(request.ProductName);
            return new DeleteVoucherResponse
            {
                Success = isVoucherDeleted
            };
        }
        #endregion
    }
}
