
using Utility;

namespace SimpleTaskSystem.Enum
{
    public enum TaskCategory : byte
    {
        /// <summary>
        /// 正常任务
        /// </summary>
        [EnumDisplayName("正常")]
        Normal = 1,

        /// <summary>
        /// 重复任务
        /// </summary>
        [EnumDisplayName("重复")]
        Repeat = 2
    }
}
