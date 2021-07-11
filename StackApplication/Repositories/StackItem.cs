using System.Linq;
using System.Text.Json;

namespace StackApplication.Repositories
{
    public class StackItem<T>
    {
        private T _vaue;
        public StackItem()
        {

        }

        public StackItem(T value)
        {
            _vaue = value;
        }
        public int Id { get; set; }
        public T Value => _vaue;
        public string ValueAsJson
        {
            get { return JsonSerializer.Serialize(_vaue); }
            set { _vaue = JsonSerializer.Deserialize<T>(value); }
        }
    }
}
