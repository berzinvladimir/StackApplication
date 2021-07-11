using Microsoft.EntityFrameworkCore;
using StackApplication.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace StackApplication.Services
{
    public abstract class EfStackBase<T> : IStack<T> where T : class
    {
        private readonly StackContext<T> _stackContext;

        public EfStackBase(StackContext<T> stackContext)
        {
            _stackContext = stackContext;
        }
        public async Task<T> Peek()
        {
            return (await GetItem())?.Value;
        }

        public async Task<T> Pop()
        {
            var value = await GetItem();
            if(value == null)
            {
                return null;
            }
            _stackContext.StackItems.Remove(value);
            await _stackContext.SaveChangesAsync();
            return value.Value;
        }

        public async Task Push(T value)
        {
            var item = new StackItem<T>(value);
            _stackContext.StackItems.Add(item);
            await _stackContext.SaveChangesAsync();
        }

        private async Task<StackItem<T>> GetItem()
        {
            return await _stackContext.StackItems.OrderByDescending(s => s.Id).Take(1).AsNoTracking().FirstOrDefaultAsync();
        }
    }

    public class EfStack : EfStackBase<Employee>
    {
        public EfStack(StackContext<Employee> stackContext):base(stackContext)
        {

        }
    }
}
