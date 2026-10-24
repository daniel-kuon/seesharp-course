# Multiple Clients and WebView2

This exercise will be graded by the supervisor; there are no tests. The second part of the exercise requires Windows. Read sections **21.6.3 “Simultaneous Service of Multiple Clients”** (page 1531) and **21.4 “Browser via WebView2 Control”** (page 1516) along with **21.4.2 “WPF Program with WebView2 Control”** (page 1518). Templates in the book’s sample folder: `Netzwerk/Socket/TcpServerTPL` and `Netzwerk/WebView2`.

**Part 1: Multiple Clients**

1. The server from Exercise 4 serves exactly one client and then terminates. Modify it (in a separate console project that references your library): An **acceptance loop** repeatedly calls `AcceptTcpClient()` and passes each accepted client to a separate task that serves it line by line (like `BedieneEinenKlienten`, but for the client that has already been accepted).
2. Start the server in one terminal and two clients in two other terminals (for example, two console programs that call `Klient.Frage`, or `ncat 127.0.0.1 <Port>`). Both clients must be connected at the same time and receive responses.
3. Think about how to shut down the server properly (for example, using `listener.Stop()` and catching the `SocketException` in the loop, or using a termination signal).
4. Answer the open-ended question about the sequential server.

Here, you're using tasks and threads only as tools (`Task.Run(...)`); the elective module on multithreading explains them in more detail, but it is not a prerequisite.

**Part 2: WebView2 (Windows only)**

Build a small WPF application (`net10.0-windows`) with a `WebView2` control that displays the local address of a page that is currently running. Refer to sections 21.4.1 (WebView2 Runtime) and 21.4.2.3 (what happens if the runtime is missing).
