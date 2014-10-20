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
        ENTER
    }

    public static class MediaPlayer
    {
        private static SoundPlayer player;

        internal static void Play(UI.Sound sound)
        {
            if (true) // TODO: If Sound is on in settings
            {
                player = new SoundPlayer(GameSettings.FilePath + sound + ".wav");
                player.Play();
            }
        }
    }
}