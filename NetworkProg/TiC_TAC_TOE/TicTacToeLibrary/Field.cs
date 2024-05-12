using System.Collections.ObjectModel;


namespace TicTacToeLibrary {
    public class Field {

        public Cell[,] Cells { get; }
        public ObservableCollection<Cell> CellsBinding { get; }
        public int Rows { get; }
        public int Columns { get; }

        public Field(int rows, int columns) {
            Rows = rows;
            Columns = columns;
            Cells = new Cell[rows, columns];
            int coutn = 0;
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    Cells[i, j] = new Cell(j, i, coutn);
                    ++coutn;
                }
            }

            CellsBinding = new ObservableCollection<Cell>();
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    CellsBinding.Add(Cells[i, j]);
        }
    }
}
