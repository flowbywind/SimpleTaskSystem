using SimpleTaskSystem.Tasks;
using Utility;

namespace SimpleTaskSystem.Enum
{
    /// <summary>
    /// Possible states of a <see cref="Task"/>.
    /// </summary>
    public enum TaskState : byte
    {
        /// <summary>
        /// The task is active.
        /// </summary>
        [EnumDisplayName("进行中")]
        Active = 1,

        /// <summary>
        /// The task is completed.
        /// </summary>
        [EnumDisplayName("已完成")]
        Completed = 2
    }
}