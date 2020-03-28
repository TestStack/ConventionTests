﻿namespace TestStack.ConventionTests.ConventionData
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using TestStack.ConventionTests.Internal;

    /// <summary>
    ///  ConventionTests data source of Types
    /// </summary>
    public class Types : IConventionData, IEnumerable<Type>
    {
        /// <summary>
        /// Create an empty Types data source.
        /// NOTE: There are static helper methods on this type. i.e Types.InAssemblyOf&lt;Foo&gt;()
        /// </summary>
        public Types(string descriptionOfTypes) : this(Enumerable.Empty<Type>(), descriptionOfTypes)
        {
        }

        /// <summary>
        /// Create a Types data source.
        /// NOTE: There are static helper methods on this type. i.e Types.InAssemblyOf&lt;Foo&gt;()
        /// </summary>
        public Types(IEnumerable<Type> types, string descriptionOfTypes)
        {
            TypesToVerify = types.ToArray();
            Description = descriptionOfTypes;
        }

        public IEnumerable<Type> TypesToVerify { get; private set; }

        public string Description { get; private set; }

        public bool HasData
        {
            get { return TypesToVerify.Any(); }
        }

        /// <summary>
        /// Gets a filtered list of types from the assembly of the specified
        /// type, <typeparam name="T" />, using the specified <param name="predicate" />.
        /// </summary>
        /// <typeparam name="T">A type residing in the assembly to get types from.</typeparam>
        /// <param name="predicate">A function to test each type for a condition.</param>
        public static Types InAssemblyOf<T>(Func<Type, bool> predicate)
        {
            return InAssemblyOf(typeof(T), predicate);
        }

        /// <summary>
        /// Gets a filtered list of types from the assembly of the specified
        /// type, <param name="type" />, using the specified <param name="predicate" />.
        /// </summary>
        /// <param name="type">A type residing in the assembly to get types from.</param>
        /// <param name="predicate">A function to test each type for a condition.</param>
        public static Types InAssemblyOf(Type type, Func<Type, bool> predicate)
        {
            return InAssembly(type.GetAssembly(), predicate);
        }

        /// <summary>
        /// Gets a filtered list of types from the specified <param name="assembly" /> using the specified <param name="predicate" />.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="predicate">A function to test each type for a condition.</param>
        public static Types InAssembly(Assembly assembly, Func<Type, bool> predicate)
        {
            return InAssembly(assembly, GetAssemblyName(assembly), predicate);
        }

        /// <summary>
        /// Gets a filtered list of types from the assembly of the specified
        /// type, <typeparam name="T" />, using the specified <param name="predicate" />.
        /// </summary>
        /// <typeparam name="T">A type residing in the assembly to get types from.</typeparam>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="predicate">A function to test each type for a condition.</param>
        public static Types InAssemblyOf<T>(string descriptionOfTypes, Func<Type, bool> predicate)
        {
            return InAssemblyOf(typeof(T), descriptionOfTypes, predicate);
        }

        /// <summary>
        /// Gets a filtered list of types from the assembly of the specified
        /// type, <param name="type" />, using the specified <param name="predicate" />.
        /// </summary>
        /// <param name="type">A type residing in the assembly to get types from.</param>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="predicate">A function to test each type for a condition.</param>
        public static Types InAssemblyOf(Type type, string descriptionOfTypes, Func<Type, bool> predicate)
        {
            return InAssembly(type.GetAssembly(), descriptionOfTypes, predicate);
        }

        /// <summary>
        /// Gets a filtered list of types from the specified <param name="assembly" /> using the specified <param name="predicate" />.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="predicate">A function to test each type for a condition.</param>
        public static Types InAssembly(Assembly assembly, string descriptionOfTypes, Func<Type, bool> predicate)
        {
            return InAssemblies(new[] { assembly }, descriptionOfTypes, predicate);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the specified <param name="assemblies" /> using the specified <param name="predicate" />.
        /// </summary>
        /// <param name="assemblies">A list of assemblies to get types from.</param>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="predicate">A function to test each type for a condition.</param>
        public static Types InAssemblies(IEnumerable<Assembly> assemblies, string descriptionOfTypes, Func<Type, bool> predicate)
        {
            return InCollection(assemblies.SelectMany(x => x.GetTypes()).Where(predicate), descriptionOfTypes);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the assembly of the specified type, <typeparam name="T" />.
        /// </summary>
        /// <typeparam name="T">A type residing in the assembly to get types from.</typeparam>
        /// <param name="excludeCompilerGeneratedTypes">Compiler generated types will be excluded if set to <c>true</c>.</param>
        public static Types InAssemblyOf<T>(bool excludeCompilerGeneratedTypes = true)
        {
            return InAssemblyOf(typeof(T), excludeCompilerGeneratedTypes);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the assembly of the specified type, <param name="type" />.
        /// </summary>
        /// <param name="type">A type residing in the assembly to get types from.</param>
        /// <param name="excludeCompilerGeneratedTypes">Compiler generated types will be excluded if set to <c>true</c>.</param>
        public static Types InAssemblyOf(Type type, bool excludeCompilerGeneratedTypes = true)
        {
            return InAssembly(type.GetAssembly(), excludeCompilerGeneratedTypes);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the specified <param name="assembly" />.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="excludeCompilerGeneratedTypes">Compiler generated types will be excluded if set to <c>true</c>.</param>
        public static Types InAssembly(Assembly assembly, bool excludeCompilerGeneratedTypes = true)
        {
            return InAssembly(assembly, GetAssemblyName(assembly), excludeCompilerGeneratedTypes);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the assembly of the specified
        /// type, <typeparam name="T" />, using the specified <param name="types" /> filter.
        /// </summary>
        /// <typeparam name="T">A type residing in the assembly to get types from.</typeparam>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="types">A function to filter or add matched types.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and should not be used. Use the overload with a predicate instead.")]
        public static Types InAssemblyOf<T>(string descriptionOfTypes, Func<IEnumerable<Type>, IEnumerable<Type>> types)
        {
            #if NewReflection
            var typeInfoTypes = typeof(T).GetTypeInfo().Assembly.GetTypes();
            #else
            var typeInfoTypes = typeof(T).Assembly.GetTypes();
            #endif
            return InCollection(types(typeInfoTypes), descriptionOfTypes);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the assembly of the specified type, <typeparam name="T" />.
        /// </summary>
        /// <typeparam name="T">A type residing in the assembly to get types from.</typeparam>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="excludeCompilerGeneratedTypes">Compiler generated types will be excluded if set to <c>true</c>.</param>
        public static Types InAssemblyOf<T>(string descriptionOfTypes, bool excludeCompilerGeneratedTypes = true)
        {
            return InAssemblyOf(typeof(T), descriptionOfTypes, excludeCompilerGeneratedTypes);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the assembly of the specified type, <param name="type" />.
        /// </summary>
        /// <param name="type">A type residing in the assembly to get types from.</param>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="excludeCompilerGeneratedTypes">Compiler generated types will be excluded if set to <c>true</c>.</param>
        public static Types InAssemblyOf(Type type, string descriptionOfTypes, bool excludeCompilerGeneratedTypes = true)
        {
            return InAssembly(type.GetAssembly(), descriptionOfTypes, excludeCompilerGeneratedTypes);
        }

        /// <summary>
        /// Gets an optionally filtered list of types from the specified <param name="assembly" />.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="descriptionOfTypes">A description of the matched types.</param>
        /// <param name="excludeCompilerGeneratedTypes">Compiler generated types will be excluded if set to <c>true</c>.</param>
        public static Types InAssembly(Assembly assembly, string descriptionOfTypes, bool excludeCompilerGeneratedTypes = true)
        {
            return InAssemblies(new[] { assembly }, descriptionOfTypes, excludeCompilerGeneratedTypes);
        }

        /// <summary>
        /// Creates a Types data source which includes all types from the specified assemblies
        /// </summary>
        /// <param name="assemblies">A list of assemblies to get types from.</param>
        /// <param name="descriptionOfTypes">A description of the types.</param>
        /// <param name="excludeCompilerGeneratedTypes">Compiler generated types will be excluded if set to <c>true</c>.</param>
        public static Types InAssemblies(IEnumerable<Assembly> assemblies, string descriptionOfTypes, bool excludeCompilerGeneratedTypes = true)
        {
            return InAssemblies(assemblies, descriptionOfTypes, type => !(excludeCompilerGeneratedTypes && type.IsCompilerGenerated()));
        }

        /// <summary>
        /// Creates a Types data source from an existing list of types
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="descriptionOfTypes">A description of the types.</param>
        public static Types InCollection(IEnumerable<Type> types, string descriptionOfTypes)
        {
            return new Types(types, descriptionOfTypes);
        }

        private static string GetAssemblyName(Assembly assembly)
        {
            return assembly.GetName().Name;
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return TypesToVerify.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}