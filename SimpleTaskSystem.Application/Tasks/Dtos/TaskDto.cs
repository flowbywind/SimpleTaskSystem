using System;
using Abp.Application.Services.Dto;

namespace SimpleTaskSystem.Tasks.Dtos
{
    /// <summary>
    /// A DTO class that can be used in various application service methods when needed to send/receive Task objects.
    /// </summary>
    public class TaskDto : EntityDto<int>
    {
        public int? AssignedPersonId { get; set; }

        public string AssignedPersonName { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int CreationUserID { get; set; }

        public DateTime CreationTime { get; set; }

        public byte TaskState { get; set; }

        public DateTime ModifyTime { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public byte TaskLevel { get; set; }
        public byte TaskCategory { get; set; }
        public byte RepeatMode { get; set; }
        public int Frequency { get; set; }
        public string RepeatDays { get; set; }
        public byte RepeatType { get; set; }
        public byte RemindType { get; set; }
        public string RemindTime { get; set; }
    }
}