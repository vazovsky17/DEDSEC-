using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingsScreenViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly MeetingsStore _meetingsStore;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly ModalNavigationStore _modalStore;

        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        #region Bindings
        private readonly ObservableCollection<MeetingViewModel> _meetingViewModels;
        public IEnumerable<MeetingViewModel> MeetingViewModels => _meetingViewModels;
        public string MeetingsViewModelsCountDisplay => MeetingViewModels.setMeetingsViewModelsCountDisplay();
        #endregion

        #region Commands
        public ICommand AddMeetingCommand { get; }
        #endregion

        public MeetingsScreenViewModel(AccountStore accountStore,
            MeetingsStore meetingsStore,
            IAuthenticatorService authenticatorService,
            ModalNavigationStore modalStore,
            INavigationService addMeetingNavigationService)
        {
            _accountStore = accountStore;
            _meetingsStore = meetingsStore;
            _authenticatorService = authenticatorService;
            _modalStore = modalStore;

            _meetingViewModels = new();

            Load();
            _meetingsStore.MeetingsLoaded += MeetingsStore_Loaded;
            _meetingsStore.MeetingAdded += MeetingsStore_Added;
            _meetingsStore.MeetingUpdated += MeetingsStore_Updated;
            _meetingsStore.MeetingDeleted += MeetingsStore_Deleted;
            _meetingsStore.MeetingToFavoriteAdded += MeetingsStore_MeetingToFeatureAdded;
            _meetingsStore.MeetingFromFavoriteDeleted += MeetingsStore_MeetingFromFeatureDeleted;

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
            OnPropertyChanged(nameof(MeetingsViewModelsCountDisplay));
        }


        private void MeetingsStore_Added(Meeting meeting)
        {
            AddGameViewModel(meeting);
            OnPropertyChanged(nameof(MeetingsViewModelsCountDisplay));
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
            OnPropertyChanged(nameof(MeetingsViewModelsCountDisplay));
        }

        private void MeetingsStore_MeetingToFeatureAdded(Meeting meeting)
        {
            MeetingViewModel meetingViewModel = _meetingViewModels.FirstOrDefault(x => x.Id == meeting.Id);
            if (meetingViewModel != null)
            {
                meetingViewModel.UpdateIsUserFeature();
            }
        }

        private void MeetingsStore_MeetingFromFeatureDeleted(Meeting meeting)
        {
            MeetingViewModel meetingViewModel = _meetingViewModels.FirstOrDefault(x => x.Id == meeting.Id);
            if (meetingViewModel != null)
            {
                meetingViewModel.UpdateIsUserFeature();
            }
        }

        private void AddGameViewModel(Meeting meeting)
        {
            var itemViewModel = new MeetingViewModel(meeting, _meetingsStore, _accountStore, _authenticatorService, _modalStore);
            _meetingViewModels.Add(itemViewModel);
        }

        public override void Dispose()
        {
            _meetingsStore.MeetingsLoaded -= MeetingsStore_Loaded;
            _meetingsStore.MeetingAdded -= MeetingsStore_Added;
            _meetingsStore.MeetingUpdated -= MeetingsStore_Updated;
            _meetingsStore.MeetingDeleted -= MeetingsStore_Deleted;
            _meetingsStore.MeetingToFavoriteAdded -= MeetingsStore_MeetingToFeatureAdded;
            _meetingsStore.MeetingFromFavoriteDeleted -= MeetingsStore_MeetingFromFeatureDeleted;

            base.Dispose();
        }
    }
}
