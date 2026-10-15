using System;

public class FloatMatrix {
    float[,] data = new float[0, 0];
    const int maxSize = 2_621_440; // höchstens 10 MB

    public int Zeilen { get; private set; }
    public int Spalten { get; private set; }

    public FloatMatrix(int z, int s) {
        if (z > 0 && s > 0 && z * s <= maxSize) {
            data = new float[z, s];
            Zeilen = z;
            Spalten = s;
        }
    }

    // Zweidimensionaler Indexer
    public float this[int z, int s] {
        get {
            return data[z, s];
        }
        set {
            data[z, s] = value;
        }
    }

    public void Transponieren() {
        if (Zeilen == Spalten) {
            for (int i = 0; i < Zeilen; i++)
                for (int j = 0; j < i; j++)
                    (data[i, j], data[j, i]) = (data[j, i], data[i, j]);
        } else {
            (Spalten, Zeilen) = (Zeilen, Spalten); // Vertauschen per Tupelzuweisung
            float[,] nData = new float[Zeilen, Spalten];
            for (int i = 0; i < Zeilen; i++)
                for (int j = 0; j < Spalten; j++)
                    nData[i, j] = data[j, i];
            data = nData;
        }
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
