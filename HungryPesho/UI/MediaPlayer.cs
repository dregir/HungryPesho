namespace HungryPesho.UI
{
    using System;
    using System.Media;
    using HungryPesho.Engine;

    public enum Sound
    {
        INTRO,
        HIT,
        MISS,
        STRIKE,
        WIN,
        LOSE,
        CREDITS,
        RANKLIST,
        CLICK,
        ENTER,
        FREEZE,
        DEATH,
        SLAM
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