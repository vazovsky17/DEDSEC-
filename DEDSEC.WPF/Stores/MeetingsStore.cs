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
        private readonly List<Meeting> _meetings;
        public IEnumerable<Meeting> Meetings => _meetings;

        public event Action MeetingsLoaded;
        public event Action<Meeting> MeetingAdded;
        public event Action<Meeting> MeetingUpdated;
        public event Action<Guid> MeetingDeleted;

        public MeetingsStore(IDataService<Meeting> dataService)
        {
            _meetings = new();
            _dataService = dataService;
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
    }
}
