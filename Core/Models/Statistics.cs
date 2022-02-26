namespace Core.Models {
    public class Statistics {
        public int StoragesAmount { get; set; } = 0;
        public int ItemsAmount { get; set; } = 0;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime LastLoginDate { get; set; } = DateTime.Now;
        public int MaxItemsInStorage { get; set; } = 0;
    }
}
