using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohTradingCars.Repositorys
{
    public class EventRepository
    {
        /// <summary>
        /// Trigger to set the Message on Main window 
        /// </summary>
        public event EventHandler<string?> MainWindowMessage;

        #region Singelton

        private static EventRepository? eventRepository;
        public static EventRepository Instance
        {
            get
            {
                if (eventRepository is null)
                    eventRepository = new();

                return eventRepository;
            }
        }

        #endregion

        public void TriggerMainWindowMessage(string? message)
        {
            this.MainWindowMessage?.Invoke(this, message);
        }
    }
}
