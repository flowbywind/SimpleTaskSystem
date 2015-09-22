using Abp.Application.Services;
using SimpleTaskSystem.Enum.Dtos;

namespace SimpleTaskSystem.Enum
{
    public interface IEnumAppService : IApplicationService
    {
        //string GetEnumDescription(object e);

        GetEnumsOutput GetSelectList(GetEnumsInput input);
    }
}
