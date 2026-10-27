# Network Programming

This elective module demonstrates how C# programs exchange data over a network (Chapter 21, page 1497). All tests run without an Internet connection: `HttpClient` communicates with a test `HttpMessageHandler`, and sockets connect via `127.0.0.1` on an available port. The book does not include any exercises in this chapter; the exercises are new.

## Basic Concepts (21.1, pages 1497–1505)

The OSI model divides data transmission into seven layers (21.1.1): from bit transmission through data link (Ethernet) and network (IP) to the application layer (HTTP, DNS). In practice, the protocol stack model (21.1.2) applies: Each layer encapsulates the data from the layer above it. The transport layer distinguishes between TCP (connection-oriented, reliable) and UDP (connectionless); a **port number** identifies a specific program on a computer, while an **IP address** identifies the computer itself. **DNS** translates hostnames into IP addresses. C# provides classes for all of these in the `System.Net` namespace (21.1.3).

## URI and URL (21.2, page 1505)

The `Uri` class breaks down an address into schema, host, port, path, query, and fragment; it fills in missing default ports (80 for `http`, 443 for `https`) and encodes spaces as `%20`. An invalid string throws a `UriFormatException`. Parameters in the query start with `?` and are separated by `&`; characters such as `&` or `=` in a value must therefore be encoded. The calls for this (`Uri.EscapeDataString`, `Uri.UnescapeDataString`, `Uri.TryCreate`) are not in the book; exercise 2 provides them (see Deep Dive).

## HttpClient (21.3, pages 1506–1516)

`HttpClient` retrieves web resources. You create **an** object and reuse it (page 1507): Creating a new client for each request wastes connections and can exhaust ports. Request methods include `GET` (read), `POST` (send, create), `HEAD` (headers only, e.g., to check for existence), and others (21.3.1). `GetStringAsync` returns the text, while `GetAsync` returns the entire response with a status code: 2xx success, 3xx redirection, 4xx client error, 5xx server error. `EnsureSuccessStatusCode()` throws an `HttpRequestException` with the `StatusCode` if it fails. The book transfers JSON with `JsonSerializer` and `StringContent` (21.3.3); with `PropertyNamingPolicy = JsonNamingPolicy.CamelCase` (16.5) the names match the usual JSON style (shorter: see Deep Dive). The methods are asynchronous (`Task<T>`); `await` is used to wait for the result without blocking a thread.

## IP Addresses and Host Names (21.5, page 1523)

`Dns.GetHostEntryAsync` and `Dns.GetHostAddressesAsync` resolve a name into IP addresses (`localhost` works even without an Internet connection); an IPv4 address has 32 bits, an IPv6 address 128 bits. The class `IPAddress` represents an address (`IPAddress.IPv6Any` for all addresses of a server, 21.6.1).

## Sockets (21.6, pages 1525–1536)

A `TcpListener` waits for connections on a port; `AcceptTcpClient()` returns a `TcpClient` whose `NetworkStream` can be used like a file with `StreamReader` and `StreamWriter` (21.6.1, 21.6.2). This results in a line-based protocol: The client sends a line, and the server responds with a line. Important: `AutoFlush = true`; otherwise, responses remain in the buffer. Additionally, `ReadLine()` returns `null` if the other end closes the connection. A server that serves only one client at a time makes the next one wait; for multiple clients simultaneously, each connection requires its own task (21.6.3, page 1531).

## WebView2 (21.4, page 1516)

The `WebView2` control embeds a browser into a WPF application. It requires Windows and the WebView2 runtime; the exercise on it is checked by the supervisor.

## Deep Dive (optional)

> Not in the book. These topics are optional – examples of what to look into next.

- **Working with addresses:** `Uri.EscapeDataString` and `Uri.UnescapeDataString` encode values for the query and back, `Uri.TryCreate` returns `false` instead of throwing, `UriBuilder` assembles addresses from parts (exercise 2 and the Deep Dive exercise URL Collector).
- **Checking IP addresses:** `IPAddress.TryParse`, `IPAddress.IsLoopback` and `GetAddressBytes()` (exercise 2 provides them).
- **JSON in one call:** `GetFromJsonAsync<T>`, `PostAsJsonAsync` and `ReadFromJsonAsync<T>` from `System.Net.Http.Json` replace `JsonSerializer` plus `StringContent`; they use camelCase names on their own.
- **Testing HttpClient without a network:** A custom `HttpMessageHandler` passed to the `HttpClient` constructor records requests and returns prepared responses; this is how the tests of this level work.
