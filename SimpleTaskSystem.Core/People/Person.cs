﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SimpleTaskSystem.People
{
    /// <summary>
    /// Represents a Person entity.
    /// 
    /// It inherits from <see cref="Entity"/> class (Optionally can implement <see cref="IEntity"/> directly).
    /// </summary>
    [Table("StsPeople")]
    public class Person : Entity<int>
    {
        /// <summary>
        /// A property (database field) for a Person to store his/her name.
        /// NOTE: NHibernate requires that all members of an entity must be virtual (for proxying purposes)!
        /// </summary>
        [MaxLength(50)]
        public virtual string Name { get; set; }
    }
}