
namespace RavenDBReplicationSample.Sample
{
    using System.Collections.Generic;
    using System.Configuration;
    using Dto;
    using RavenAccess;

    /// <summary>
    /// Example class showing how to interact with RavenDB.
    /// </summary>
    public static class Replication
    {
        private const string REPLICATION_DESTINATIONS_ID = "Raven/Replication/Destinations";

        /// <summary>
        /// Shows how to delete all records that mach a specific query in RavenDB
        /// </summary>
        internal static void SetupReplicationDestination()
        {
            var session = RavenSession.OpenSession();

            var allAlbums = session.Load<ReplicationDestinations>(REPLICATION_DESTINATIONS_ID);

            allAlbums.Destinations = new List<Destination>
                {
                    new Destination
                        {
                            Url = ConfigurationManager.ConnectionStrings["RavenDBReplicated"].ConnectionString
                        }
                };

            session.SaveChanges();

            RavenSession.SaveAndCloseSession(session);
        }
    }
}
