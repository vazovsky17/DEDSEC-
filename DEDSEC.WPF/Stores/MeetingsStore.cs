using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class MeetingsStore
    {
        private readonly IDataService<Meeting> _dataService;
        private readonly AccountStore _accountStore;
        private readonly List<Meeting> _meetings;
        public IEnumerable<Meeting> Meetings => _meetings;

        public event Action MeetingsLoaded;
        public event Action<Meeting> MeetingAdded;
        public event Action<Meeting> MeetingUpdated;
        public event Action<Guid> MeetingDeleted;
        public event Action<Meeting> MeetingToFavoriteAdded;
        public event Action<Meeting> MeetingFromFavoriteDeleted;

        public MeetingsStore(IDataService<Meeting> dataService,
            AccountStore accountStore)
        {
            _meetings = new();
            _dataService = dataService;
            _accountStore = accountStore;
        }

        public async Task Load()
        {
            IEnumerable<Meeting> meetings = await _dataService.GetAll();
            _meetings.Clear();
            _meetings.AddRange(meetings);
            MeetingsLoaded?.Invoke();
        }

        public async Task Add(Meeting meeting)
        {
            await _dataService.Create(meeting);
            _meetings.Add(meeting);
            MeetingAdded?.Invoke(meeting);
        }

        public async Task Update(Meeting meeting)
        {
            await _dataService.Update(meeting.Id, meeting);
            _meetings.Add(meeting);
            MeetingUpdated?.Invoke(meeting);
        }

        public async Task Delete(Meeting meeting)
        {
            await _dataService.Delete(meeting.Id);
            _meetings.Remove(meeting);
            MeetingDeleted?.Invoke(meeting.Id);
        }

        public async Task AddToFeature(Meeting meeting)
        {
            await _accountStore.AddToFeatureMeetings(meeting).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    MeetingToFavoriteAdded?.Invoke(meeting);
                }
            });
        }

        public async Task DeleteFromFeature(Meeting meeting)
        {
            await _accountStore.DeleteFromFeatureMeetings(meeting).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    MeetingFromFavoriteDeleted?.Invoke(meeting);
                }
            });
        }
    }
}
