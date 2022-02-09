namespace PlatformerFNAEnvato
{
    public class App
    {
        public static void Main(string[] args)
        {
            using (FNAgame g = new FNAgame())
            {
                g.Run();
            }
        }
    }
}
