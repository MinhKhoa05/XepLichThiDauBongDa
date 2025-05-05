using System;

namespace DTO
{
    public class NotificationDTO
    {
        public int NotificationID { get; private set; }
        public int UserID { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public bool IsRead { get; private set; }

        public NotificationDTO() { }

        public NotificationDTO(int notificationID, int userID, string title, string content, DateTime createdAt, bool isRead)
        {
            NotificationID = notificationID;
            UserID = userID;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            IsRead = isRead;
        }
    }
}