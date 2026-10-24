# Multithreading and Asynchronous Programming

A program that performs multiple tasks at the same time uses multiple threads (Chapter 17, page 1061). This level is an elective module and is one of the most challenging in the course because errors here are random: the same code sometimes produces the correct result and sometimes an incorrect one.

## Threads (17.1 and 17.2, pages 1062–1068)

All threads of a process share the heap, but each has its own stack containing its local variables (17.1.1). This facilitates parallelism (multiple cores; a waiting thread does not block the others) but increases complexity: shared data must be protected. A `Thread` is created with a delegate, started with `Start()`, and `Join()` waits for it to finish (17.2.1 and 17.2.2). A lambda that uses a loop variable should first copy it to a local variable; otherwise, all threads will see the same, later value.

## Coordinating Access (17.2.4, pages 1072–1085)

A **race condition** occurs when two threads modify the same variable without protection. Even `zaehler++` consists of reading, adding, and writing; two threads can read the same old value, and an update is lost. The `lock` statement (17.2.4.1.1, page 1073) allows only one thread at a time into the protected block and must be applied to a private object. For individual operations on numbers, `Interlocked` is sufficient—for example, `Increment` or `Add`—which combines the three steps into a single indivisible operation (17.2.4.2.3, page 1084). Collections such as `List<T>` or `Queue<T>` do not tolerate concurrent access: every access must be under the same lock.

## Exercises (17.5, pages 1118–1152)

The Task Parallel Library takes it to the next level: A `Task<T>` is a promise of a future result. `Task.Run` starts work in the thread pool (17.5.1.3.2, page 1124); `Result` waits and retrieves the result. `Task.WhenAll` and `Task.WhenAny` combine tasks, while `ContinueWith` appends follow-up work (17.5.8 and 17.5.9, pages 1138–1142). An exception in a task only becomes apparent during the wait, as an `AggregateException` containing all errors; `Flatten()` unwraps nested groups (17.5.6, page 1129). Cancellation is **cooperative**: The caller invokes `Cancel()` on a `CancellationTokenSource`; the task checks its `CancellationToken`—most easily with `ThrowIfCancellationRequested()`—and then terminates as “canceled” (17.5.10, page 1145). `TaskCompletionSource<T>` turns an event or any asynchronous operation into a task (17.7.3, page 1205).

## Parallel and PLINQ (May 17, 2011, and May 18, pages 1152 and 1245)

`Parallel.Invoke`, `Parallel.For`, and `Parallel.ForEach` automatically distribute loop iterations across threads (pages 1153–1157); `ParallelOptions` can be used to limit the extent of this distribution. `AsParallel()` parallelizes LINQ queries; `AsOrdered()` restores the original order (18.5.5, pages 1252). Anything shared by the iterations needs protection.

## async and await (17.6, pages 1161–1202)

`async` and `await` allow you to write asynchronous code as if it were sequential. An `async` method returns a `Task` or `Task<T>` (17.6.4); when `await` is used, it releases the thread and resumes execution after the expected task has completed (17.6.5). Exceptions are received by `await` in their original type (17.6.7); cancellation is handled via a passed-through `CancellationToken` (17.6.8). Two pitfalls (17.6.12): `async void` loses exceptions—it is only intended for event handlers; and blocking with `.Result` or `.Wait()` can lead to a deadlock in an application with a user interface because the program waits for the blocked UI thread to resume.

## For Practice

The tasks are **deterministic**: no time measurement, no `Thread.Sleep` in tests. Results are awaited using `Join()`, `TaskCompletionSource`, `ManualResetEventSlim`, or a `Barrier`; time limits are used only to prevent deadlocks. A race condition cannot be reliably demonstrated this way, but the correct variant can: it must produce the exact result every time.
