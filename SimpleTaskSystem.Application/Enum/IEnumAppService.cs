using Abp.Application.Services;

namespace SimpleTaskSystem.Enum
{
    public interface IEnumAppService : IApplicationService
    {
        //string GetEnumDescription(object e);

        string GetSelectList();
    }
}
