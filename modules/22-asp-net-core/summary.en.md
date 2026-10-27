# ASP.NET Core Razor Pages

A Razor web application is a program that accepts HTTP requests and returns HTML pages. In Chapter 22 (page 1537), the book develops an online survey on party preferences: form, entity class, test run (22.1, page 1538). In the course, it runs without a database; a service in memory handles the storage.

## Program Startup and Services (22.2 and 22.3, pages 1552–1555)

`Program.cs` consists of top-level statements. `WebApplicationBuilder` collects the application's **services** in `builder.Services` (`AddRazorPages()`); `Build()` returns the `WebApplication`. Next comes the **request pipeline**: a chain of middleware components that each request passes through in the order in which they are configured (`UseHttpsRedirection`, `UseStaticFiles`, `UseRouting`, `UseAuthorization`, `MapRazorPages`). The order is part of the program. The **service container** creates and disposes of the service objects; A class requests its dependencies in the constructor (constructor injection) and knows only an interface. When you register a type using `AddSingleton`, `AddScoped`, or `AddTransient`, you define its lifetime (the book shows only `AddTransient`; the lifetimes come up in exercise 4 and the quiz).

## Pages and PageModel (22.4 and 22.5, pages 1556–1572)

A page consists of a markup file (`.cshtml`, Razor syntax: `@model`, `@foreach`, `@if`, `@Model.Eigenschaft`) and a `PageModel` class. The handlers are called `OnGet` and `OnPost` and return an `IActionResult`: `Page()` displays the page, `RedirectToPage(...)` redirects, and `NotFound()` returns a 404 response. After a successful POST, a redirect is performed (Post-Redirect-Get) to prevent the form from being resubmitted when the page reloads. HTTP is stateless: the page and PageModel exist only for the duration of a single request; maintaining state across requests requires a database, a cookie, or a service (22.5.4, page 1571). Because a PageModel is a regular class, its logic can be tested without a web server.

## Forms, Routing, Binding (22.6 through 22.8, pages 1572 through 1607)

**Tag helpers** (`asp-for`, `asp-page`, `asp-validation-for`) generate the appropriate HTML—including anti-forgery tokens—from markup. **Routing** maps page paths to pages; a route parameter with a restriction (`@page "{id:int}"`) only allows matching URLs to pass through, while all others result in a 404 error. **Model binding** writes form values to PageModel properties marked with `[BindProperty]`; missing or unconvertible values end up as errors in `ModelState`. Because it writes every bindable property that appears in the request, **overposting** is possible (22.8.7, page 1606): Countermeasures include a whitelist (`[Bind]`) or, better yet, a custom input model class.

## Validation (22.9, pages 1608–1619)

Rules are defined as attributes on the model (`[Required]`, `[Range]`, `[StringLength]`, `[EmailAddress]`); rules that span multiple properties implement `IValidatableObject` (not in the book; exercise 3 explains it). The server always performs validation; client-side validation is merely a convenience. `OnPost` checks `ModelState.IsValid`. A reference type that does not allow null values is implicitly considered `[Required]` (22.9.6); `[BindRequired]`, on the other hand, requires that the value be present in the request at all (22.9.2).

## Layout (22.10 and 22.11, pages 1620–1636)

`_Layout.cshtml` contains the common framework with `@RenderBody()`; `_ViewStart.cshtml` selects it; `_ViewImports.cshtml` registers tag helpers and `@using` statements; partial views (`<partial>`) encapsulate recurring code; and `UseStaticFiles` serves files from `wwwroot`.

## Testing

In the course, tests assess two things: The PageModel logic is tested as a regular class without a host (fake service, `PageContext`, checking the result type). `WebApplicationFactory<Program>` tests entire pages using in-memory HTTP requests. The supervisor evaluates the user interface design.
