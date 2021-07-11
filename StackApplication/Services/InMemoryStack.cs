using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace StackApplication.Services
{
    public class InMemoryStack<T> : IStack<T> where T : class
    {

        private readonly ConcurrentStack<T> _stack;
        public InMemoryStack()
        {
            _stack = new ConcurrentStack<T>();
        }
        public Task<T> Peek()
        {
            if (_stack.TryPeek(out T result))
            {
                return Task.FromResult(result);
            }
            return Task.FromResult<T>(result);
        }

        public Task<T> Pop()
        {
            if (_stack.TryPop(out T result))
            {
                return Task.FromResult<T>(result);
            }
            return Task.FromResult<T>(result);
        }

        public Task Push(T value)
        {
            return Task.Run(() => _stack.Push(value));
        }
    }
}
