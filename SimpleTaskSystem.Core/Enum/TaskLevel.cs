
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
        None = 0,
        /// <summary>
        /// 低
        /// </summary>
        Lower = 1,
        /// <summary>
        /// 中
        /// </summary>
        Medium = 2,
        /// <summary>
        /// 高
        /// </summary>
        Top = 3
    }
}
