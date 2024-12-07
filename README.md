# PlexPlaylistImport
.Net 8.0 console application to import Plex music playlists

# Why
While its fairly simple to use Postman or CURL to insert a playlist if you have a handful of playlists a commandline tool helps import playlists quickly.

# Related projects
This project was based on the https://github.com/gregchak/plex-playlist-import Windows Store application.

# Usage
plexplaylistimport.exe /s[ServerURL] /x[X-Plex-Token] /i[SectionID] /p[Local Playlist Path]

Example: 
PlexPlaylistImport.exe /shttp://localhost:32400/ /sdsdsdsafyhwe8fgh78w474 /i3 /pC:\playlist\top40.m3u
