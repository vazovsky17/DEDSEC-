using DEDSEC.Domain.Models;
using System;

namespace DEDSEC.WPF.Stores
{
    public class MeetingsStore
    {
        public event Action<Meeting> MeetingAdded;

        public void AddMeeting(Meeting meeting)
        {
            MeetingAdded?.Invoke(meeting);
        }
    }
}
