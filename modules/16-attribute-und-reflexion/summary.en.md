# Attributes and Reflection

Attributes attach metadata to program elements without modifying their code: a note that is evaluated by the compiler, the runtime, or a tool (Chapter 14, page 921). Reflection is the counterpart: a program examines its own types and metadata at runtime. Together, these two concepts form the foundation of serializers, validation, database mappers, and plugin systems. This level is an elective module.

## Assigning Attributes (14.1, page 922)

An attribute is placed in square brackets before a type, method, property, parameter, or return value: `[Obsolete("Bitte Neu() verwenden")]`. The class name ends with `Attribute`; when used, the suffix is omitted. Parameters are either **positional** (constructor) or **named** (`Name = wert`, public writable property or public field). Multiple attributes may be listed one after another or separated by commas; in some cases, the same attribute may even appear multiple times.

## Evaluation Through Reflection (14.2, page 924)

The starting point is a `Type`: `typeof(Klasse)` is known to the compiler, `objekt.GetType()` returns the runtime type. `Attribute.GetCustomAttribute(ziel, typeof(XyzAttribute))` and `Attribute.GetCustomAttributes(ziel, false)` retrieve the attribute objects (which invokes their constructors), while `Attribute.IsDefined` simply checks whether one exists. `FindMembers` lists the members of a type as `MemberInfo`; `BindingFlags` filter them (public, instance, static), and without `Public` or `NonPublic` nothing comes back. For shorter forms, see Deep Dive. The same applies to assemblies; their attributes carry the target `assembly:` and stand at the start of any source file, after the using directives and before everything else (14.3, pages 929 to 932).

## nameof (14.4, page 933)

`nameof(Person.Alter)` returns the identifier as text, which is validated by the compiler and automatically carried over during renaming. It replaces literals in error messages and change notifications.

## Key Attributes of the Class Library (14.5, pages 934–940)

`[CallerMemberName]` and `[CallerLineNumber]` on optional parameters let the compiler insert the name and line number of the call site (14.5.1). `[Conditional("DEBUG")]` removes **calls** to a void method during compilation if the symbol is missing (14.5.2, page 935). `[DebuggerStepThrough]` keeps the debugger out of the method when single-stepping (14.5.3). `[Flags]` converts an enumeration into a bit field whose combinations appear as `Lesen, Schreiben` (14.5.4, page 937). `[StructLayout(LayoutKind.Explicit)]`, when used with `[FieldOffset]`, places fields one above the other like a union in C (14.5.5, page 940).

## Custom Attributes (14.6 through 14.8, pages 940 through 945)

An attribute class inherits from `Attribute`. `[AttributeUsage]` specifies the allowed targets (`AttributeTargets`) and whether the attribute may appear multiple times (`AllowMultiple`); Microsoft recommends using `sealed`. The only allowed parameters are constants, text, `typeof` expressions, enum values, and arrays of these. Since C# 11, attributes may be generic (14.7, page 942): `[Implementierung<StandardRechnung>]` instead of `typeof(...)`, including type constraints that the compiler checks. Since C# 10, lambda expressions may carry attributes (14.8, page 945).

## Reflection in Practice

The book shows how an object of a type is only created at runtime: `Activator.CreateInstance(typ)` (14.7.1, page 943); before that, `typeof(IPersistenceHelper).IsAssignableFrom(typ)` checks whether the type fulfils the interface. Frameworks such as Entity Framework Core evaluate attributes this way at runtime (page 921). For reading properties and calling methods via reflection, see Deep Dive.

## Exercises

The exercises range from library attributes to custom attributes and reading them via reflection, all the way to a small plugin loader (mapper and caller as Deep Dive). A quiz covers `Conditional`, `[assembly: ...]`, and attribute targets, because this depends on the build and cannot be checked automatically. The optional tasks include: validation via attributes, permissions using `[Flags]`, and a mini test runner (Deep Dive).

## Deep Dive (optional)

> Not in the book. These topics are optional – examples of what to look into next.

- **Shorter reflection calls:** `type.GetCustomAttribute<T>()` and `GetCustomAttributes<T>()` (namespace `System.Reflection`) save the cast and `typeof`; `member.IsDefined(typeof(T))` asks the `MemberInfo` itself. `GetMethods(BindingFlags)` and `GetProperties()` return `MethodInfo` or `PropertyInfo` objects without `FindMembers`.
- **Values and calls via reflection:** `PropertyInfo.GetValue` and `SetValue` read and write properties by name, `MethodInfo.Invoke` calls methods by name. Exceptions from the invoked code come back as `TargetInvocationException` (the original is in `InnerException`). `Type.GetType(name)` finds a type by its name.
- **Costs:** Reflection is slower than direct access and bypasses the compiler's type checking (names as text, errors only at runtime); use it where types are really only known at runtime.
- `Enum.Parse<T>(text, ignoreCase: true)` turns a name back into an enum value, also with `[Flags]` (`"Leser, Autor"`).
