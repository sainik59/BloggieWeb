﻿using BloggieWeb.Enum;

namespace BloggieWeb.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}
