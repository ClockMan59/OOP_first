using System;
using System.Collections.Generic;

namespace task5
{
    public interface IFileSystem
    {
        List<string> ListItems(string path);
        byte[] ReadFile(string path);
        void WriteFile(string path, byte[] data);
        void DeleteItem(string path);
    }

    public class LocalFileSystemAdapter : IFileSystem
    {
        public List<string> ListItems(string path) => new List<string> { "report.docx", "photo.png" };

        public byte[] ReadFile(string path)
        {
            Console.WriteLine($"[Локальный диск] Чтение файла: {path}");
            return new byte[1024];
        }

        public void WriteFile(string path, byte[] data)
        {
            Console.WriteLine($"[Локальный диск] Сохранение файла: {path}");
        }

        public void DeleteItem(string path) => Console.WriteLine($"[Локальный диск] Удаление: {path}");
    }

    public class FtpFileSystemAdapter : IFileSystem
    {
        public List<string> ListItems(string path) => new List<string> { "backup.zip" };

        public byte[] ReadFile(string path)
        {
            Console.WriteLine($"[FTP Сервер] Скачивание файла по сети: {path}");
            return new byte[2048];
        }

        public void WriteFile(string path, byte[] data)
        {
            Console.WriteLine($"[FTP Сервер] Загрузка файла на сервер: {path}");
        }

        public void DeleteItem(string path) => Console.WriteLine($"[FTP Сервер] Удаление: {path}");
    }

    public class CloudFileSystemAdapter : IFileSystem
    {
        public List<string> ListItems(string path) => new List<string> { "shared_doc.pdf" };

        public byte[] ReadFile(string path)
        {
            Console.WriteLine($"[Google Drive] API запрос на скачивание: {path}");
            return new byte[512];
        }

        public void WriteFile(string path, byte[] data)
        {
            Console.WriteLine($"[Google Drive] API запрос на загрузку: {path}");
        }

        public void DeleteItem(string path) => Console.WriteLine($"[Google Drive] API запрос на удаление: {path}");
    }
}