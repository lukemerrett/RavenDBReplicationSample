namespace RavenDBReplicationSample.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// DTO matching the replication destinations stored in RavenDB when using the Replication Bundle.
    /// </summary>
    public class ReplicationDestinations
    {
        public List<Destination> Destinations { get; set; }
    }
}
