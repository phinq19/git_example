﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.AspNet.Mvc.FunctionalTests
{
    public class SimpleTests : IClassFixture<MvcTestFixture<SimpleWebSite.Startup>>
    {
        public SimpleTests(MvcTestFixture<SimpleWebSite.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task JsonSerializeFormated()
        {
            // Arrange
            var expected = "{" + Environment.NewLine
                 + "  \"first\": \"wall\"," + Environment.NewLine
                 + "  \"second\": \"floor\"" + Environment.NewLine
                 + "}";

            // Act
            var content = await Client.GetStringAsync("http://localhost/Home/Index");

            // Assert
            Assert.Equal(expected, content);
        }
    }
}
