using System;
using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.CompositionRoot.Utilities
{
    public static class TypeConstraints
    {
        //        public static bool IsCity(Type type) => type.IsAssignableToGenericType(typeof (ICity<>))
        //                                                && !type.IsAssignableToGenericType(typeof (CityDecorator<>))
        //                                                && type.IsClass;
        //
        //        public static bool IsTerrain(Type type) => type.IsAssignableToGenericType(typeof (ITerrain<>))
        //                                                   && type.IsClass;
        //
        //        public static bool IsUnit(Type type) => type.IsAssignableToGenericType(typeof (IUnit<>))
        //                                                && !type.IsAssignableToGenericType(typeof (UnitDecorator<>))
        //                                                && type.IsClass;
        //
        //        public static bool IsCityFactory(Type type) => type.IsAssignableToGenericType(typeof (ICityFactory<>))
        //                                                       && type.IsClass;
        //
        //        public static bool IsTerrainFactory(Type type) => type.IsAssignableToGenericType(typeof (ITerrainFactory<>))
        //                                                          && type.IsClass;
        //
        //        public static bool IsUnitFactory(Type type) => type.IsAssignableToGenericType(typeof (IUnitFactory<>))
        //                                                       && type.IsClass;
        //
        //        public static bool IsProductionProject(Type type) => typeof (IProductionProject).IsAssignableFrom(type)
        //                                                             && type != typeof (EmptyProject)
        //                                                             && type.IsClass;

        public static IEnumerable<Type> Cities
            => typeof (ICity<>).Assembly.GetTypes().Where(t => t.IsCity());

        public static IEnumerable<Type> Terrains
            => typeof (ITerrain<>).Assembly.GetTypes().Where(t => t.IsTerrain());

        public static IEnumerable<Type> Units
            => typeof (IUnit<>).Assembly.GetTypes().Where(t => t.IsUnit());

        public static IEnumerable<Type> CityFactories
            => typeof (ICityFactory<>).Assembly.GetTypes().Where(t => t.IsCityFactory());

        public static IEnumerable<Type> TerrainFactories
            => typeof (ITerrainFactory<>).Assembly.GetTypes().Where(t => t.IsTerrainFactory());

        public static IEnumerable<Type> UnitFactories
            => typeof (IUnitFactory<>).Assembly.GetTypes().Where(t => t.IsUnitFactory());

        public static IEnumerable<Type> ProductionProjects
            => typeof (IProductionProject).Assembly.GetTypes().Where(t => t.IsProductionProject());
    }
}
