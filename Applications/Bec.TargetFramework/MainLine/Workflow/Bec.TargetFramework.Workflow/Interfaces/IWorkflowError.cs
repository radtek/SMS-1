﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow
{
    public interface IWorkflowError
    {
        Exception WorkflowException { get; set; }

    }
}
