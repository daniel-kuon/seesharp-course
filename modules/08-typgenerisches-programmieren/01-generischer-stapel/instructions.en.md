# A generic stack

Read sections **8.1, "Motivations for Generic Types"** (page 589), and **8.2.1, "Generic Classes: Definition"** (page 591), in the book.

`SimpleStack<T>` is a fixed-capacity stack (last-in, first-out). The type parameter `T` represents the element type; it is only made concrete when the stack is used: `new SimpleStack<double>(10)`. Open `SimpleStack.cs` and complete the following:

1. Both constructors create the array `data` of type `T[]`; `max` is used only if it is greater than 0; otherwise, the capacity remains 5.
2. `Count` returns the number of elements.
3. `Push(T element)` pushes an element onto the top of the stack; if the stack is full, the method throws an `InvalidOperationException`.
4. `Pop()` removes the top element and returns it; `Peek()` returns it without removing it. Both throw an `InvalidOperationException` if the stack is empty.

`Program.cs` uses the stack with `double` and `string`; both are the same class. Level 11 handles exceptions; here, `throw new InvalidOperationException("…")` is sufficient.
