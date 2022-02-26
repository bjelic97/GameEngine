using System.ComponentModel;

namespace GameEngine
{
    public class PlayerCharacter : INotifyPropertyChanged
    {
        private int _health = 100;
        public int Health { get => _health; set { _health = value; OnPropertyChanged(); } }

        private void OnPropertyChanged()
        {
           // PropertyChanged.Invoke();
        }

        public bool IsNoob { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string? NickName { get; set; }

        public List<string> Weapons { get; set; }
        public event EventHandler<EventArgs> PlayerSlept;
        public event PropertyChangedEventHandler? PropertyChanged;

        public PlayerCharacter()
        {
            IsNoob = true;
            CreateStartingWeapons();
        }

        private void CreateStartingWeapons()
        {
            Weapons = new List<string>
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
        }

        public void Sleep()
        {
            var healthIncrease = CalculateHealthIncrease();
            Health += healthIncrease;
            OnPlayerSlept(EventArgs.Empty);
        }

        protected virtual void OnPlayerSlept(EventArgs e)
        {
            PlayerSlept?.Invoke(this, e);
        }

        private static int CalculateHealthIncrease()
        {
            var rnd = new Random();
            return rnd.Next(1, 101);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);
        }
    }
}
