using SOLID_Fundamentals;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ЛАБА 2: SOLID Principles ===\n");

        // 1. Тест SRP (OrderProcessor)
        var order = new Order { Id = 1, TotalAmount = 1000, CustomerEmail = "bro@example.com" };

        // Собираем зависимости
        var processor = new OrderProcessor(
            new PaymentService(),
            new InventoryService(),
            new EmailNotificationService(),
            new ConsoleLogger()
        );
        processor.Process(order);

        Console.WriteLine("\n----------------\n");

        // 2. Тест OCP (Скидки)
        var calculator = new DiscountCalculator();
        decimal price = 1000;

        // Используем разные стратегии
        decimal regularPrice = calculator.Calculate(price, new RegularDiscount()); // -5%
        decimal vipPrice = calculator.Calculate(price, new VipDiscount());         // -15%

        Console.WriteLine($"Обычная цена: {regularPrice}");
        Console.WriteLine($"VIP цена: {vipPrice}");

        Console.WriteLine("\n----------------\n");

        // 3. Тест LSP (Банк)
        CheckingAccount myCard = new CheckingAccount();
        myCard.Deposit(500);

        BankService bank = new BankService();
        bank.WithdrawFromAccount(myCard, 100); // Работает

        FixedDepositAccount deposit = new FixedDepositAccount(DateTime.Now.AddYears(1));
        deposit.Deposit(1000);
        // bank.WithdrawFromAccount(deposit, 100); // Ошибка компиляции! Мы защищены от снятия с депозита.

        Console.WriteLine("\n----------------\n");

        // 4. Тест DIP (Уведомления)
        IMessageSender email = new EmailSender();
        IMessageSender sms = new SmsSender();

        // Можем легко менять способы отправки
        var notifer1 = new NotificationManager(email);
        notifer1.Notify("bro@mail.com", "Привет через Email");

        var notifer2 = new NotificationManager(sms);
        notifer2.Notify("89991234567", "Привет через SMS");

        Console.ReadLine();
    }
}