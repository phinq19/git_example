// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNet.Mvc.DataAnnotations.Internal
{
    public static class DataAnnotationsLocalizationServices
    {
        public static void AddDataAnnotationsLocalizationServices(
            IServiceCollection services,
            Action<MvcDataAnnotationsLocalizationOptions> setupAction)
        {
            services.AddLocalization();

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }
            else
            {
                services.TryAddEnumerable(
                    ServiceDescriptor.Transient
                    <IConfigureOptions<MvcDataAnnotationsLocalizationOptions>,
                    MvcDataAnnotationsLocalizationOptionsSetup>());
            }
        }
    }
}
