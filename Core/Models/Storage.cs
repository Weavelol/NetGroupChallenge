namespace Core.Models {
    public class Storage : AbstractModel {
        public Guid? ParentStorageId { get; set; }
        public Storage? ParentStorage { get; set; }
        public List<Storage>? NestedStorages { get; set; }
        public List<Item>? NestedItems { get; set; }
        public string OwnerId { get; set; }
        public string StoragePath { get; set; }

        public Storage() {
            Id = Guid.Empty;
            OwnerId = Guid.Empty.ToString();
            StoragePath = string.Empty;
            Title = string.Empty;
            NestedStorages = new List<Storage>();
            NestedItems = new List<Item>();
            ParentStorageId = Guid.Empty;
        }
    }
}
