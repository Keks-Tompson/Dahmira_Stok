namespace System.Windows.Forms
{
    internal class DoubleBufferedDataGridViewVI : DataGridView
    {
        protected override bool DoubleBuffered { get => true; }
    }
}