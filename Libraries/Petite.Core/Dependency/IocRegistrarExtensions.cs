//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IocRegistrarExtensions 
//        Description :    
//        Created by Wsy at 2016/8/6 15:31:28
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Dependency
{
    /// <summary>
    /// <see cref="IIocRegistrar"/>接口扩展方法
    /// </summary>
    public static class IocRegistrarExtensions
    {
        #region RegisterIfNot

        /// <summary>
        /// 为未注册的对象注册
        /// </summary>
        /// <typeparam name="T">class的类型</typeparam>
        /// <param name="iocRegistrar">Registrar</param>
        /// <param name="lifeStyle">生命周期类型</param>
        /// <returns>boolean</returns>
        public static bool RegisterIfNot<T>(this IIocRegistrar iocRegistrar, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class
        {
            if (iocRegistrar.IsRegistered<T>())
            {
                return false;
            }

            iocRegistrar.Register<T>(lifeStyle);
            return true;
        }

        /// <summary>
        /// 为未注册的对象注册
        /// </summary>
        /// <param name="iocRegistrar">Registrar</param>
        /// <param name="type">class类型</param>
        /// <param name="lifeStyle">生命周期类型</param>
        /// <returns>boolean</returns>
        public static bool RegisterIfNot(this IIocRegistrar iocRegistrar, Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            if (iocRegistrar.IsRegistered(type))
            {
                return false;
            }

            iocRegistrar.Register(type, lifeStyle);
            return true;
        }

        /// <summary>
        /// Registers a type with it's implementation if it's not registered before.
        /// </summary>
        /// <typeparam name="TType">Registering type</typeparam>
        /// <typeparam name="TImpl">The type that implements <see cref="TType"/></typeparam>
        /// <param name="iocRegistrar">Registrar</param>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        /// <returns>True, if registered for given implementation.</returns>
        public static bool RegisterIfNot<TType, TImpl>(this IIocRegistrar iocRegistrar, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            if (iocRegistrar.IsRegistered<TType>())
            {
                return false;
            }

            iocRegistrar.Register<TType, TImpl>(lifeStyle);
            return true;
        }


        /// <summary>
        /// Registers a type with it's implementation if it's not registered before.
        /// </summary>
        /// <param name="iocRegistrar">Registrar</param>
        /// <param name="type">Type of the class</param>
        /// <param name="impl">The type that implements <paramref name="type"/></param>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        /// <returns>True, if registered for given implementation.</returns>
        public static bool RegisterIfNot(this IIocRegistrar iocRegistrar, Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            if (iocRegistrar.IsRegistered(type))
            {
                return false;
            }

            iocRegistrar.Register(type, impl, lifeStyle);
            return true;
        }

        #endregion
    }
}
