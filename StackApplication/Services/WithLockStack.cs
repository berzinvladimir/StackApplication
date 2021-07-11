using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackApplication.Services
{
    public class WithLockStack<T> : IStack<T> where T : class
    {

        private readonly Stack<T> _stack;
        public WithLockStack()
        {
            _stack = new Stack<T>();
        }
        public Task<T> Peek()
        {
            if (_stack.TryPeek(out T result))
            {
                return Task.FromResult(result);
            }
            return null;
        }

        public Task<T> Pop()
        {
            lock(_stack)
            {
                T result;
                if (_stack.TryPop(out result))
                {
                    return Task.FromResult(result);
                }
                return null;
            }
           
        }

        public Task Push(T value)
        {
            lock (_stack)
            {
                return Task.Run(() => _stack.Push(value));
            }
        }
    }
}
