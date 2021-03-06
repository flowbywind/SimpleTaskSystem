﻿using System.Collections.Generic;
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
    public class UpdateTaskStateInput : IInputDto, ICustomValidate
    {
        [Range(1, long.MaxValue)] //Data annotation attributes work as expected.
        public int Id { get; set; }

        public int? AssignedPersonId { get; set; }

        public TaskState? taskState { get; set; }

        //Custom validation method. It's called by ABP after data annotation validations.
        public void AddValidationErrors(List<ValidationResult> results)
        {
            if (AssignedPersonId == null && taskState == null)
            {
                results.Add(new ValidationResult("Both of AssignedPersonId and State can not be null in order to update a Task!", new[] { "AssignedPersonId", "State" }));
            }
        }

        public override string ToString()
        {
            return string.Format("[UpdateTaskStateInput > TaskId = {0}, AssignedPersonId = {1}, TaskState = {2}]", Id, AssignedPersonId, taskState);
        }
    }
}
