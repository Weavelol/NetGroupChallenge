namespace DTOModels {
    public class StatisticsDTO {
        public int StoragesAmount { get; set; }
        public int ItemsAmount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int MaxItemsInStorage { get; set; }
    }
}
