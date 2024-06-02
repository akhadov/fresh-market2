using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Domain.Common.Base;
public abstract class Entity<TId> : AuditableEntity
{
    public TId Id { get; set; } = default!;
}
