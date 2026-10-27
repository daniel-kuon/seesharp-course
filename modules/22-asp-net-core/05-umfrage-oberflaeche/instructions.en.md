# The survey interface, including layout and tag helpers

See the book, section **22.6 Tag Helpers** (page 1572, including 22.6.2 Form Tag Helpers and 22.6.2.4 Validation), **22.9.3 Client-Side Validation** and **22.9.7 asp-validation-summary** (pages 1613 and 1619), **22.10 Layout Techniques** (page 1620), including the partial views in 22.10.5 and the `wwwroot` folder in 22.10.7, as well as **22.11 Improvements to the Survey Example** (page 1632).

The `Umfrage` project is the working survey from Exercise 4. It has no styling yet. Run it locally (`dotnet run`, Rider: green arrow) and build the user interface:

1. **Form** in `Pages/Umfrage.cshtml`: `<select>` for the party, label, error message at the field, and summary of errors—all using tag helpers (`asp-for`, `asp-items`, `asp-validation-for`, `asp-validation-summary`) and scripts for client-side validation.
2. **Layout:** `Pages/Shared/_Layout.cshtml` with navigation and `@RenderBody()`, `Pages/_ViewStart.cshtml`; the results table as a partial view `_Ergebnisse.cshtml`.
3. **Stylesheet** in `wwwroot/css/site.css`. To ensure the server serves the file, you need to call the `UseStaticFiles()` middleware before `UseRouting()` in `Program.cs`.

There are no automated tests. Place three screenshots (empty form, form with error messages, results page) in the `Umfrage/screenshots` folder and discuss them with your supervisor. At the end, answer the open-ended question about text and business logic.
