using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Enum;

namespace SimpleTaskSystem.Tasks
{
    /// <summary>
    /// Represents a Task entity.
    /// 
    /// Inherits from <see cref="Entity{TPrimaryKey}"/> class (Optionally can implement <see cref="IEntity{TPrimaryKey}"/> directly).
    /// 
    /// An Entity's primary key is assumed as <see cref="int"/> as default.
    /// If it's different, we must declare it as generic parameter (as done here for <see cref="long"/>).
    /// 
    /// Implements <see cref="IHasCreationTime"/>, thus ABP sets CreationTime automatically while saving to database.
    /// Also, this helps us to use standard naming and functionality for 'creation time' of entities.
    /// </summary>
    [Table("StsTasks")]
    public class Task : Entity, IHasCreationTime
    {
        /// <summary>
        /// A reference (navigation property) to assigned <see cref="Person"/> for this task.
        /// We declare <see cref="ForeignKeyAttribute"/> for EntityFramework here. No need for NHibernate.
        /// </summary>
        [ForeignKey("AssignedPersonId")]
        public virtual Person AssignedPerson { get; set; }

        /// <summary>
        /// Database field for AssignedPerson reference.
        /// Needed for EntityFramework, no need for NHibernate.
        /// </summary>
        public virtual int? AssignedPersonId { get; set; }

        /// <summary>
        /// The title of the task
        /// <remarks>创建人员(日期):★刘建★(150916 16:21)</remarks>
        /// </summary>
        [MaxLength(50)]
        public virtual string Title { get; set; }

        /// <summary>
        /// Describes the task.
        /// </summary>
        [MaxLength(200)]
        public virtual string Description { get; set; }

        /// <summary>
        /// The time when this task is created.
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// CreationUserID
        /// <remarks>创建人员(日期):★刘建★(150916 16:30)</remarks>
        /// </summary>
        public virtual int CreationUserID { get; set; }

        /// <summary>
        /// the time when this task modify
        /// <remarks>创建人员(日期):★刘建★(150916 16:29)</remarks>
        /// </summary>
        public virtual DateTime ModifyTime { get; set; }

        /// <summary>
        /// CreationUserID
        /// <remarks>创建人员(日期):★刘建★(150916 16:30)</remarks>
        /// </summary>
        public virtual int ModifyUserID { get; set; }

        /// <summary>
        /// The time when this task begin
        /// <remarks>创建人员(日期):★刘建★(150916 16:27)</remarks>
        /// </summary>
        public virtual DateTime BeginTime { get; set; }

        /// <summary>
        /// the time when this task end
        /// <remarks>创建人员(日期):★刘建★(150916 16:27)</remarks>
        /// </summary>
        public virtual DateTime EndTime { get; set; }

        /// <summary>
        /// 任务级别
        /// </summary>
        public virtual TaskLevel TaskLevel { get; set; }

        /// <summary>
        /// Current state of the task.
        /// </summary>
        public virtual TaskState TaskState { get; set; }

        /// <summary>
        /// 任务类别
        /// </summary>
        public virtual TaskCategory TaskCategory { get; set; }

        /// <summary>
        /// 重复模式
        /// </summary>
        public virtual RepeatMode RepeatMode { get; set; }

        /// <summary>
        /// 频率
        /// </summary>
        public virtual int Frequency { get; set; }

        /// <summary>
        /// 重复日
        /// </summary>
        [MaxLength(50)]
        public virtual string RepeatDays { get; set; }

        /// <summary>
        /// 按月时分重复方式
        /// </summary>
        public virtual RepeatType RepeatType { get; set; }
        /// <summary>
        /// 提醒方式
        /// </summary>
        public virtual RemindType RemindType { get; set; }

        /// <summary>
        /// 提醒时间，提前时间，或者提醒具体时间
        /// </summary>
        [MaxLength(50)]
        public virtual string RemindTime { get; set; }

        /// <summary>
        /// Default costructor.
        /// Assigns some default values to properties.
        /// </summary>
        public Task()
        {
            CreationTime = DateTime.Now;
            TaskState = TaskState.Active;
            TaskLevel = TaskLevel.None;
            TaskCategory = TaskCategory.Normal;
            RepeatType = RepeatType.Zero;
            RemindType = RemindType.Minute;
        }
    }
}
