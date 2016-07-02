namespace Petite.Core.Events
{
    public interface IEventPublisher
    {
        /// <summary>
        /// 发布一个事件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="eventMessage">事件信息</param>
        void Publish<T>(T eventMessage);
    }
}
