using Utility;

namespace SimpleTaskSystem.Enum
{
    /// <summary>
    /// Possible states of a <see cref="Task"/>.
    /// </summary>
    public enum TaskLevel : byte
    {
        /// <summary>
        /// 无
        /// </summary>
        [EnumDisplayName("无")]
        None = 0,
        /// <summary>
        /// 低
        /// </summary>
        [EnumDisplayName("低")]
        Lower = 1,
        /// <summary>
        /// 中
        /// </summary>
        [EnumDisplayName("中")]
        Medium = 2,
        /// <summary>
        /// 高
        /// </summary>
        [EnumDisplayName("高")]
        Top = 3
    }
}
