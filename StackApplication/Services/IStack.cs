using StackApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackApplication.Services
{
    public interface IStack<T> where T : class
    
    {

        public Task<T> Pop();
        public Task<T> Peek();
        public Task Push(T value);

    }
}
