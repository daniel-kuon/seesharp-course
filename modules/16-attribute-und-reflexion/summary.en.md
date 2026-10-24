# Attributes and Reflection

Attributes attach metadata to program elements without modifying their code: a note that is evaluated by the compiler, the runtime, or a tool (Chapter 14, page 921). Reflection is the opposite: a program examines its own types and metadata at runtime. Together, these two concepts form the foundation of serializers, validation, database mappers, and plugin systems. This level is an elective module.

## Assigning Attributes (14.1, page 922)

An attribute is placed in square brackets before a type, method, property, parameter, or return value: `[Obsolete("Bitte Neu() verwenden")]`. The class name ends with `Attribute`; when used, the suffix is omitted. Parameters are either **positional** (constructor) or **named** (`Name = wert`, public writable property). Multiple attributes may be listed one after another or separated by commas; in some cases, the same attribute may even appear multiple times.

## Evaluation Through Reflection (14.2, page 924)

Let's start with a `Type`: The compiler recognizes `typeof(Klasse)`, and `objekt.GetType()` returns the runtime type. `GetCustomAttribute<T>()` and `GetCustomAttributes<T>()` retrieve the attribute objects (which invokes their constructors), while `IsDefined` simply checks whether one exists. `GetProperties()` and `GetMethods()` list the members of a type; `BindingFlags` can be used to filter them (public, instance, static). The same applies to assemblies; the attributes are located there with the Target `assembly:` property set to the top-level (14.3, page 929).

## nameof (14.4, page 933)

`nameof(Person.Alter)` returns the identifier as text, which is validated by the compiler and automatically carried over during renaming. It replaces literals in error messages and change notifications.

## Key Attributes of the Class Library (14.5, pages 934–940)

The optional parameters `[CallerMemberName]` and `[CallerLineNumber]` allow the compiler to insert the name and line number of the calling location (14.5.1). `[Conditional("DEBUG")]` removes **calls** to a void method during compilation if the symbol is missing (14.5.2, page 935). `[DebuggerStepThrough]` keeps the debugger in single-step mode (14.5.3). `[Flags]` converts an enumeration into a bit field whose combinations appear as `Lesen, Schreiben` (14.5.4, page 937). `[StructLayout(LayoutKind.Explicit)]`, when used with `[FieldOffset]`, places fields one above the other like a union in C (14.5.5, page 940).

## Custom Attributes (14.6 through 14.8, pages 940 through 945)

An AttributeClass inherits from `Attribute`. `[AttributeUsage]` specifies the allowed targets (`AttributeTargets`) and whether the attribute may appear multiple times (`AllowMultiple`); Microsoft recommends using `sealed`. The only allowed parameters are constants, text, `typeof` expressions, enum values, and arrays of these. Since C# 11, attributes may be generic (14.7, page 942): `[Implementierung<StandardRechnung>]` instead of `typeof(...)`, including type constraints that the compiler checks. Since C# 10, lambda expressions may carry attributes (14.8, page 945).

## Reflection in Practice

The book shows how an object of a type is only created at runtime: `Activator.CreateInstance(typ)` (14.7.1, page 943). The summary adds two tools: `PropertyInfo.GetValue` and `SetValue` read and write properties by name, `MethodInfo.Invoke` calls methods by name. Exceptions from the invoked code come back as `TargetInvocationException`. Reflection is slower than direct access and bypasses the compiler's type checking; use it where types are really only known at runtime.

## Exercises

The exercises range from library attributes to custom attributes and reading data, all the way to a small mapper and plugin loader. A quiz covers `Conditional`, `[assembly: ...]`, and attribute targets, because this depends on the build and cannot be checked automatically. The optional tasks include: validation via attributes, permissions using `[Flags]`, and a mini-tester.
