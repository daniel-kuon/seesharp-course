using System.Data;
using System.Data.Common;

namespace Datenzugriff;

/// <summary>
/// Datenzugriff gegen die Basisklassen aus System.Data.Common, ohne einen bestimmten Provider zu kennen.
/// </summary>
public static class Zugriff
{
    public static DbConnection OeffneVerbindung(DbProviderFactory fabrik, string verbindungsstring)
    {
        DbConnection verbindung = fabrik.CreateConnection()
            ?? throw new InvalidOperationException("Die Fabrik kann keine Verbindung erzeugen.");
        verbindung.ConnectionString = verbindungsstring;
        verbindung.Open();
        return verbindung;
    }

    public static DataTable LiesTabelle(DbConnection verbindung, string sql)
    {
        using DbCommand befehl = verbindung.CreateCommand();
        befehl.CommandText = sql;
        using DbDataReader leser = befehl.ExecuteReader();
        var tabelle = new DataTable();
        tabelle.Load(leser);
        return tabelle;
    }

    public static string Verbindungsstring(DbProviderFactory fabrik, string datei)
    {
        DbConnectionStringBuilder builder = fabrik.CreateConnectionStringBuilder()
            ?? throw new InvalidOperationException("Die Fabrik kann keinen ConnectionStringBuilder erzeugen.");
        builder["Data Source"] = datei;
        builder["Mode"] = "ReadOnly";
        return builder.ConnectionString;
    }

    public static List<DataRow> TeureArtikel(DataTable tabelle) =>
        tabelle.AsEnumerable().Where(r => r.Field<double>("Preis") > 10).ToList();

    public static List<string> Namen(DataTable tabelle) =>
        tabelle.AsEnumerable().Select(r => r.Field<string>("Name")!).ToList();

    public static double Summe(DataTable tabelle, string spalte) =>
        tabelle.AsEnumerable().Sum(r => r.Field<double>(spalte));
}
