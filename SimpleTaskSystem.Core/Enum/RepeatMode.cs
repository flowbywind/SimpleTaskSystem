using Utility;

namespace SimpleTaskSystem.Enum
{
    public enum RepeatMode : byte
    {
        /// <summary>
        /// 天
        /// </summary>
        [EnumDisplayName("按天")]
        Day = 1,
        /// <summary>
        /// 周
        /// </summary>
        [EnumDisplayName("按周")]
        Week = 2,
        ///// <summary>
        ///// 工作日
        ///// </summary>
        //[EnumDisplayName("工作日")]
        //Weekdays = 3,
        /// <summary>
        /// 月
        /// </summary>
        [EnumDisplayName("按月")]
        Month = 4,
        /// <summary>
        /// 年
        /// </summary>
        [EnumDisplayName("按年")]
        Year = 5

    }
}
