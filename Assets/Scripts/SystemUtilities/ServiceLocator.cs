using System;
using System.Collections.Generic;

public class ServiceLocator
{
    public static ServiceLocator Instance => instance ?? (instance = new ServiceLocator());
    private static ServiceLocator instance;

    private readonly Dictionary<Type, object> services;

    public ServiceLocator()
    {
        services = new Dictionary<Type, object>();
    }

    public void RegisterService<T>(T service)
    {
        Type type = typeof(T);

        if (!services.ContainsKey(type) && !services.ContainsValue(service))
            services.Add(type, service);
    }

    public T GetService<T>()
    {
        Type type = typeof(T);
        if (!services.TryGetValue(type, out var service))
        {
            throw new Exception($"Service {type} not found");
        }

        return (T)service;
    }
}