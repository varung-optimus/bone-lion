using System.Threading.Tasks;
using Abp.Application.Services;
using EarthLink.Roles.Dto;

namespace EarthLink.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
