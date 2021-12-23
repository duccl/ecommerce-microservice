using MediatR;

namespace Microservices.Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery: IRequest<IEnumerable<OrderVm>>
    {
        #region .: Properties :.

        public string Username { get; set; }

        #endregion

        #region .: Constructor :.

        public GetOrdersListQuery(string username)
        {
            Username = username;
        }

        #endregion
    }
}
