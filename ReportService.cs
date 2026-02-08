namespace OOP_Fundamentals_Library
{
    namespace OOP_Fundamentals_Library
    {
        public class ReportService
        {
            public static void GenerateReport(Person person)
            {
                Console.WriteLine("Generating Report...");
                person.PrintInfo();
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
