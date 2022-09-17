﻿using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Meetings;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Stores;
using System;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingViewModel : ViewModelBase
    {
        public bool IsAdmin { get; }
        public Meeting Meeting { get; private set; }

        #region Bindings
        public Guid Id => Meeting.Id;
        public string Title => Meeting.SetTitleDisplay();
        public string Description => Meeting.SetDescriptionDisplay();
        public string DatesDisplay => Meeting.SetDatesDisplay();
        public string MaxCountVisitorsDisplay => Meeting.SetCountVisitorsDisplay();
        #endregion

        #region Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        public MeetingViewModel(Meeting meeting,
            MeetingsStore meetingsStore,
            ModalNavigationStore modalStore,
            bool isAdmin)
        {
            IsAdmin = isAdmin;
            Meeting = meeting;

            EditCommand = new OpenEditMeetingCommand(this, meetingsStore, modalStore);
            DeleteCommand = new DeleteMeetingCommand(meetingsStore, meeting);
        }

        public void Update(Meeting meeting)
        {
            Meeting = meeting;

            OnPropertyChanged(nameof(Meeting));
        }

    }
}

