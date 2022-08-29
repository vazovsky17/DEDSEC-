using DEDSEC.Domain.Models;
using System;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingViewModel : ViewModelBase
    {
        public Meeting Meeting { get; private set; }
        public Guid Id => Meeting.Id;
        public string Title => Meeting.Title;
        public string Description => Meeting.Description;
        public DateTime DateBegin => Meeting.DateBegin;
        public DateTime DateEnd => Meeting.DateEnd;
        public int MaxCountVisitors => Meeting.MaxCountVisitors;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MeetingViewModel(Meeting meeting)
        {
            Meeting = meeting;
        }

        public void Update(Meeting meeting)
        {
            Meeting = meeting;

            OnPropertyChanged(nameof(Meeting));
        }
    }
}
