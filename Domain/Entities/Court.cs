namespace Domain.Entities
{
    public class Court : BaseEntity
    {
        public string CourtDes { get; set; }
        public int ClubID { get; set; }
        public virtual Club Club { get; set; }
    }
}
