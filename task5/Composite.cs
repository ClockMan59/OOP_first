using System;
using System.Collections.Generic;
using System.Linq;

namespace task5
{

    public abstract class FileSystemItem
    {
        public string Name { get; set; }

        public FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract long GetSize();
        public abstract void Print(string indent = "");

        public virtual void Add(FileSystemItem item) => throw new NotSupportedException("Нельзя добавить в файл.");
        public virtual void Remove(FileSystemItem item) => throw new NotSupportedException("Нельзя удалить из файла.");
    }

    public class FileItem : FileSystemItem
    {
        private long _size;

        public FileItem(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize() => _size;

        public override void Print(string indent = "")
        {
            Console.WriteLine($"{indent}- Файл: {Name} ({_size} байт)");
        }
    }

    public class Folder : FileSystemItem
    {
        private List<FileSystemItem> _items = new List<FileSystemItem>();

        public Folder(string name) : base(name) { }

        public override void Add(FileSystemItem item) => _items.Add(item);

        public override void Remove(FileSystemItem item) => _items.Remove(item);

        public override long GetSize()
        {
            return _items.Sum(item => item.GetSize());
        }

        public override void Print(string indent = "")
        {
            Console.WriteLine($"{indent}+ Папка: {Name} (Общий размер: {GetSize()} байт)");
            foreach (var item in _items)
            {
                item.Print(indent + "  ");
            }
        }
    }
}