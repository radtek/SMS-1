﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 29/04/2015 12:05:02
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

namespace Bec.TargetFramework.SB.Data
{
    public partial class TargetFrameworkCoreEntities : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initialize a new TargetFrameworkCoreEntities object.
        /// </summary>
        public TargetFrameworkCoreEntities() :
                base(@"name=TargetFrameworkCoreEntitiesConnectionString")
        {
            Configure();
        }

        /// <summary>
        /// Initializes a new TargetFrameworkCoreEntities object using the connection string found in the 'TargetFrameworkCoreEntities' section of the application configuration file.
        /// </summary>
        public TargetFrameworkCoreEntities(string nameOrConnectionString) :
                base(nameOrConnectionString)
        {
            Configure();
        }

        private void Configure()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            throw new UnintentionalCodeFirstException();
        }

    
        /// <summary>
        /// There are no comments for BusTaskHandler in the schema.
        /// </summary>
        public virtual DbSet<BusTaskHandler> BusTaskHandlers { get; set; }
    
        /// <summary>
        /// There are no comments for BusTask in the schema.
        /// </summary>
        public virtual DbSet<BusTask> BusTasks { get; set; }
    
        /// <summary>
        /// There are no comments for BusMessage in the schema.
        /// </summary>
        public virtual DbSet<BusMessage> BusMessages { get; set; }
    
        /// <summary>
        /// There are no comments for BusTaskSchedule in the schema.
        /// </summary>
        public virtual DbSet<BusTaskSchedule> BusTaskSchedules { get; set; }
    
        /// <summary>
        /// There are no comments for StatusTypeTemplate in the schema.
        /// </summary>
        public virtual DbSet<StatusTypeTemplate> StatusTypeTemplates { get; set; }
    
        /// <summary>
        /// There are no comments for StatusType in the schema.
        /// </summary>
        public virtual DbSet<StatusType> StatusTypes { get; set; }
    
        /// <summary>
        /// There are no comments for BusMessageProcessLog in the schema.
        /// </summary>
        public virtual DbSet<BusMessageProcessLog> BusMessageProcessLogs { get; set; }
    
        /// <summary>
        /// There are no comments for StatusTypeValueTemplate in the schema.
        /// </summary>
        public virtual DbSet<StatusTypeValueTemplate> StatusTypeValueTemplates { get; set; }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTemplate in the schema.
        /// </summary>
        public virtual DbSet<StatusTypeStructureTemplate> StatusTypeStructureTemplates { get; set; }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransitionTemplate in the schema.
        /// </summary>
        public virtual DbSet<StatusTypeStructureTransitionTemplate> StatusTypeStructureTransitionTemplates { get; set; }
    
        /// <summary>
        /// There are no comments for StatusTypeStructure in the schema.
        /// </summary>
        public virtual DbSet<StatusTypeStructure> StatusTypeStructures { get; set; }
    
        /// <summary>
        /// There are no comments for StatusTypeStructureTransition in the schema.
        /// </summary>
        public virtual DbSet<StatusTypeStructureTransition> StatusTypeStructureTransitions { get; set; }
    
        /// <summary>
        /// There are no comments for StatusTypeValue in the schema.
        /// </summary>
        public virtual DbSet<StatusTypeValue> StatusTypeValues { get; set; }
    
        /// <summary>
        /// There are no comments for BusTaskScheduleProcessLog in the schema.
        /// </summary>
        public virtual DbSet<BusTaskScheduleProcessLog> BusTaskScheduleProcessLogs { get; set; }
    
        /// <summary>
        /// There are no comments for BusEventType in the schema.
        /// </summary>
        public virtual DbSet<BusEventType> BusEventTypes { get; set; }
    
        /// <summary>
        /// There are no comments for BusEvent in the schema.
        /// </summary>
        public virtual DbSet<BusEvent> BusEvents { get; set; }
    
        /// <summary>
        /// There are no comments for BusEventMessageSubscriber in the schema.
        /// </summary>
        public virtual DbSet<BusEventMessageSubscriber> BusEventMessageSubscribers { get; set; }
    
        /// <summary>
        /// There are no comments for BusEventBusEventMessageSubscriber in the schema.
        /// </summary>
        public virtual DbSet<BusEventBusEventMessageSubscriber> BusEventBusEventMessageSubscribers { get; set; }
    
        /// <summary>
        /// There are no comments for ClassificationTypeCategory in the schema.
        /// </summary>
        public virtual DbSet<ClassificationTypeCategory> ClassificationTypeCategories { get; set; }
    
        /// <summary>
        /// There are no comments for ClassificationType in the schema.
        /// </summary>
        public virtual DbSet<ClassificationType> ClassificationTypes { get; set; }
    
        /// <summary>
        /// There are no comments for Setting in the schema.
        /// </summary>
        public virtual DbSet<Setting> Settings { get; set; }
    
        /// <summary>
        /// There are no comments for BusMessageContent in the schema.
        /// </summary>
        public virtual DbSet<BusMessageContent> BusMessageContents { get; set; }
    
        /// <summary>
        /// There are no comments for VStatusType in the schema.
        /// </summary>
        public virtual DbSet<VStatusType> VStatusTypes { get; set; }
    
        /// <summary>
        /// There are no comments for VBusMessageProcessLog in the schema.
        /// </summary>
        public virtual DbSet<VBusMessageProcessLog> VBusMessageProcessLogs { get; set; }
    
        /// <summary>
        /// There are no comments for VBusTaskSchedule in the schema.
        /// </summary>
        public virtual DbSet<VBusTaskSchedule> VBusTaskSchedules { get; set; }
    }
}
