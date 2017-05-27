using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace LMS.Base
{
    public class EntityBase : FullAuditedEntity<Guid>
    {
    }
}
