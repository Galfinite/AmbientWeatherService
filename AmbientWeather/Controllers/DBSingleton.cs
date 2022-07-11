namespace AmbientWeather.Controllers
{
    //pS9UCznx4C#9
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }

        public void InsertData(List<KeyValuePair<string, string>> values)
        {
            foreach (var element in values)
            {
                System.Diagnostics.Debug.WriteLine(element);
            }
        }
    }
}
