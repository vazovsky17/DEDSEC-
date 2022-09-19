using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Meetings;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingViewModel : ViewModelBase
    {
        public AccountStore AccountStore { get; }
        public Meeting Meeting { get; private set; }

        #region Bindings
        public Guid Id => Meeting.Id;
        public string Title => Meeting.SetTitleDisplay();
        public string Description => Meeting.SetDescriptionDisplay();
        public string DateBegin => Meeting.SetDateDisplay(Meeting.DateBegin);
        public string DateEnd => Meeting.SetDateDisplay(Meeting.DateEnd);
        public string MaxCountVisitorsDisplay => Meeting.SetCountVisitorsDisplay();
        public bool IsFeature => Meeting.IsUserFeatureMeeting(FeatureMeetings);
        public bool IsUnfeature => !Meeting.IsUserFeatureMeeting(FeatureMeetings);
        #endregion

        #region Commands
        public ICommand AddToFeatureCommand { get; }
        public ICommand DeleteFromFeatureCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        #region Account
        public Account CurrentAccount => AccountStore.CurrentAccount;
        public List<Meeting> FeatureMeetings => CurrentAccount.FeatureMeetings ?? new();
        public bool IsAdmin => CurrentAccount.AccountHolder?.IsAdmin ?? false;
        #endregion

        public MeetingViewModel(Meeting meeting,
            MeetingsStore meetingsStore,
            AccountStore accountStore,
            IAuthenticatorService authenticatorService,
            ModalNavigationStore modalStore)
        {
            Meeting = meeting;
            AccountStore = accountStore;

            AddToFeatureCommand = new AddToFeatureCommand(meeting, meetingsStore, authenticatorService);
            DeleteFromFeatureCommand = new DeleteFromFeatureCommand(meeting, meetingsStore, authenticatorService);
            EditCommand = new OpenEditMeetingCommand(this, meetingsStore, modalStore);
            DeleteCommand = new DeleteMeetingCommand(meetingsStore, accountStore, meeting);
        }

        public void UpdateIsUserFeature()
        {
            OnPropertyChanged(nameof(CurrentAccount));
            OnPropertyChanged(nameof(FeatureMeetings));
            OnPropertyChanged(nameof(IsFeature));
            OnPropertyChanged(nameof(IsUnfeature));
        }

        public void Update(Meeting meeting)
        {
            Meeting = meeting;

            OnPropertyChanged(nameof(Meeting));
        }

    }
}

