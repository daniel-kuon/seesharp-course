# A float matrix with transposition

Read Section **6.2.9, “Multidimensional Arrays”** (page 467), and Exercise 4 in Section **6.10** (page 541) in the book. For the two-dimensional indexer, see **5.12.3** (page 397); for tuple assignment, see **6.6.4** (page 491).

`FloatMatrix` encapsulates a rectangular `float[,]` array. Open `FloatMatrix.cs` and complete the following:

1. The constructor creates the array only if the dimensions are valid (`z > 0`, `s > 0`, and no more than `maxSize` elements) and sets the number of `Zeilen` and `Spalten`; otherwise, the matrix remains empty (0 × 0).
2. The indexer `this[int z, int s]` reads and writes `data[z, s]`.
3. `Transponieren()` reflects the matrix across the main diagonal: `m[i, j]` becomes `m[j, i]`.
   - Square: in place, by swapping each element below the diagonal with its counterpart above it. A tuple assignment `(a, b) = (b, a)` eliminates the need for the auxiliary variable.
   - Otherwise: fill a new array with the swapped dimensions, swap `Zeilen` and `Spalten`, and replace the array.

`FloatMatrixDemo.cs` displays a 3 × 5 matrix before and after transposition.
