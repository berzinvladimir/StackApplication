using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackApplication.Repositories;
using StackApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StackController : ControllerBase
    {

        private readonly IStack<NameObject> _stack;

        public StackController(IStack<NameObject> stack)
        {
            _stack = stack;
        }

        [HttpGet]
        public async Task<NameObject> Get()
        {
            var item = await _stack.Pop();
            return item;
        }

        [HttpGet("Peek")]
        public async Task<NameObject> Peek()
        {
            var item = await _stack.Peek();
            return item;
        }

        [HttpPut]
        public async Task Push([FromBody] NameObject value)
        {
            await _stack.Push(value);
        }
    }

    
}
