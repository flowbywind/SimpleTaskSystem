using Abp.Application.Services.Dto;

namespace SimpleTaskSystem.Tasks.Dtos
{
    public class GetTaskInput : IInputDto
    {
        public int id { get; set; }
    }
}
