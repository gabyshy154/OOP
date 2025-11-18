using System;

namespace MeetAgain.Client.Services
{
    public class NotificationService
    {
        public event Action<string>? OnNotification;

        public void Send(string message) => OnNotification?.Invoke(message);

        public void NotifyMeetupCreated(string title)
            => Send($"✅ Meetup '{title}' has been created!");

        public void NotifyMeetupUpdated(string title)
            => Send($"✏️ Meetup '{title}' has been updated.");

        public void NotifyMeetupScheduled(string title, DateTime date)
            => Send($"📅 Meetup '{title}' scheduled for {date:MMM dd, yyyy}.");

        public void NotifyAvailabilityUpdated(string friendName)
            => Send($"👤 {friendName} updated their availability.");
    }
}
