using System;

public class FloatMatrix {
    float[,] data = new float[0, 0];
    const int maxSize = 2_621_440; // höchstens 10 MB

    public int Zeilen { get; private set; }
    public int Spalten { get; private set; }

    public FloatMatrix(int z, int s) {
        // TODO: nur bei z > 0, s > 0 und z * s <= maxSize ein Array anlegen und Zeilen/Spalten setzen;
        //       sonst bleibt die Matrix leer (0 Zeilen, 0 Spalten)
        throw new NotImplementedException();
    }

    // Zweidimensionaler Indexer
    public float this[int z, int s] {
        get {
            // TODO
            throw new NotImplementedException();
        }
        set {
            // TODO
            throw new NotImplementedException();
        }
    }

    public void Transponieren() {
        // TODO: quadratisch: Elemente unterhalb der Diagonale mit denen oberhalb tauschen (in place);
        //       sonst: neues Array mit vertauschten Dimensionen füllen, Zeilen und Spalten tauschen
        throw new NotImplementedException();
    }

    public string Anzeigen() {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < Zeilen; i++) {
            for (int j = 0; j < Spalten; j++)
                sb.Append($"{data[i, j],7:f2}");
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
