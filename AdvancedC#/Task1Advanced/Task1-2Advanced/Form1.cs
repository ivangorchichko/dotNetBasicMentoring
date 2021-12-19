using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1Advanced;

namespace Task1_2Advanced
{
    public partial class Form1 : Form
    {
        private string _filterText;
        private Task _executionTask;
        private delegate void SafeCallDelegate(DataGridView table, DataRow row);

        private FileSystemVisitor _fileVisitor;
        private DataTable ObjectsInSystem => ObjectsView.DataSource as DataTable;
        private DataTable EventLogsInSystem => EventsLogs.DataSource as DataTable;
        public Form1()
        {
            InitializeComponent();

            ObjectsView.DataSource = new DataTable();
            ObjectsInSystem.Columns.Add("Name", typeof(string));
            ObjectsInSystem.Columns.Add("Type", typeof(string));
            ObjectsInSystem.Columns.Add("Date of creating", typeof(DateTime));
            ObjectsInSystem.Columns.Add("Parent directory", typeof(string));

            EventsLogs.DataSource = new DataTable();
            EventLogsInSystem.Columns.Add("Event logs", typeof(string));
        }

        public void AddRowSafe(DataGridView table, DataRow row)
        {
            if (table.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddRowSafe);
                table.Invoke(d, table, row);
            }
            else
            {
                ((DataTable)table.DataSource).Rows.Add(row);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ObjectsInSystem.Clear();
            EventLogsInSystem.Clear();
            
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _fileVisitor = new FileSystemVisitor(dialog.SelectedPath,
                            AlgorithmsForFiltering.GetFilter(_filterText, inputTextForFiltering.Text));
                SubscribeEvents();

                _executionTask = new Task(() =>
                {
                    foreach (var directoryObject in _fileVisitor.GetDirectoryComponents())
                    {
                        var row = ObjectsInSystem.NewRow();
                        row["Name"] = directoryObject.Name;
                        row["Type"] = directoryObject.Type;
                        row["Date of creating"] = directoryObject.CreatingDate;
                        row["Parent directory"] = directoryObject.ParentDirectoryPath;
                        AddRowSafe(ObjectsView, row);
                    }
                });
                _executionTask.Start();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _fileVisitor.OnVisitFinished(new FileSystemObjectEventArgs());
        }

        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton filter = (RadioButton) sender;
            if (filter.Checked)
            {
                _filterText = filter.Text;
            }
        }

        private void SubscribeEvents()
        {
            _fileVisitor.SearchStarted += (sender, e) =>
            {
                var row = EventLogsInSystem.NewRow();
                row["Event logs"] = "Searching started";
                AddRowSafe(EventsLogs, row);
            };
            _fileVisitor.SearchFinished += (sender, e) =>
            {
                var row = EventLogsInSystem.NewRow();
                row["Event logs"] = "Searching finished";
                AddRowSafe(EventsLogs, row);
            };
            _fileVisitor.DirectoryFound += (sender, e) =>
            {
                var row = EventLogsInSystem.NewRow();
                row["Event logs"] = $"Directory found: {e.Name}";
                AddRowSafe(EventsLogs, row);
            };
            _fileVisitor.FileFound += (sender, e) =>
            {
                var row = EventLogsInSystem.NewRow();
                row["Event logs"] = $"File found: {e.Name}";
                AddRowSafe(EventsLogs, row);
            };
            _fileVisitor.FilteredDirectoryFound += (sender, e) =>
            {
                var row = EventLogsInSystem.NewRow();
                row["Event logs"] = $"Filtered directory found: {e.Name}";
                AddRowSafe(EventsLogs, row);
            };
            _fileVisitor.FilteredFileFound += (sender, e) =>
            {
                var row = EventLogsInSystem.NewRow();
                row["Event logs"] = $"Filtered file found: {e.Name}";
                AddRowSafe(EventsLogs, row);
            };
        }
    }
}
