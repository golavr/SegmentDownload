# SegmentDownloader

Forked from [guilhermelabigalini/mydownloader](https://github.com/guilhermelabigalini/mydownloader)

MyDownloader from CodeProject http://www.codeproject.com/Articles/21053/MyDownloader-A-Multi-thread-C-Segmented-Download-M

![MyDwnloader1](src/docs/MyDwnloader1.png)

## Packages are available on Nuget
- Maintain nuget packages - TODO.
- Fix large file size issues.
- Set EndedWithError state when reaching max retries.
- Fix network failure during segments download - override default value of 5 minutes and set stream timeout value to 30 sec.
