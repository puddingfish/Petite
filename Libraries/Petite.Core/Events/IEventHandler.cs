namespace Petite.Core.Events
{
    /// <summary>
    /// 事件处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventHandler<T>
    {
        void HandleEvent(T eventMessage);
    }
}
