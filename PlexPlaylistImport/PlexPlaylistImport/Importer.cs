using System;
using System.Net.Http;
using System.Text;

namespace PlexPlaylistImport
{
    /// <summary>Class Importer.</summary>
    internal class Importer
    {

        private static readonly HttpClient client = new HttpClient();

        /// <summary>Processes the playlist.</summary>
        /// <param name="ServerUrl">The server URL.</param>
        /// <param name="Token">The token.</param>
        /// <param name="SectionId">The section identifier.</param>
        /// <param name="PlaylistPath">The playlist path.</param>
        internal async void ProcessPlaylist(string ServerUrl, string Token, int SectionId, string PlaylistPath)
        {

            string result;
            StringBuilder path = new StringBuilder();

            // Add slash if not present in provided URL input
            if (ServerUrl.Substring(ServerUrl.Length - 1) == "/")
            {
                path.Append(ServerUrl);
            }
            else
            {
                path.Append($"{ServerUrl}/");
            }

            // Build path for playlist endpoint
            path.Append($"playlists/upload?sectionID={SectionId}&path={PlaylistPath}&X-Plex-Token={Token}");

            System.Diagnostics.Debug.WriteLine(path.ToString(), "Path");

            try
            {
                // Send POST request
                var response = client.PostAsync(path.ToString(), null).Result;

                // Await response
                var responseString = await response.Content.ReadAsStringAsync();

                // Write to debugger
                System.Diagnostics.Debug.WriteLine(response, "Response");

                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        result = "Command successfully sent to PLEX";
                        break;
                    default:
                        result = $"Unexpected result of request ({response.StatusCode})";
                        Console.WriteLine($"Errors occurred while processing request. {response.StatusCode}\n{response.RequestMessage?.RequestUri?.AbsoluteUri}");
                        break;
                }
            }
            catch (Exception ex)
            {
                result = $"Errors occurred while processing request. {ex.Message}";
                System.Diagnostics.Debug.WriteLine(ex.ToString(), "Exception");
                Console.WriteLine($"Errors occurred while processing request. {ex}");
            }
        }

    }
}
