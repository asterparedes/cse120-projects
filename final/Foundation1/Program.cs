using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video();
        video1._title = "Crochet Tutorial";
        video1._author = "SirinCrochet";
        video1._length = 500;
        video1._comments.Add(new Comment("Jane","Good job!"));
        video1._comments.Add(new Comment("Ashley","I enjoyed the video."));
        video1._comments.Add(new Comment("Mark","I learned something new. Thank you!"));

        Video video2 = new Video();
        video2._title = "Cooking Video";
        video2._author = "Tasty";
        video2._length = 550;
        video2._comments.Add(new Comment("Ramon","Looks good!"));
        video2._comments.Add(new Comment("Andrew","Amazing video!"));
        video2._comments.Add(new Comment("Jess","Interesting to watch."));

        Video video3 = new Video();
        video3._title = "C# Tutorial";
        video3._author = "FreeCodeCamp";
        video3._length = 730;
        video3._comments.Add(new Comment("John","Well thought explanation!"));
        video3._comments.Add(new Comment("Jimmy","This is a great idea."));
        video3._comments.Add(new Comment("Albert","A very helpful content."));

        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        
        foreach(Video video in videos)
        {
            video.DisplayAll();
        }
        
    }
}