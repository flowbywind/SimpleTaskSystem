using System;
using System.Collections.Generic;
using Abp.Application.Services;
using SimpleTaskSystem.Enum;

namespace SimpleTaskSystem.Enum
{
    interface IEnumAppService : IApplicationService
    {
        string GetEnumDescription(object e);

        string GetSelectList(Type enumType);
    }
}
