namespace Core.Models {
    public class Storage : AbstractModel {
        public Guid? ParentStorageId { get; set; }
        public string OwnerId { get; set; }
    }
}
