namespace Domain.Entities
{
    public class Club: BaseEntity
    {
        public string ClubDes { get; set; }

        public virtual ICollection<Court> Courts { get; set; }
    }
}
