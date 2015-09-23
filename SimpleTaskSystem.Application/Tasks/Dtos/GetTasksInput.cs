using Abp.Application.Services.Dto;
using SimpleTaskSystem.Enum;

namespace SimpleTaskSystem.Tasks.Dtos
{
    public class GetTasksInput : IInputDto
    {
        public TaskState? TaskState { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}