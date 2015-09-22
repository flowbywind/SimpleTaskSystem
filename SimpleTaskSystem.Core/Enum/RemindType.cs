using Utility;

namespace SimpleTaskSystem.Enum
{
    public enum RemindType : byte
    {
        /// <summary>
        /// 分钟
        /// </summary>
        [EnumDisplayName("分钟")]
        Minute = 1,
        /// <summary>
        /// 小时
        /// </summary>
        [EnumDisplayName("小时")]
        Hour = 2,
        /// <summary>
        /// 天
        /// </summary>
        [EnumDisplayName("天")]
        Day = 3,
        /// <summary>
        /// 具体时间
        /// </summary>
        [EnumDisplayName("具体时间")]
        Specific = 4
    }
}
