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
    /// There are no comments for Bec.TargetFramework.Data.Analysis.AnalysisMutatorInput in the schema.
    /// </summary>
    public partial class AnalysisMutatorInput    {

        public AnalysisMutatorInput()
        {
          this.AnalysisMutatorVersionNumber = 0;
          this.AnalysisInputVersionNumber = 0;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for AnalysisMutatorID in the schema.
        /// </summary>
        public virtual global::System.Guid AnalysisMutatorID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisMutatorVersionNumber in the schema.
        /// </summary>
        public virtual int AnalysisMutatorVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisInputID in the schema.
        /// </summary>
        public virtual global::System.Guid AnalysisInputID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AnalysisInputVersionNumber in the schema.
        /// </summary>
        public virtual int AnalysisInputVersionNumber
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
