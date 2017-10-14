@ECHO OFF
del *.nupkg
.\nuget.exe pack .\SegmentDownloader.Core.nuspec
.\nuget.exe pack .\SegmentDownloader.Extension.nuspec