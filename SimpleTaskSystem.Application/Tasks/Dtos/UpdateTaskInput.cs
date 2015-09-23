using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using SimpleTaskSystem.Enum;

namespace SimpleTaskSystem.Tasks.Dtos
{
    /// <summary>
    /// This DTO class is used to send needed data to <see cref="ITaskAppService.UpdateTask"/> method.
    /// 
    /// Implements <see cref="IInputDto"/>, thus ABP applies standard input process (like automatic validation) for it. 
    /// Implements <see cref="ICustomValidate"/> for additional custom validation.
    /// </summary>
    public class UpdateTaskInput : IInputDto, ICustomValidate
    {
        [Range(1, long.MaxValue)] //Data annotation attributes work as expected.
        public int Id { get; set; }

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

        public TaskState TaskState { get; set; }

        public int ModifyUserID { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TaskLevel TaskLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TaskCategory TaskCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RepeatMode RepeatMode { get; set; }
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
        //[Required]
        public string RemindTime { get; set; }

        //Custom validation method. It's called by ABP after data annotation validations.
        public void AddValidationErrors(List<ValidationResult> results)
        {
            if (AssignedPersonId == null)
            {
                results.Add(new ValidationResult("Both of AssignedPersonId and State can not be null in order to update a Task!", new[] { "AssignedPersonId", "State" }));
            }
        }

        public override string ToString()
        {
            return string.Format("[UpdateTaskInput > TaskId = {0}, AssignedPersonId = {1}, TaskState = {2}]", Id, AssignedPersonId, TaskState);
        }
    }
}
