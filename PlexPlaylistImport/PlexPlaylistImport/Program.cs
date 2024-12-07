namespace PlexPlaylistImport;

using System;

/// <summary>Class Program.</summary>
class Program
{
    /// <summary>Gets or sets the server URL.</summary>
    /// <value>The server URL.</value>
    internal static string ServerURL { get; set; }

    /// <summary>Gets or sets the x plex token.</summary>
    /// <value>The x plex token.</value>
    internal static string XPlexToken { get; set; }

    /// <summary>Gets or sets the section identifier.</summary>
    /// <value>The section identifier.</value>
    internal static int SectionId {  get; set; }

    /// <summary>Gets or sets the playlist path.</summary>
    /// <value>The playlist path.</value>
    internal static string PlaylistPath { get; set; }

    /// <summary>Defines the entry point of the application.</summary>
    /// <param name="args">The arguments.</param>
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Help.Screen();
        }
        else
        {
            foreach (var ag in args)
            {
                if ((ag == "/h") | (ag == "/H") | (ag == "/?"))
                {
                    Help.Screen();
                    return;
                }

                if ((ag.Substring(0, 2) == "/s") | (ag.Substring(0, 2) == "/S"))
                {
                    // Server URL
                    ServerURL = ag.Substring(2, ag.Length - 2);
                }

                if ((ag.Substring(0, 2) == "/x") | (ag.Substring(0, 2) == "/X"))
                {
                    // X-Plex-Token
                    XPlexToken = ag.Substring(2, ag.Length - 2);
                }

                if ((ag.Substring(0, 2) == "/i") | (ag.Substring(0, 2) == "/I"))
                {
                    // Section ID must be Int
                    SectionId = Convert.ToInt32(ag.Substring(2, ag.Length - 2));
                }

                if ((ag.Substring(0, 2) == "/p") | (ag.Substring(0, 2) == "/P"))
                {
                    // Playlist Path
                    PlaylistPath = ag.Substring(2, ag.Length - 2);
                }
            }

            if (ServerURL.Length > 0
                && XPlexToken.Length > 0
                && SectionId > -1
                && PlaylistPath.Length > 0 )
            {
                // kick off job
                var importer = new Importer();
                importer.ProcessPlaylist(ServerURL, XPlexToken, SectionId, PlaylistPath);
            }
            else
            {
                Help.Screen();
                return;
            }
        }
    }
}