using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using SimpleTaskSystem.Enum;

namespace SimpleTaskSystem.Tasks.Dtos
{
    public class CreateTaskInput : IInputDto
    {
        public int id { get; set; }
        public int? AssignedPersonId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CreationUserID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ModifyUserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TaskLevel Level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TaskState State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TaskCategory Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RepeatMode Mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Frequency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RepeatDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RepeatType RepeatType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RemindType RemindType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string RemindTime { get; set; }

        public override string ToString()
        {
            return string.Format("[CreateTaskInput > AssignedPersonId = {0}, Description = {1}]", AssignedPersonId, Description);
        }
    }
}