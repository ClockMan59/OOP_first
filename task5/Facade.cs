using System;

namespace task5
{
    public class SyncFacade
    {
        private IFileSystem _sourceFS;
        private IFileSystem _targetFS;

        public SyncFacade(IFileSystem source, IFileSystem target)
        {
            _sourceFS = source;
            _targetFS = target;
        }

        public void SyncFolder(string sourcePath, string targetPath)
        {
            Console.WriteLine($"\n--- Запуск синхронизации: {sourcePath} -> {targetPath} ---");
            var items = _sourceFS.ListItems(sourcePath);

            foreach (var item in items)
            {
                byte[] data = _sourceFS.ReadFile(sourcePath + "/" + item);
                _targetFS.WriteFile(targetPath + "/" + item, data);
            }
            Console.WriteLine("--- Синхронизация завершена ---");
        }

        public void Backup(string sourcePath, string backupPath)
        {
            Console.WriteLine($"\n>>> НАЧАЛО РЕЗЕРВНОГО КОПИРОВАНИЯ: {sourcePath} -> {backupPath} <<<");
            try
            {
                SyncFolder(sourcePath, backupPath);
                Console.WriteLine(">>> РЕЗЕРВНОЕ КОПИРОВАНИЕ УСПЕШНО ЗАВЕРШЕНО <<<\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при копировании: {ex.Message}");
            }
        }
    }
}