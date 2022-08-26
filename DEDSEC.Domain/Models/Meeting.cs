namespace DEDSEC.Domain.Models
{
    public class Meeting : DomainObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int MaxCountVisitors { get; set; }
    }
}
