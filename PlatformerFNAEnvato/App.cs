using System;

namespace PlatformerFNAEnvato
{
    public class App
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (FNAgame g = new FNAgame())
            {
                g.Run();
            }
        }
    }
}
