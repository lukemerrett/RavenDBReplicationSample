namespace RavenDBReplicationSample
{
    using System;
    using Sample;

    public class Program
    {
        public static void Main(string[] args)
        {
            Replication.SetupReplicationDestination();

            SetupDummyDataToReplicate();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine(); // Pause execution
        }

        private static void SetupDummyDataToReplicate()
        {
            BasicSampleCommands.DeleteAllReubenAlbumsFromRavenDb();
            BasicSampleCommands.AddReubenAlbumsToRavenDb();
            BasicSampleCommands.GetAllReubenAlbumsFromRaven();
        }
    }
}
