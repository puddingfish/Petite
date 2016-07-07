//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :AsyncHelper 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/25 16:32:41
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Reflection;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace Petite.Data.Threading
{
    /// <summary>
    /// 异步方法的帮助类
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// 检测传入的方法是否为异步方法
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }

        /// <summary>
        /// 同步运行一个异步方法
        /// </summary>
        /// <typeparam name="TResult">返回结果</typeparam>
        /// <param name="func">方法</param>
        /// <returns>异步操作的结果</returns>
        public static TResult RunSync<TResult> (Func<Task<TResult>> func)
        {
            return AsyncContext.Run(func);
        }

        /// <summary>
        /// 同步运行一个异步方法
        /// </summary>
        /// <param name="action">异步action</param>
        public static void RunSync(Func<Task> action)
        {
            AsyncContext.Run(action);
        }
    }
}
