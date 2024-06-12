using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrder;

public sealed record LineItemResponse(Guid LineItemId, decimal Price);