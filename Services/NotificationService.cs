namespace MeetAgain.Services
{
    public class NotificationService
    {
        public event Action<string>? OnNotification;

        public void SendNotification(string message)
        {
            OnNotification?.Invoke(message);
        }

        public void NotifyMeetupCreated(string meetupTitle)
        {
            SendNotification($"Meetup '{meetupTitle}' has been created!");
        }

        public void NotifyMeetupUpdated(string meetupTitle)
        {
            SendNotification($"Meetup '{meetupTitle}' has been updated!");
        }

        public void NotifyMeetupScheduled(string meetupTitle, DateTime date)
        {
            SendNotification($"Meetup '{meetupTitle}' has been scheduled for {date:MMM dd, yyyy}!");
        }

        public void NotifyAvailabilityUpdated(string friendName)
        {
            SendNotification($"{friendName} has updated their availability!");
        }
    }
}