﻿using Mastodon.Models;
using System.Net.Http.Json;

namespace Mastodon.Client;

public sealed class InstanceClient
{
    private readonly MastodonClient _client;

    internal InstanceClient(MastodonClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Obtain general information about the server.
    /// </summary>
    public Task<Response<InstanceV1>> GetInstanceV1Async()
    {
        return _client.HttpClient.GetFromJsonWithHeadersAsync<InstanceV1>("api/v1/instance", MastodonClient._options);
    }

    /// <summary>
    /// Obtain general information about the server.
    /// </summary>
    public Task<Instance?> GetInstanceAsync()
    {
        return _client.HttpClient.GetFromJsonAsync<Instance>("api/v2/instance", MastodonClient._options);
    }

    /// <summary>
    /// Domains that this instance is aware of.
    /// </summary>
    public Task<List<string>?> GetConnectedDomainsAsync()
    {
        return _client.HttpClient.GetFromJsonAsync<List<string>>("api/v1/instance/peers", MastodonClient._options);
    }

    public Task<List<Activity>?> GetActivitiesAsync()
    {
        return _client.HttpClient.GetFromJsonAsync<List<Activity>>("api/v1/instance/activity", MastodonClient._options);
    }


    /// <summary>
    /// Rules that the users of this service should follow.
    /// </summary>
    public Task<List<Rule>?> GetRulesAsync()
    {
        return _client.HttpClient.GetFromJsonAsync<List<Rule>>("api/v1/instance/rules", MastodonClient._options);
    }


    /// <summary>
    /// Obtain an extended description of this server.
    /// </summary>
    public Task<ExtendedDescription?> GetExtendedDescriptionAsync()
    {
        return _client.HttpClient.GetFromJsonAsync<ExtendedDescription>("api/v1/instance/extended_description", MastodonClient._options);
    }

    /// <summary>
    /// Obtain a list of domains that have been blocked.
    /// </summary>
    public Task<List<DomainBlock>?> GetDomainBlocksAsync()
    {
        return _client.HttpClient.GetFromJsonAsync<List<DomainBlock>>("api/v1/instance/domain_block", MastodonClient._options);
    }
}

