namespace Domain.Entities
{
    public class Club
    {
        public int ClubID { get; set; }
        public string ClubDes { get; set; }
        public bool Active { get; set;}
        public virtual ICollection<Court> Courts { get; set; }
    }
}
