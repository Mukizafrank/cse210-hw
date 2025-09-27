
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create and configure video 1 - Traveling
        Video video1 = new Video("Exploring Japan: Tokyo to Kyoto", "Wanderlust Adventures", 1500);
        video1.AddComment(new Comment("Sarah", "The cherry blossom footage was breathtaking!"));
        video1.AddComment(new Comment("Mike", "Your travel tips saved me so much money on my trip!"));
        video1.AddComment(new Comment("Jessica", "Can't wait to visit Japan after watching this!"));
        video1.AddComment(new Comment("David", "The temple scenes were so peaceful and beautiful."));
        videos.Add(video1);

        // Create and configure video 2 - Gospel Music
        Video video2 = new Video("Amazing Grace: Live Gospel Choir Performance", "Heavenly Voices", 1200);
        video2.AddComment(new Comment("Pastor John", "This brought tears to my eyes. Truly uplifting!"));
        video2.AddComment(new Comment("Maria", "The harmonies were absolutely angelic."));
        video2.AddComment(new Comment("Thomas", "More gospel music videos please! This blessed my soul."));
        video2.AddComment(new Comment("Rebecca", "I felt the Holy Spirit while watching this performance."));
        videos.Add(video2);

        // Create and configure video 3 - Funny Video
        Video video3 = new Video("Cat vs Robot Vacuum: Epic Battle", "Funny Moments Daily", 600);
        video3.AddComment(new Comment("Emma", "I can't stop laughing! My cat does the same thing!"));
        video3.AddComment(new Comment("Alex", "This made my day! Shared with all my friends."));
        video3.AddComment(new Comment("Sophia", "The cat's expression at 2:30 is priceless!"));
        video3.AddComment(new Comment("Kevin", "I've watched this 10 times and still laughing!"));
        videos.Add(video3);

        // Create and configure video 4 - Podcast
        Video video4 = new Video("Mindfulness & Meditation Podcast", "Peaceful Thoughts", 2700);
        video4.AddComment(new Comment("Dr. Wilson", "Excellent discussion on mental health awareness."));
        video4.AddComment(new Comment("Lisa", "The guided meditation at the end was so helpful."));
        video4.AddComment(new Comment("Marcus", "Great guests and insightful conversation."));
        video4.AddComment(new Comment("Olivia", "This podcast has changed my daily routine for the better."));
        videos.Add(video4);

        // Iterate through the list of videos and display information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine(); // Empty line for separation
        }
    }
}