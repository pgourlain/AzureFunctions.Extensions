﻿#if NET461
using System.Net.Http;
#endif

using System.Reflection;
using System.Threading.Tasks;

#if NETSTANDARD2_0
using Microsoft.AspNetCore.Http;
#endif

using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json.Serialization;

namespace Aliencube.AzureFunctions.Extensions.OpenApi.Abstractions
{
    /// <summary>
    /// This provides interfaces to the <see cref="Document"/> class.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Initializes the document instance.
        /// </summary>
        /// <returns><see cref="IDocument"/> instance.</returns>
        IDocument InitialiseDocument();

        /// <summary>
        /// Adds metadata to build Open API document.
        /// </summary>
        /// <param name="info"><see cref="OpenApiInfo"/> instance.</param>
        /// <returns><see cref="IDocument"/> instance.</returns>
        IDocument AddMetadata(OpenApiInfo info);

#if NET461
        /// <summary>
        /// Adds server details.
        /// </summary>
        /// <param name="req"><see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="routePrefix">Route prefix value.</param>
        /// <returns><see cref="IDocument"/> instance.</returns>
        IDocument AddServer(HttpRequestMessage req, string routePrefix);
#elif NETSTANDARD2_0
        /// <summary>
        /// Adds server details.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="routePrefix">Route prefix value.</param>
        /// <returns><see cref="IDocument"/> instance.</returns>
        IDocument AddServer(HttpRequest req, string routePrefix);
#endif
        /// <summary>
        /// Builds Open API document.
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/> instance.</param>
        /// <param name="namingStrategy"><see cref="NamingStrategy"/> insance to create the JSON schema from .NET Types.</param>
        /// <returns><see cref="IDocument"/> instance.</returns>
        IDocument Build(Assembly assembly, NamingStrategy namingStrategy = null);

        /// <summary>
        /// Renders Open API document.
        /// </summary>
        /// <param name="version"><see cref="OpenApiSpecVersion"/> value.</param>
        /// <param name="format"><see cref="OpenApiFormat"/> value.</param>
        /// <returns>Serialised Open API document.</returns>
        Task<string> RenderAsync(OpenApiSpecVersion version, OpenApiFormat format);
    }
}