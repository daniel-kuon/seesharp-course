# The User Interface: Layout, Binding, and Controls

This exercise will be graded by the supervisor; there are no tests. You will need Windows and Rider with .NET desktop support, because WPF only runs on Windows (target type: `net10.0-windows`). If you do not have a Windows computer, please discuss the exercise with the supervisor.

Read sections **12.11 Layout Containers** (page 804) through **12.11.1 Grid** (page 807), **12.11.2 DockPanel** (page 812), **12.11.3 StackPanel** (page 814), and **12.11.4 WrapPanel** (page 815), as well as **12.12 Controls** (page 819) and **12.10 Data Binding** (page 787). The sample folder included with the book contains the following templates: `WPF/Eurokonverter`, `WPF/MVVM/RelayCommand`, and `WPF/Layoutcontainer`.

Procedure:

1. Create the solution: a **class library** (`net10.0`) containing the ViewModel classes from Exercises 2 through 4—which you **can copy** here **or create from scratch**—and a **WPF application** (`net10.0-windows`) that accesses the library via a project reference. The library does not receive a WPF reference so that it remains testable.
2. Choose **one** of the three ViewModels and build the window for it.
   - Set the `DataContext` in `App.xaml.cs` or in the window.
   - Arrange the elements using `Grid` (rows and columns with `Auto` and `*`) and, where appropriate, `DockPanel` or `StackPanel`.
   - `TextBox`: `Text="{Binding ..., Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"`.
   - Buttons: `Command="{Binding ...}"`, with `CommandParameter` if necessary.
   - Collection: `ListBox` or `ItemsControl` with `ItemsSource`.
   - Validation: Errors must be visible (message text, border).
3. Answer the open-ended question and take a screenshot. SeeSharp will include the source files in the test package; add the screenshot to it.

The review checks for: no logic in the code-behind except for `InitializeComponent()`; bindings instead of event handlers; a window that behaves correctly when resized (no `Canvas`, no fixed coordinates); and readable names and text.
