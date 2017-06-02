using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using LMS.Authorization.Roles;

namespace LMS.Roles
{
    [AutoMapFrom(typeof(Role))]
    public class RoleListDto : EntityDto<Guid>, IHasCreationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
