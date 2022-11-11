﻿namespace CvBuilder.Core.Entities
{
    public class AboutMe
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}