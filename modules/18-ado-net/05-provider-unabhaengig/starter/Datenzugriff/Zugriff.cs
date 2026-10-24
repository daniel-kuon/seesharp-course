using System.Data;
using System.Data.Common;

namespace Datenzugriff;

/// <summary>
/// Datenzugriff gegen die Basisklassen aus System.Data.Common (DbConnection, DbCommand,
/// DbProviderFactory), ohne einen bestimmten Provider zu kennen. Dieses Projekt darf
/// Microsoft.Data.Sqlite NICHT referenzieren: Die Tests übergeben die passende Fabrik
/// (SqliteFactory.Instance); für den SQL Server wäre es SqlClientFactory.Instance.
/// </summary>
public static class Zugriff
{
    /// <summary>Erzeugt mit der Fabrik eine Verbindung, setzt die Verbindungszeichenfolge und öffnet sie.</summary>
    public static DbConnection OeffneVerbindung(DbProviderFactory fabrik, string verbindungsstring)
    {
        // TODO: fabrik.CreateConnection() kann null liefern (Provider ohne Verbindungsklasse):
        // dann InvalidOperationException werfen. Sonst ConnectionString setzen und Open() aufrufen.
        throw new NotImplementedException();
    }

    /// <summary>Führt die Abfrage aus und lädt das Ergebnis in eine DataTable.</summary>
    public static DataTable LiesTabelle(DbConnection verbindung, string sql)
    {
        // TODO: Befehl und Leser mit using; new DataTable() und tabelle.Load(leser).
        throw new NotImplementedException();
    }

    /// <summary>Baut mit dem ConnectionStringBuilder der Fabrik die Verbindungszeichenfolge für eine
    /// Datei zusammen: Schlüssel "Data Source" = datei und "Mode" = "ReadOnly" (nur lesen).
    /// Der Builder maskiert Sonderzeichen im Pfad selbst, du verkettest nichts.</summary>
    public static string Verbindungsstring(DbProviderFactory fabrik, string datei)
    {
        // TODO: fabrik.CreateConnectionStringBuilder(), Werte über den Indexer setzen, ConnectionString zurückgeben.
        throw new NotImplementedException();
    }

    /// <summary>LINQ-to-DataSet: die Zeilen, deren Spalte "Preis" (double, SQLite speichert REAL) größer als 10 ist.</summary>
    public static List<DataRow> TeureArtikel(DataTable tabelle)
    {
        // TODO: tabelle.AsEnumerable().Where(r => r.Field<double>("Preis") > 10).ToList()
        throw new NotImplementedException();
    }

    /// <summary>LINQ-to-DataSet: die Werte der Spalte "Name" (string) in Tabellenreihenfolge.</summary>
    public static List<string> Namen(DataTable tabelle)
    {
        // TODO: AsEnumerable().Select(r => r.Field<string>("Name"))
        throw new NotImplementedException();
    }

    /// <summary>LINQ-to-DataSet: Summe einer double-Spalte.</summary>
    public static double Summe(DataTable tabelle, string spalte)
    {
        // TODO: AsEnumerable().Sum(r => r.Field<double>(spalte))
        throw new NotImplementedException();
    }
}
