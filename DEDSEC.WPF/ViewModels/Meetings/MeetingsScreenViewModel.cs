﻿using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingsScreenViewModel : ViewModelBase
    {
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;
        public ICommand AddMeetingCommand { get; }

        private readonly AccountStore _accountStore;
        private readonly MeetingsStore _meetingsStore;
        private readonly ModalNavigationStore _modalStore;

        private readonly ObservableCollection<MeetingViewModel> _meetingViewModels;
        public IEnumerable<MeetingViewModel> MeetingViewModels => _meetingViewModels;

        public MeetingsScreenViewModel(AccountStore accountStore,
            MeetingsStore meetingsStore,
            ModalNavigationStore modalStore,
            INavigationService addMeetingNavigationService)
        {
            _accountStore = accountStore;
            _meetingsStore = meetingsStore;
            _modalStore = modalStore;

            _meetingViewModels = new();

            Load();
            _meetingsStore.MeetingsLoaded += MeetingsStore_Loaded;
            _meetingsStore.MeetingAdded += MeetingsStore_Added;
            _meetingsStore.MeetingUpdated += MeetingsStore_Updated;
            _meetingsStore.MeetingDeleted += MeetingsStore_Deleted;

            AddMeetingCommand = new NavigateCommand(addMeetingNavigationService);
        }

        private async void Load()
        {
            await _meetingsStore.Load();
        }

        private void MeetingsStore_Loaded()
        {
            _meetingViewModels.Clear();
            foreach (var meeting in _meetingsStore.Meetings)
            {
                AddGameViewModel(meeting);
            }
        }


        private void MeetingsStore_Added(Meeting meeting)
        {
            AddGameViewModel(meeting);
        }

        private void MeetingsStore_Updated(Meeting meeting)
        {
            MeetingViewModel meetingViewModel = _meetingViewModels.FirstOrDefault(x => x.Id == meeting.Id);
            if (meetingViewModel != null)
            {
                _meetingViewModels.Remove(meetingViewModel);
                meetingViewModel.Update(meeting);
                _meetingViewModels.Add(meetingViewModel);
            }
        }

        private void MeetingsStore_Deleted(Guid id)
        {
            MeetingViewModel meetingViewModel = _meetingViewModels.FirstOrDefault(y => y.Id == id);

            if (meetingViewModel != null)
            {
                _meetingViewModels.Remove(meetingViewModel);
            }
        }

        private void AddGameViewModel(Meeting meeting)
        {
            var itemViewModel = new MeetingViewModel(meeting, _meetingsStore, _modalStore, IsAdmin);
            _meetingViewModels.Add(itemViewModel);
        }

        public override void Dispose()
        {
            _meetingsStore.MeetingsLoaded -= MeetingsStore_Loaded;
            _meetingsStore.MeetingAdded -= MeetingsStore_Added;
            _meetingsStore.MeetingUpdated -= MeetingsStore_Updated;
            _meetingsStore.MeetingDeleted -= MeetingsStore_Deleted;

            base.Dispose();
        }
    }
}
