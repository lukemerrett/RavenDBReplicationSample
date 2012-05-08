A Note on NuGet Packages
========================
Usually you would have to get this package through NuGet; however one dependency in this project is the replication bundle which is stored in "packages\RavenDB.1.0.888\server\Plugins".  Due to this I've included the package rather than just the config.

Starting the RavenDB Server Locally
===================================

Go to "packages/RavenDB.xx/server/Raven.Server.exe" and run it.

Then update the App.Config file of the sample application so the RavenDB connection string points to the connection string presented in the command window under "Server Url:"


Starting the RavenDB Server To Replicate To Locally
===================================================

Go to "packages/RavenDB.xx/replicatedserver/Raven.Server.exe" and run it.

Then update the App.Config file of the sample application so the RavenDBReplicated connection string points to the connection string presented in the command window under "Server Url:"


Managing the RavenDB Server
===========================

If you go to the server url given in the command window; it will give you a silverlight interface for managing the database.


Adding Replication Destinations
===============================

This is stored in the RavenDB server (Master server here) under "Raven/Replication/Destinations".  In order to allow this locally; I've changed the App.Config of the replicated server so it allows All access to be anonymous.