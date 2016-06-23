//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EventHandlerExtensions 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/23 15:38:13
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Extension
{
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Raises given event safely with given arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="sender">Source of the event</param>
        public static void InvokeSafely(this EventHandler eventHandler, object sender)
        {
            eventHandler.InvokeSafely(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Raises given event safely with given arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="sender">Source of the event</param>
        /// <param name="e">Event argument</param>
        public static void InvokeSafely(this EventHandler eventHandler,object sender,EventArgs e)
        {
            if (eventHandler == null)
                return;
            eventHandler(sender, e);
        }

        /// <summary>
        /// Raises given event safely with given arguments.
        /// </summary>
        /// <typeparam name="TEventArgs">Type of the <see cref="EventArgs"/></typeparam>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="sender">Source of the event</param>
        /// <param name="e">Event argument</param>
        public static void InvokeSafely<TEventArgs>(this EventHandler<TEventArgs> eventHandler,object sender,TEventArgs e) where TEventArgs:EventArgs
        {
            if (eventHandler == null)
                return;
            eventHandler(sender, e);
        }
    }
}
