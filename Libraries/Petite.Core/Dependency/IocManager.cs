//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IocManager 
//        Description :    
//        Created by Wsy at 2016/7/9 13:30:28
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Petite.Core.Configuration;

namespace Petite.Core.Dependency
{
    /// <summary>
    /// 直接执行依赖注册任务
    /// </summary>
    public class IocManager:IIocManager
    {
        #region fields

        /// <summary>
        /// IocManager单例模式
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        /// Castle Windsor Container
        /// </summary>
        public IWindsorContainer IocContainer { get; private set; }

        /// <summary>
        /// 依赖 注册列表
        /// </summary>
        private readonly List<IConventionalDependencyRegistrar> _conventionalRegistrars;

        #endregion

        #region ctors

        static IocManager()
        {
            Instance = new IocManager();
        }

        /// <summary>
        /// <see cref="IocManager"/>构造函数
        /// 通常情况下，你不需要直接实例化 <see cref="IocManager"/>.
        /// 但在测试的情况下有可能需要.
        /// </summary>
        public IocManager()
        {
            IocContainer = new WindsorContainer();
            _conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

            //注册IocManager!
            IocContainer.Register(
                Component.For<IocManager, IIocManager, IIocRegistrar, IIocResolver>().UsingFactoryMethod(() => this)
                );
        }

        #endregion

        #region methods

        /// <summary>
        /// 添加一个依赖注入项
        /// </summary>
        /// <param name="registrar">依赖注入</param>
        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            _conventionalRegistrars.Add(registrar);
        }

        /// <summary>
        /// 注册Assembly，参见 <see cref="AddConventionalRegistrar"/> 方法.
        /// </summary>
        /// <param name="assembly">需要注册的程序集</param>
        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            RegisterAssemblyByConvention(assembly, new ConventionalRegistrationConfig());
        }

        /// <summary>
        /// 注册Assembly,参见 <see cref="AddConventionalRegistrar"/> 方法.
        /// </summary>
        /// <param name="assembly">需要注册的程序集</param>
        /// <param name="config">附加配置</param>
        public void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config)
        {
            var context = new ConventionalRegistrationContext(assembly, this, config);

            foreach (var registerer in _conventionalRegistrars)
            {
                registerer.RegisterAssembly(context);
            }

            if (config.InstallInstallers)
            {
                IocContainer.Install(FromAssembly.Instance(assembly));
            }
        }

        /// <summary>
        /// 自注册一个类型.
        /// </summary>
        /// <typeparam name="TType">class类型</typeparam>
        /// <param name="lifeStyle">对象生命周期</param>
        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType>(), lifeStyle));
        }

        /// <summary>
        /// 自注册一个类型
        /// </summary>
        /// <param name="type">class类型</param>
        /// <param name="lifeStyle">对象生命周期</param>
        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifestyle(Component.For(type), lifeStyle));
        }

        /// <summary>
        /// 使用TType的实现类注册
        /// </summary>
        /// <typeparam name="TType">注册类型</typeparam>
        /// <typeparam name="TImpl">对应的实现类<see cref="TType"/></typeparam>
        /// <param name="lifeStyle">对应对象的生命周期</param>
        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
        }

        /// <summary>
        /// 自注册一个类型
        /// </summary>
        /// <param name="type">class类型</param>
        /// <param name="impl">对应类型实现类<paramref name="type"/></param>
        /// <param name="lifeStyle">对应对象的生命周期</param>
        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifestyle(Component.For(type, impl).ImplementedBy(impl), lifeStyle));
        }

        /// <summary>
        /// 检测Type是否已经注册过
        /// </summary>
        /// <param name="type">检测的Type</param>
        public bool IsRegistered(Type type)
        {
            return IocContainer.Kernel.HasComponent(type);
        }

        /// <summary>
        /// 检测Type是否已经注册过
        /// </summary>
        /// <typeparam name="TType">检测的Type</typeparam>
        public bool IsRegistered<TType>()
        {
            return IocContainer.Kernel.HasComponent(typeof(TType));
        }

        /// <summary>
        /// 从IOC容器获取一个对象
        /// 返回的对象必须在使用后release (见 <see cref="IIocResolver.Release"/>) .
        /// </summary> 
        /// <typeparam name="T">需要获取的对象类型</typeparam>
        /// <returns>对象实例</returns>
        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }

        /// <summary>
        /// 从IOC容器获取一个对象
        /// 返回的对象必须在使用后release (见 <see cref="IIocResolver.Release"/>) .
        /// </summary> 
        /// <typeparam name="T">转换的对象类型</typeparam>
        /// <param name="type">获取的对象类型</param>
        /// <returns>对象实例</returns>
        public T Resolve<T>(Type type)
        {
            return (T)IocContainer.Resolve(type);
        }

        /// <summary>
        /// 从IOC容器获取一个对象
        /// 返回的对象必须在使用后release (见 <see cref="IIocResolver.Release"/>) .
        /// </summary> 
        /// <typeparam name="T">需要获取的对象类型</typeparam>
        /// <param name="argumentsAsAnonymousType">构造函数参数</param>
        /// <returns>对象实例</returns>
        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve<T>(argumentsAsAnonymousType);
        }

        /// <summary>
        /// 从IOC容器获取一个对象
        /// 返回的对象必须在使用后release (见 <see cref="IIocResolver.Release"/>) .
        /// </summary> 
        /// <param name="type">需要获取的对象类型</param>
        /// <returns>对象实例</returns>
        public object Resolve(Type type)
        {
            return IocContainer.Resolve(type);
        }

        /// <summary>
        /// 从IOC容器获取一个对象
        /// 返回的对象必须在使用后release (见 <see cref="IIocResolver.Release"/>) .
        /// </summary> 
        /// <param name="type">需要获取的对象类型</param>
        /// <param name="argumentsAsAnonymousType">构造函数参数</param>
        /// <returns>对象实例</returns>
        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve(type, argumentsAsAnonymousType);
        }

        /// <summary>
        /// 释放之前获取的对象<see cref="Resolve"/> 
        /// </summary>
        /// <param name="obj">Object to be released</param>
        public void Release(object obj)
        {
            IocContainer.Release(obj);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            IocContainer.Dispose();
        }

        private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
            where T : class
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }        

        #endregion
    }
}
