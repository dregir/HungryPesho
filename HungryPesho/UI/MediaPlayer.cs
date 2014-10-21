namespace HungryPesho.UI
{
    using System;
    using System.Media;
    using HungryPesho.Engine;

    public enum Sound
    {
        Intro,
        Hit,
        Miss,
        Strike,
        Win,
        Lose,
        Credits,
        Ranklist,
        Click,
        Enter,
        Freeze,
        Death,
        Slam
    }

    public static class MediaPlayer
    {
        private static SoundPlayer player;

        internal static void Play(UI.Sound sound)
        {
            if (GameSettings.SoundStatus)
            {
                try
                {
                    player = new SoundPlayer(GameSettings.FilePath + sound + ".wav");
                    player.Play();
                }
                catch (Exception e)
                {
                    Console.WriteLine("File {0} not found or cannot be opened! \r\n{1}", sound, e.Message);
                }
            }
        }
    }
}