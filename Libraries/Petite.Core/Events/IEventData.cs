using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petite.Core.Events
{
    public interface IEventData
    {
        /// <summary>
        /// 事件发生时间
        /// </summary>
        DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的事件源（可选）
        /// </summary>
        object EventSource { get; set; }
    }
}
