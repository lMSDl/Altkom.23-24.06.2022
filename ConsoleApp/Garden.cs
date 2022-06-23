﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Garden
    {
        public int Size { get; }
        public ICollection<string> _items { get; }


        public Garden(int size)
        {
            Size = size;
            _items = new List<string>();
        }


        public bool Plant(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            if (_items.Contains(name))
                throw new ArgumentException("Roślina już istnieje w ogrodzie");

            if (_items.Count() >= Size)
                return false;

            _items.Add(name);
            return true;
        }

        public IEnumerable<string> GetPlants()
        {
            return _items.ToList();
        }
    }
}