using System.Xml.Linq;

namespace HomeWorkLinq5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new();
            user.ShowExpired();
        }
    }

    class Storage
    {
        private List<CannedMeat> _cannedMeatList = new();

        public Storage()
        {
            AddCannedMeat();
        }

        public void FindExpired()
        {
            int todaysYear = DateTime.Now.Year;
            var expiredStews = _cannedMeatList.Where(_stews => (_stews.ProductionDate + _stews.ExpirationDate) < todaysYear).ToList();
            Console.WriteLine($"Просроченная тушёнка, по сегодняшнему {todaysYear} году:");
            ShowGoods(expiredStews);
        }

        public void ShowGoods(List<CannedMeat> cannedMeats)
        {
            Console.WriteLine("Тушёнка:");

            foreach (CannedMeat cannedMeat in cannedMeats)
            {
                cannedMeat.ShowDetails();
            }
        }

        private void AddCannedMeat()
        {
            _cannedMeatList = new List<CannedMeat>()
            {
                new CannedMeat("Баварская", 2020, 2),
                new CannedMeat("По ГОСТу", 2021, 5),
                new CannedMeat("Образцовая", 2011, 10),
                new CannedMeat("Белорусская", 2012, 5),
                new CannedMeat("Совок", 2015, 4),
                new CannedMeat("Гродфуд", 2015, 7),
                new CannedMeat("Береза", 2017, 10),
                new CannedMeat("Говяжья", 2015, 10),
            };
        }
    }

    class CannedMeat
    {
        public CannedMeat(string name, int productionDate, int expirationDate)
        {
            Name = name;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }

        public string Name { get; private set; }

        public int ProductionDate { get; private set; }

        public int ExpirationDate { get; private set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Тушёнка - {Name}, год поизводства - {ProductionDate}, срок годности - {ExpirationDate}.");
        }
    }

    class User
    {
        private Storage _storage = new();

        public void ShowExpired()
        {
            _storage.FindExpired();
        }
    }
}