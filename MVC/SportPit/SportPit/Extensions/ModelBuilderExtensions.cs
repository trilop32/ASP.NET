using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SportPit.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
    {
        var typesToRegister = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.GetInterfaces()
            .Any(gi => gi.IsGenericType &&
                       gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
            .ToList();

        var configurations = typesToRegister.Select(type =>
                                                Activator.CreateInstance(type)
                                                ?? throw new MemberAccessException("Failed to create an instance of the type"));

        foreach (var configuration in configurations)
        {
            modelBuilder.ApplyConfiguration((dynamic)configuration);
        }
    }
}
