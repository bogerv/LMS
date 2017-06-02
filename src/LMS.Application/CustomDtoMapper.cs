using AutoMapper;
using LMS.Authorization.Users;
using LMS.Authorization.Users.Dtos;

namespace LMS.Application
{
    internal static class CustomDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        public static void CreateMappings(IMapperConfigurationExpression mapper)
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(mapper);

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<User, UserListDto>()
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
        }
    }
}
