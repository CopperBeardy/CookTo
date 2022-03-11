﻿namespace CookTo.Client.Managers.Shared;

public static class HttpClientFactoryHelper
{
    public static HttpClient CreateClient(IHttpClientFactory factory, HttpClientType type)
    {
        if(type == HttpClientType.Anon)
        {
            return factory.CreateClient("CookTo.ServerAPIAnonymous");
        } else
        {
            return factory.CreateClient("CookTo.ServerAPI");
        }
    }
}