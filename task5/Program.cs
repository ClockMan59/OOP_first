using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЭТАП 1: Тест Компоновщика (Composite) ===");
            Folder root = new Folder("C:/Мои документы");
            Folder work = new Folder("Работа");
            Folder games = new Folder("Игры");

            work.Add(new FileItem("Отчет.docx", 2500));
            work.Add(new FileItem("Таблица.xlsx", 5000));
            games.Add(new FileItem("save.dat", 15000));

            root.Add(work);
            root.Add(games);
            root.Add(new FileItem("пароли.txt", 100));

            root.Print();
            Console.WriteLine($"Общий размер на диске: {root.GetSize()} байт\n");


            Console.WriteLine("=== ЭТАП 2: Тест Адаптера и Фасада (Adapter + Facade) ===");

            IFileSystem localDrive = new LocalFileSystemAdapter();
            IFileSystem cloudDrive = new CloudFileSystemAdapter();
            IFileSystem ftpServer = new FtpFileSystemAdapter();

            SyncFacade cloudBackup = new SyncFacade(localDrive, cloudDrive);
            cloudBackup.Backup("C:/Мои документы/Работа", "GoogleDrive:/Backups/Работа");

            SyncFacade ftpSync = new SyncFacade(localDrive, ftpServer);
            ftpSync.SyncFolder("C:/Мои документы/Игры", "ftp://server.com/games");

            Console.ReadLine();
        }
    }
}