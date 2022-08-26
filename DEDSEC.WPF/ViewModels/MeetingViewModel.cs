using DEDSEC.Domain.Models;
using System;

namespace DEDSEC.WPF.ViewModels
{
    public class MeetingViewModel : ViewModelBase
    {
        public Meeting Meeting { get; }
        public Guid Id => Meeting.Id;
        public string Title => Meeting.Title;
        public string Description => Meeting.Description;
        public DateTime DateBegin => Meeting.DateBegin;
        public DateTime DateEnd => Meeting.DateEnd;
        public int MaxCountVisitors => Meeting.MaxCountVisitors;

        public MeetingViewModel(Meeting meeting)
        {
            Meeting = meeting;
        }
    }
}
