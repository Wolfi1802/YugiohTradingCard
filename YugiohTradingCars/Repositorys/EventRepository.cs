namespace YugiohTradingCars.Repositorys
{
    public class EventRepository
    {
        /// <summary>
        /// Triggered, when Loading ist done, should be use to switch from splash Page to main page
        /// </summary>
        public event EventHandler LoadingDone;

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

        public void TriggerLoadingDone()
        {
            this.LoadingDone?.Invoke(this, null);
        }
    }
}
