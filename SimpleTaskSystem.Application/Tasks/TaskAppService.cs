using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks.Dtos;
using System;

namespace SimpleTaskSystem.Tasks
{
    /// <summary>
    /// Implements <see cref="ITaskAppService"/> to perform task related application functionality.
    /// 
    /// Inherits from <see cref="ApplicationService"/>.
    /// <see cref="ApplicationService"/> contains some basic functionality common for application services (such as logging and localization).
    /// </summary>
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        //These members set in constructor using constructor injection.

        private readonly ITaskRepository _taskRepository;
        private readonly IRepository<Person> _personRepository;

        /// <summary>
        ///In constructor, we can get needed classes/interfaces.
        ///They are sent here by dependency injection system automatically.
        /// </summary>
        public TaskAppService(ITaskRepository taskRepository, IRepository<Person> personRepository)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            //Called specific GetAllWithPeople method of task repository.
            var tasks = _taskRepository.GetAllWithPeople(input.AssignedPersonId, input.TaskState);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTasksOutput
                   {
                       Tasks = Mapper.Map<List<TaskDto>>(tasks)
                   };
        }

        public void UpdateTaskState(UpdateTaskStateInput input)
        {
            //We can use Logger, it's defined in ApplicationService base class.
            Logger.Info("Updating a task for input: " + input);

            //Retrieving a task entity with given id using standard Get method of repositories.
            var task = _taskRepository.Get(input.Id);

            //Updating changed properties of the retrieved task entity.

            if (input.taskState.HasValue)
            {
                task.TaskState = input.taskState.Value;
            }

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = _personRepository.Load(input.AssignedPersonId.Value);
            }
            //_taskRepository.Update(task);
            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }

        public void CreateTask(CreateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            var task = Mapper.Map<Task>(input);

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = _personRepository.Load(input.AssignedPersonId.Value);
            }

            //Saving entity with standard Insert method of repositories.
            _taskRepository.Insert(task);
        }

        public TaskDto GetTaskById(GetTaskInput input)
        {
            var task = _taskRepository.Get(input.id);
            return Mapper.Map<TaskDto>(task);
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Updating a task for input: " + input);
            var task = _taskRepository.Get(input.Id);
            task.Title = input.Title;
            task.Description = input.Description;
            task.TaskState = input.TaskState;
            task.ModifyTime = DateTime.Now;
            task.ModifyUserID = input.ModifyUserID;
            task.BeginTime = input.BeginTime;
            task.EndTime = input.EndTime;
            task.TaskLevel = input.TaskLevel;
            task.TaskCategory = input.TaskCategory;
            task.RepeatMode = input.RepeatMode;
            task.Frequency = input.Frequency;
            task.RepeatDays = input.RepeatDays;
            task.RepeatType = input.RepeatType;
            task.RemindType = input.RemindType;
            task.RemindTime = input.RemindTime;
            task.ModifyUserID = input.ModifyUserID;
            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = _personRepository.Load(input.AssignedPersonId.Value);
            }
        }
    }
}