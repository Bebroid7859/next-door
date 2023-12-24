using NetCoreAudio;

namespace NextDoor
{
    public static class Audio
    {
        static string currentMusic = "sex";

        static Player music = new();

        public static void PlaySound(string path) { var sound = new Player(); sound.Play(path); sound = null; GC.Collect(); }
        public static void SetBackgroundMusic(string path, int duration) { currentMusic = path; music.Stop(); _ = Task.Run(() => MusicLoop(path, duration)); }
        public static async void MusicLoop(string path, int duration)
        {
            while (currentMusic == path)
            {
                if (currentMusic == path)
                {
                    await music.Play(path);
                    await Task.Delay(duration * 1000);
                }
            }
        }
    }
}