using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Meetings;
using DEDSEC.WPF.Stores;
using System;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingViewModel : ViewModelBase
    {
        public bool IsAdmin { get; }
        public Meeting Meeting { get; private set; }

        public Guid Id => Meeting.Id;
        public string Title => SetTitleDisplay(Meeting.Title);
        public string Description => SetDescriptionDisplay(Meeting.Description);

        public DateTime DateBegin => Meeting.DateBegin;
        public DateTime DateEnd => Meeting.DateEnd;
        public string DatesDisplay => SetDatesDisplay(DateBegin, DateEnd);

        public int MaxCountVisitors => Meeting.MaxCountVisitors;
        public string MaxCountVisitorsDisplay => SetCountVisitorsDisplay(MaxCountVisitors);

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MeetingViewModel(Meeting meeting, MeetingsStore meetingsStore, bool isAdmin)
        {
            IsAdmin = isAdmin;
            Meeting = meeting;

            //EditCommand = new NavigateCommand();
            DeleteCommand = new DeleteMeetingCommand(meetingsStore, meeting);
        }

        public void Update(Meeting meeting)
        {
            Meeting = meeting;

            OnPropertyChanged(nameof(Meeting));
        }

        /// <summary>
        /// Установка отображаемого заголовка встречи
        /// </summary>
        /// <param name="title">Заголовок, если есть</param>
        /// <returns>Строка с заголовком встречи</returns>
        private string SetTitleDisplay(string? title) => (title != null && title.Length > 0) ? title : "Заголовок не был добавлен";

        /// <summary>
        /// Установка отображаемого описания встречи
        /// </summary>
        /// <param name="description">Описание, если есть</param>
        /// <returns>Строка с описанием встречи</returns>
        private string SetDescriptionDisplay(string? description) => (description != null && description.Length > 0) ? description : "Описание не было добавлено";

        /// <summary>
        /// Установка отображаемых дат проведения встречи
        /// </summary>
        /// <param name="dateBegin">Дата начала встречи</param>
        /// <param name="dateEnd">Дата окончания встречи</param>
        /// <returns>Строка с датами проведения встречи</returns>
        private string SetDatesDisplay(DateTime dateBegin, DateTime dateEnd)
        {
            if (dateBegin.DayOfYear == dateEnd.DayOfYear)
            {
                return dateBegin.ToString("M") + " " + dateBegin.ToString("t") + " - " + dateEnd.ToString("t");
            }
            else
            {
                return dateBegin.ToString("M") + " " + dateBegin.ToString("t") + " - " + dateEnd.ToString("M") + " " + dateEnd.ToString("t");
            };
        }


        /// <summary>
        /// Установка отображаемого максимального количества участников встречи
        /// </summary>
        /// <param name="maxCountVisitors">Максимальное количество посетителей</param>
        /// <returns>Строка с максимальным количеством участников</returns>
        private string SetCountVisitorsDisplay(int maxCountVisitors)
        {
            if (maxCountVisitors > 20)
            {
                return "Не ограничено";
            }
            else
            {
                return maxCountVisitors + " человек";
            }
        }

    }
}

