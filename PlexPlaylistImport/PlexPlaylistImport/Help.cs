using System;

namespace PlexPlaylistImport
{
    /// <summary>Class Help.</summary>
    internal class Help
    {
        /// <summary>Screens this instance.</summary>
        internal static void Screen()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("|                Plex Playlist Import              |");
            Console.WriteLine("| Usage:                                           |");
            Console.WriteLine("| plexplaylistimport.exe /s[ServerURL]             |");
            Console.WriteLine("| /x[X-Plex-Token] /i[SectionID]                   |");
            Console.WriteLine("| /p[Local Playlist Path]                          |");
            Console.WriteLine("----------------------------------------------------");
            Environment.Exit(1);
        }
    }
}
