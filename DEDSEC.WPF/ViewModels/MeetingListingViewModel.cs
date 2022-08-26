using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class MeetingListingViewModel : ViewModelBase
    {
        private readonly MeetingsStore _meetingsStore;
        private readonly ObservableCollection<MeetingViewModel> _meetings;

        public IEnumerable<MeetingViewModel> Meetings => _meetings;
        public ICommand AddMeetingCommand { get; }

        public MeetingListingViewModel(MeetingsStore meetingsStore, INavigationService addMeetingNavigationService)
        {
            _meetingsStore = meetingsStore;

            AddMeetingCommand = new NavigateCommand(addMeetingNavigationService);
            _meetings = new ObservableCollection<MeetingViewModel>();

            _meetings.Add(new MeetingViewModel(new Meeting(
                Guid.NewGuid(),
                "Сходочка",
                "Хуедочка",
                DateTime.Now,
                DateTime.Now,
                10
                )));

            _meetingsStore.MeetingAdded += OnMeetingAdded;
        }

        private void OnMeetingAdded(Meeting meeting)
        {
            _meetings.Add(new MeetingViewModel(meeting));
        }
    }
}
