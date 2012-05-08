
namespace RavenDBReplicationSample.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dto;
    using Raven.Client;
    using RavenAccess;

    /// <summary>
    /// Example class showing how to interact with RavenDB.
    /// </summary>
    public static class BasicSampleCommands
    {
        /// <summary>
        /// Shows how to delete all records that mach a specific query in RavenDB
        /// </summary>
        internal static void DeleteAllReubenAlbumsFromRavenDb()
        {
            var session = RavenSession.OpenSession();

            var allAlbums = session.Query<Album>();

            var reubenAlbums = allAlbums.Where(x => x.Artist == "Reuben");

            foreach (var album in reubenAlbums)
            {
                Console.WriteLine("Removing '" + album.Title + "' from RavenDB");
                session.Delete(album);
            }

            RavenSession.SaveAndCloseSession(session);
        }

        /// <summary>
        /// Shows how to check the existence of an object in RavenDB then add it
        /// if it does not exist.
        /// </summary>
        internal static void AddReubenAlbumsToRavenDb()
        {
            var reubenAlbums = new List<Album>
            {
                new Album
                {
                    Title = "We Should Have Gone To University",
                    Artist = "Reuben",
                    ReleaseYear = DateTime.UtcNow.AddYears(-1)
                },
                new Album
                {
                    Title = "In Nothing We Trust",
                    Artist = "Reuben",
                    ReleaseYear = DateTime.UtcNow.AddYears(-2)
                },
                new Album
                {
                    Title = "Too Fast Too Dangerous",
                    Artist = "Reuben",
                    ReleaseYear = DateTime.UtcNow.AddYears(-3)
                },
                new Album
                {
                    Title = "Racecar is Racecar Backways",
                    Artist = "Reuben",
                    ReleaseYear = DateTime.UtcNow.AddYears(-4)
                }
            };

            var session = RavenSession.OpenSession();

            foreach (var reubenAlbum in reubenAlbums)
            {
                if (AlbumDoesntAlreadyExist(session, reubenAlbum))
                {
                    Console.WriteLine("Adding '" + reubenAlbum.Title + "' to RavenDB");
                    session.Store(reubenAlbum);
                }
                else
                {
                    Console.WriteLine("Album '" + reubenAlbum.Title + "' already exists in RavenDB");
                }
            }

            RavenSession.SaveAndCloseSession(session);
        }

        /// <summary>
        /// Gets all the Reuben albums from the database and writes out their titles.
        /// </summary>
        internal static void GetAllReubenAlbumsFromRaven()
        {
            var session = RavenSession.OpenSession();

            var allAlbums = session.Query<Album>();

            var reubenAlbums = allAlbums.Where(x => x.Artist == "Reuben");

            foreach (var album in reubenAlbums)
            {
                Console.WriteLine("Reading '" + album.Title + "' from RavenDB");
            }

            RavenSession.SaveAndCloseSession(session);
        }

        private static bool AlbumDoesntAlreadyExist(IDocumentSession session, Album reubenAlbum)
        {
            return !session.Query<Album>()
                .Any(x => x.Title == reubenAlbum.Title
                    && x.Artist == reubenAlbum.Artist);
        }
    }
}
