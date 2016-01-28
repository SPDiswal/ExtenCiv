using System;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.ProductionProjects;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.CompositionRoot.Utilities
{
    public static class TypeExtensions
    {
        /// <summary>
        ///     Checks if a concrete type is assignable to an open generic interface.
        ///     <para></para>
        ///     Borrowed from:
        ///     http://stackoverflow.com/questions/74616/how-to-detect-if-type-is-another-generic-type/1075059#1075059
        /// </summary>
        public static bool IsAssignableToGenericType(this Type type, Type genericType)
        {
            return type.GetInterfaces().Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                   || type.IsGenericType && type.GetGenericTypeDefinition() == genericType
                   || type.BaseType != null && IsAssignableToGenericType(type.BaseType, genericType);
        }

        public static Type ToGenericCity(this Type t) => typeof (ICity<>).MakeGenericType(t);

        public static Type ToGenericTerrain(this Type t) => typeof (ITerrain<>).MakeGenericType(t);

        public static Type ToGenericUnit(this Type t) => typeof (IUnit<>).MakeGenericType(t);

        public static Type ToGenericCityFactory(this Type t) =>
            typeof (ICityFactory<>).MakeGenericType(t.GetInterfaces()[0].GetGenericArguments()[0]);

        public static Type ToGenericTerrainFactory(this Type t) =>
            typeof (ITerrainFactory<>).MakeGenericType(t.GetInterfaces()[0].GetGenericArguments()[0]);

        public static Type ToGenericUnitFactory(this Type t) =>
            typeof (IUnitFactory<>).MakeGenericType(t.GetInterfaces()[0].GetGenericArguments()[0]);

        public static bool IsCity(this Type type) => type.IsAssignableToGenericType(typeof (ICity<>))
                                                     && !type.IsAssignableToGenericType(typeof (CityDecorator<>))
                                                     && type.IsClass;

        public static bool IsTerrain(this Type type) => type.IsAssignableToGenericType(typeof (ITerrain<>))
                                                        && type.IsClass;

        public static bool IsUnit(this Type type) => type.IsAssignableToGenericType(typeof (IUnit<>))
                                                     && !type.IsAssignableToGenericType(typeof (UnitDecorator<>))
                                                     && type.IsClass;

        public static bool IsCityFactory(this Type type) => type.IsAssignableToGenericType(typeof (ICityFactory<>))
                                                            && type.IsClass;

        public static bool IsTerrainFactory(this Type type)
            => type.IsAssignableToGenericType(typeof (ITerrainFactory<>))
               && type.IsClass;

        public static bool IsUnitFactory(this Type type) => type.IsAssignableToGenericType(typeof (IUnitFactory<>))
                                                            && type.IsClass;

        public static bool IsProductionProject(this Type type) => typeof (IProductionProject).IsAssignableFrom(type)
                                                                  && type != typeof (EmptyProject)
                                                                  && type.IsClass;
    }
}
