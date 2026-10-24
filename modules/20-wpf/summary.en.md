# WPF and the MVVM Pattern

This elective module is optional and does not require WPF for the programming exercises: Only ViewModel classes in a standard `net10.0` class library will be tested. You will build the user interface yourself in Rider (Windows) and present it to your supervisor (Chapter 12, page 725).

## Classification and Fundamentals (12.1 through 12.3, pages 727 through 745)

WPF is the GUI technology for Windows desktop applications that has been available since 2006; it is technically superior to the older Windows Forms, but like Windows Forms, it is limited to Windows (target type `net10.0-windows`). For new projects, Microsoft recommends the Windows App SDK with WinUI 3; MAUI, Avalonia, and Uno cover additional platforms (12.1.1). A WPF Application consists of exactly one `Application` object, which controls startup, and at least one `Window`. All UI objects belong to a single UI thread (12.2.2).

## XAML and Code-Behind (12.4 through 12.6, pages 746 through 764)

XAML is XML that describes an object graph: An element creates an object, an attribute sets a property, a property element (`<Button.Content>`) sets complex values, and markup extensions such as `{Binding}` or `{StaticResource}` evaluate an expression during loading. Each `.xaml` file corresponds to a partial class in the code-behind file; during the build process, this is converted into BAML and generated C# code that populates `InitializeComponent()`.

## Routing Events and Dependency Properties (12.8 and 12.9, pages 766–786)

Routing events travel through the element hierarchy: Tunnel events (`PreviewMouseDown`) travel from top to bottom, bubble events (`MouseDown`, `Click`) travel from the source upward, and direct events remain at the source. `Handled = true` stops event propagation to regular handlers. Dependency properties do not store their value in the field, but rather in a dictionary of the object; this allows for value precedence (animation, trigger, style, default value), inheritance in the element tree, and, most importantly, data binding.

## Data Binding (12.10, pages 787–803)

A `Binding` links a target object property (dependent property) to a source property. The mode (`OneWay`, `TwoWay`, `OneWayToSource`) specifies the direction; `UpdateSourceTrigger` determines when an input is written back. For `TextBox.Text`, this occurs by default only when focus is lost; with `UpdateSourceTrigger=PropertyChanged`, it occurs with every keystroke. For the source to update the user interface, it must implement `INotifyPropertyChanged` (12.10.4.1); collections report changes via `INotifyCollectionChanged`, which in practice means `ObservableCollection<T>` (12.10.4.2). Validation is handled via exceptions or, better yet, via `INotifyDataErrorInfo` (12.10.5.2).

## Layout and Controls (12.11 and 12.12, pages 804–855)

`Grid` (rows and columns, `Auto`, `*`, and fixed values), `StackPanel`, `DockPanel`, and `WrapPanel` arrange elements relative to each other so that the window remains usable when its size changes; A `Canvas` with fixed coordinates is the exception. Common controls include `TextBox`, `Button`, `ListBox`, and `ComboBox`.

## MVVM (12.13, pages 856–883)

The pattern separates three roles: The **model** holds data and business logic; the **view** (XAML) displays information and uses only bindings; and the **ViewModel** prepares data for the view, maintains its state, and provides commands. The ViewModel does not use window classes, so it can be tested without a user interface—and that is exactly what the tests in this module do. Commands implement `ICommand` (`Execute`, `CanExecute`, `CanExecuteChanged`; 12.13.3.1); `RelayCommand` accepts two delegates and eliminates the need for a separate class per command (12.13.3.4). The MVVM Community Toolkit provides ready-made building blocks (`ObservableObject`, `ObservableValidator`, `RelayCommand`; 12.13.4); in the exercises, you’ll write them yourself once to understand them.
