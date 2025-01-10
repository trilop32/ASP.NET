using AutoMapper;
using System.Reflection;

namespace Teledok.Application.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

        IMapWith<object> mapWith;
        var nameMethodMapping = nameof(mapWith.Mapping);

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(nameMethodMapping);
            methodInfo?.Invoke(instance, [this]);
        }
    }
}