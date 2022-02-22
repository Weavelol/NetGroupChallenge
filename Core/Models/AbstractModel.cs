namespace Core.Models {
    public abstract class AbstractModel {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
    }
}
