using FreshMarket.Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderSummary;

public sealed record GetOrderSummaryQuery(Guid OrderId) : IRequest<OrderSummary?>;