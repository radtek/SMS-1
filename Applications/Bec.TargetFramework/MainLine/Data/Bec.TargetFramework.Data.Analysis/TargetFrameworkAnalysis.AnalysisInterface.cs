﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/5/2015 2:37:37 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data.Analysis
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.Analysis.AnalysisInterface in the schema.
    /// </summary>
    public partial class AnalysisInterface    {

        public AnalysisInterface()
        {
          this.AnalysisInterfaceVersionNumber = 0;
          this.IsActive = true;
          this.IsDeleted = false;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for AnalysisInterfaceID in the schema.
        /// </summary>
        public virtual global::System.Guid AnalysisInterfaceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisInterfaceVersionNumber in the schema.
        /// </summary>
        public virtual int AnalysisInterfaceVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisInterfaceTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisInterfaceTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisInterfaceCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisInterfaceCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectName in the schema.
        /// </summary>
        public virtual string ObjectName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectAssembly in the schema.
        /// </summary>
        public virtual string ObjectAssembly
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchSchedulerID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AnalysisBatchSchedulerID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchSchedulerVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisBatchSchedulerVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchReceiverID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AnalysisBatchReceiverID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchReceiverVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisBatchReceiverVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchProcessorID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AnalysisBatchProcessorID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchProcessorVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisBatchProcessorVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisEngineID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AnalysisEngineID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisEngineVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisEngineVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchCollatorID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AnalysisBatchCollatorID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchCollatorVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisBatchCollatorVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchSenderID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AnalysisBatchSenderID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisBatchSenderVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AnalysisBatchSenderVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for AnalysisProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<AnalysisProcessLog> AnalysisProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AnalysisBatchScheduler in the schema.
        /// </summary>
        public virtual AnalysisBatchScheduler AnalysisBatchScheduler
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AnalysisBatchReceiver in the schema.
        /// </summary>
        public virtual AnalysisBatchReceiver AnalysisBatchReceiver
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AnalysisBatchProcessor in the schema.
        /// </summary>
        public virtual AnalysisBatchProcessor AnalysisBatchProcessor
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AnalysisEngine in the schema.
        /// </summary>
        public virtual AnalysisEngine AnalysisEngine
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AnalysisBatchCollator in the schema.
        /// </summary>
        public virtual AnalysisBatchCollator AnalysisBatchCollator
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AnalysisBatchSender in the schema.
        /// </summary>
        public virtual AnalysisBatchSender AnalysisBatchSender
        {
            get;
            set;
        }

        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
