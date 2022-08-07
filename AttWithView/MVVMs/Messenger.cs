using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs
{
    public class Messenger
    {
        Dictionary<Type, Delegate> acceptions = new();
        public void Register<T>(Action<T> acception)
        {
            if (acceptions.TryAdd(typeof(T), acception) is false)
            {
                acceptions[typeof(T)] = acception;
            }
        }
        public void Send<T>(T message)
            where T : IMessage
        {
            if (acceptions.TryGetValue(typeof(T), out var acception))
            {
                Action<T> _acception = (Action<T>)acception;
                _acception(message);
            }
            else
            {
                message.DefaultAccept();
            }
        }
    }
}
