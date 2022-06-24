using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Garden
    {
        public int Size { get; }
        private ICollection<string> _items { get; }
        private ILogger? _logger { get; }


        public Garden(int size)
        {
            Size = size;
            _items = new List<string>();
        }

        public Garden(int size, ILogger logger) : this(size)
        {
            _logger = logger;
        }

        public bool Plant(string name)
        {
            if(name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Roślina musi posiadać nazwę!", nameof(name));
            if (_items.Contains(name))
                throw new ArgumentException("Roślina już istnieje w ogrodzie", nameof(name));

            if (_items.Count() >= Size)
            {
                _logger?.Log($"Brak miejsca w ogrodzie na {name}");
                return false;
            }

            _items.Add(name);
            _logger?.Log($"Zasadzono w ogrodzie {name}");
            return true;
        }

        public void Remove(string name)
        {
            if(!_items.Contains(name))
                throw new ArgumentException("Nie ma takiej rośliny w ogrodzie!", nameof(name));

            _items.Remove(name);

            _logger?.Log($"Usunięto z ogrodu {name}");
        }

        public void Clear()
        {
            _items.Clear();
        }

        public int Count()
        {
            return _items.Count();
        }

        public ICollection<string> GetPlants()
        {
            return _items.ToList();
        }
    }
}
