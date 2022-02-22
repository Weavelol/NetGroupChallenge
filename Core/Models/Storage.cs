namespace Core.Models {
    public class Storage : AbstractModel {
        public Guid? ParentStorageId { get; set; }
        public Storage? ParentStorage { get; set; }
        public string OwnerId { get; set; }
        public List<Item>? NestedItems { get; set; }
    }
}
