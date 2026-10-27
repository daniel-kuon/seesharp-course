# File Processing and JSON

Chapter 16 (page 1013) shows how a program stores data permanently: in files, as bytes, as text, and as JSON. All of this is held together by the concept of **a data stream** and the obligation to release external resources.

## Data streams consisting of bytes (16.1, pages 1013–1026)

A `Stream` is a sequence of bytes with a position. The base class provides `Read`, `Write`, `Seek`, and `Flush`; a `FileStream` (16.1.4, page 1018) binds them to a file. When opening a file, `FileMode` specifies what happens to the file (`Create`, `CreateNew`, `Open`, `OpenOrCreate`, `Append`, `Truncate`), `FileAccess` specifies what the object is allowed to do, and `FileShare` specifies what others are allowed to do. `Read` returns the number of bytes actually read (0 at the end): anyone who always uses the entire buffer writes garbage.

## Releasing Resources (16.2, page 1026; 5.4.5, page 355)

The garbage collector frees up memory, but not at a specific time; a file remains locked until someone calls `Dispose()` (or `Close()`) or the garbage collector eventually cleans up. The **using statement** (16.2.3, page 1027) is a shorthand for `try/finally` with `Dispose()`; the **using declaration** (16.2.4, page 1030) remains in effect until the end of the enclosing block. Nested resources are released in reverse order. Custom classes that hold a resource implement `IDisposable`: `Dispose()` is idempotent; after that, any further use throws an `ObjectDisposedException`. A finalizer is only needed if you hold unmanaged resources directly.

## Binary and Text (16.3, pages 1032–1041)

`BinaryWriter` and `BinaryReader` (16.3.1, page 1032) write and read values of primitive types in their binary format (an `int` is 4 bytes, a `double` is 8 bytes). `StreamWriter` and `StreamReader` (16.3.2, page 1036) work with text and a character encoding: If not specified, UTF-8 is used; the encoding is not stored in the file (at most a BOM reveals UTF-8 or UTF-16). Windows-1252 is only provided by the `CodePagesEncodingProvider` (16.3.3, page 1040): after `Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)`, use `Encoding.GetEncoding(1252)`. `ReadLine()` returns `null` at the end of the file. A `StreamWriter` buffers; `Flush()` empties the buffer; `AutoFlush = true` does this after every write (safe, but slow with large amounts of data; Exercise 16.7/2, page 1060).

## Small Files and Culture (16.4, page 1041)

`File.ReadAllText`, `ReadAllLines`, `ReadAllBytes`, `WriteAllText`, `WriteAllLines`, and `AppendAllText` handle opening, reading or writing, and closing in a single call. Numbers in files are parsed and formatted using `CultureInfo.InvariantCulture`; otherwise, the computer's language settings determine the result: `"1.5"` equals 15 under `de-DE`.

## JSON (16.5, pages 1043–1051)

`JsonSerializer.Serialize` and `Deserialize<T>` (System.Text.Json, part of the framework) convert public properties to JSON and back. `JsonSerializerOptions` control indentation, camelCase, and enums as text; `[JsonPropertyName]` and `[JsonIgnore]` control individual properties. Unknown JSON fields are ignored during parsing. Circular references cause serialization to fail unless you set `ReferenceHandler.IgnoreCycles` or `Preserve` (16.5.5, page 1050).

## Files and Folders (16.6, pages 1052–1058)

`File`, `Directory`, and `Path` manage the file system: copying, moving, deleting, creating folders, and listing them. Paths are built with `Path.Combine` (an absolute part discards everything before it) and taken apart with `GetFileName`, `GetExtension`, and `GetRelativePath`. `Path.GetTempPath()` and `Environment.GetFolderPath(…)` provide special folders; `DriveInfo` and `FileSystemWatcher` (16.6.5, 16.6.6) are demonstration material only. In the exercises, each test runs in its own temp folder, whose name contains spaces, commas, and umlauts.

Further study in the book: Chapter 16 (pages 1013–1060); the exercises in 16.7 (page 1060) provide the column averages and the AutoFlush question for this level.
