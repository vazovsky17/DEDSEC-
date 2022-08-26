namespace DEDSEC.Domain.Models
{
    public class Meeting
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int MaxCountVisitors { get; set; }

        public Meeting(Guid id, string title, string description, DateTime dateBegin, DateTime dateEnd, int maxCountVisitors)
        {
            Id = id;
            Title = title;
            Description = description;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            MaxCountVisitors = maxCountVisitors;
        }
    }
}
