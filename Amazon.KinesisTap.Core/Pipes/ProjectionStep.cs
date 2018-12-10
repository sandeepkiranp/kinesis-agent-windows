/*
 * Copyright 2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.KinesisTap.Core
{
    /// <summary>
    /// Projection step
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class ProjectionStep<TIn, TOut> : Step<TIn, TOut>
    {
        private readonly Func<TIn, TOut> _project;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="project">The conversion function for the projection</param>
        public ProjectionStep(Func<TIn, TOut> project)
        {
            Guard.ArgumentNotNull(project, "project");
            _project = project;
        }

        public override void OnNext(TIn value)
        {
            if (_next != null)
                _next.OnNext(_project(value));
        }
    }
}
