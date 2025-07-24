using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestFluentReturns {
    private static object? CreateDefault(Type type) {
        if (type == typeof(string)) return "test";
        if (type.IsEnum) return Enum.GetValues(type).GetValue(0);
        if (type.IsValueType) return Activator.CreateInstance(type);
        if (type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)) {
            var elementType = type.GetGenericArguments()[0];
            var array = Array.CreateInstance(elementType, 0);
            return array;
        }
        if (typeof(Delegate).IsAssignableFrom(type)) {
            var invoke = type.GetMethod("Invoke")!;
            var parameters = invoke.GetParameters()
                .Select(p => Expression.Parameter(p.ParameterType, p.Name)).ToArray();
            Expression body = invoke.ReturnType == typeof(void)
                ? Expression.Empty()
                : Expression.Default(invoke.ReturnType);
            var lambda = Expression.Lambda(type, body, parameters);
            return lambda.Compile();
        }
        if (type.IsArray) return Array.CreateInstance(type.GetElementType()!, 0);
        var ctor = type.GetConstructor(Type.EmptyTypes);
        if (ctor != null) return Activator.CreateInstance(type);
        try {
            return RuntimeHelpers.GetUninitializedObject(type);
        } catch {
            return null;
        }
    }

    private static object?[] GetConstructorDefaults(ConstructorInfo ctor) {
        var parameters = ctor.GetParameters();
        var args = new object?[parameters.Length];
        for (int i = 0; i < parameters.Length; i++) {
            args[i] = parameters[i].HasDefaultValue ? parameters[i].DefaultValue : CreateDefault(parameters[i].ParameterType);
        }
        return args;
    }

    private static object?[] GetMethodDefaults(MethodInfo method) {
        var parameters = method.GetParameters();
        var args = new object?[parameters.Length];
        for (int i = 0; i < parameters.Length; i++) {
            var p = parameters[i];
            args[i] = p.HasDefaultValue ? p.DefaultValue : CreateDefault(p.ParameterType);
        }
        return args;
    }

    private static void AssertFluentMethods(Type type) {
        var ctor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
            .OrderBy(c => c.GetParameters().Length).FirstOrDefault();
        if (ctor == null) {
            return; // cannot instantiate type
        }
        var instance = ctor.Invoke(GetConstructorDefaults(ctor));
        foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)) {
            if (method.IsSpecialName) continue;
            if (method.DeclaringType != type) continue;
            if (method.ReturnType != type) continue;
            var parameters = GetMethodDefaults(method);
            try {
                var result = method.Invoke(instance, parameters);
                Assert.AreSame(instance, result, $"{type.Name}.{method.Name} should return the instance for chaining");
            } catch (TargetInvocationException) {
                // Skip methods that throw due to invalid default parameters
            }
        }
    }

    [TestMethod]
    public void VisNetwork_FluentMethods_ReturnSelf() {
        AssertFluentMethods(typeof(HtmlForgeX.VisNetwork));
    }

    [TestMethod]
    public void Tabler_FluentMethods_ReturnSelf() {
        var assembly = typeof(TablerTag).Assembly;
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && !t.IsSealed && t.Name.StartsWith("Tabler"));
        foreach (var type in types) {
            AssertFluentMethods(type);
        }
    }
}