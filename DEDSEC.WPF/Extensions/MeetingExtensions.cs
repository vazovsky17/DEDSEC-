using DEDSEC.Domain.Models;
using DEDSEC.WPF.ViewModels.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DEDSEC.WPF.Extensions
{
    public static class MeetingExtensions
    {
        /// <summary>
        /// Установка отображаемого заголовка встречи
        /// </summary>
        /// <param name="meeting">Встреча</param>
        /// <returns>Строка с заголовком встречи</returns>
        public static string SetTitleDisplay(this Meeting meeting)
            => !string.IsNullOrEmpty(meeting.Title) ? meeting.Title : "Заголовок не был добавлен";

        /// <summary>
        /// Установка отображаемого описания встречи
        /// </summary>
        /// <param name="meeting">Встреча</param>
        /// <returns>Строка с описанием встречи</returns>
        public static string SetDescriptionDisplay(this Meeting meeting)
            => !string.IsNullOrEmpty(meeting.Title) ? meeting.Title : "Описание не было добавлено";


        /// <summary>
        /// Установка отображаемых дат проведения встречи
        /// </summary>
        /// <param name="meeting">Встреча</param>
        /// <returns>Строка с датами проведения встречи</returns>
        public static string SetDatesDisplay(this Meeting meeting)
        {
            var dateBegin = meeting.DateBegin;
            var dateEnd = meeting.DateEnd;

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
        /// Установка отображаемой даты проведения встречи
        /// </summary>
        /// <param name="meeting">встреча</param>
        /// <param name="dateTime">дата</param>
        /// <returns>Строка с датой проведения встречи</returns>
        public static string SetDateDisplay(this Meeting meeting, DateTime dateTime) => dateTime.ToString("t") + " " + dateTime.ToString("M");


        /// <summary>
        /// Установка отображаемого максимального количества участников встречи
        /// </summary>
        /// <param name="meeting">Встреча</param>
        /// <returns>Строка с максимальным количеством участников</returns>
        public static string SetCountVisitorsDisplay(this Meeting meeting)
        {
            if (meeting.MaxCountVisitors >= 20)
            {
                return "Не ограничено";
            }
            else
            {
                return meeting.MaxCountVisitors + " человек";
            }
        }

        /// <summary>
        /// Выявление, есть ли встреча в запланированных у пользователя
        /// </summary>
        /// <param name="meeting">Всетрча</param>
        /// <param name="featureMeetings">Список запланированных встреч</param>
        /// <returns>Собирается ли пользователь идти на встречу</returns>
        public static bool IsUserFeatureMeeting(this Meeting meeting, List<Meeting> featureMeetings)
        {
            foreach (var item in featureMeetings)
            {
                if (item.Id == meeting.Id) return true;
            }
            return false;
        }

        public static string setMeetingsViewModelsCountDisplay(this IEnumerable<MeetingViewModel> meetingViewModels)
        {
            var count = meetingViewModels.Count();
            return count + " " + Pluralize(count);
        }

        private static string Pluralize(int num)
        {
            if (num % 10 == 1 && num != 11)
            {
                return "встреча";
            }
            else if ((num >= 2 && num <= 4) || (num % 10 <= 4 && num % 10 >= 2))
            {
                return "встречи";
            }
            else
            {
                return "встреч";
            }
        }
    }
}
