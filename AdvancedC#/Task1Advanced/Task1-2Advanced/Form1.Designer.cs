
namespace Task1_2Advanced
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.noneFilter = new System.Windows.Forms.RadioButton();
            this.containsFilter = new System.Windows.Forms.RadioButton();
            this.typeFilter = new System.Windows.Forms.RadioButton();
            this.creatingFilter = new System.Windows.Forms.RadioButton();
            this.inputTextForFiltering = new System.Windows.Forms.TextBox();
            this.ObjectsView = new System.Windows.Forms.DataGridView();
            this.EventsLogs = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupFilters = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsLogs)).BeginInit();
            this.groupFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(137, 37);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(12, 72);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(137, 37);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // noneFilter
            // 
            this.noneFilter.AutoSize = true;
            this.noneFilter.Checked = true;
            this.noneFilter.Location = new System.Drawing.Point(6, 12);
            this.noneFilter.Name = "noneFilter";
            this.noneFilter.Size = new System.Drawing.Size(54, 19);
            this.noneFilter.TabIndex = 2;
            this.noneFilter.TabStop = true;
            this.noneFilter.Text = "None";
            this.noneFilter.UseVisualStyleBackColor = true;
            this.noneFilter.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // containsFilter
            // 
            this.containsFilter.AutoSize = true;
            this.containsFilter.Location = new System.Drawing.Point(6, 37);
            this.containsFilter.Name = "containsFilter";
            this.containsFilter.Size = new System.Drawing.Size(157, 19);
            this.containsFilter.TabIndex = 3;
            this.containsFilter.TabStop = true;
            this.containsFilter.Text = "Name contains substring";
            this.containsFilter.UseVisualStyleBackColor = true;
            this.containsFilter.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // typeFilter
            // 
            this.typeFilter.AutoSize = true;
            this.typeFilter.Location = new System.Drawing.Point(6, 62);
            this.typeFilter.Name = "typeFilter";
            this.typeFilter.Size = new System.Drawing.Size(49, 19);
            this.typeFilter.TabIndex = 4;
            this.typeFilter.TabStop = true;
            this.typeFilter.Text = "Type";
            this.typeFilter.UseVisualStyleBackColor = true;
            this.typeFilter.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // creatingFilter
            // 
            this.creatingFilter.AutoSize = true;
            this.creatingFilter.Location = new System.Drawing.Point(6, 87);
            this.creatingFilter.Name = "creatingFilter";
            this.creatingFilter.Size = new System.Drawing.Size(119, 79);
            this.creatingFilter.TabIndex = 5;
            this.creatingFilter.TabStop = true;
            this.creatingFilter.Text = "By creating time \r\n(files found more \r\nthen input time)\r\nformat :\r\nYYYY-MM-DD\r\n";
            this.creatingFilter.UseVisualStyleBackColor = true;
            this.creatingFilter.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // inputTextForFiltering
            // 
            this.inputTextForFiltering.Location = new System.Drawing.Point(12, 311);
            this.inputTextForFiltering.Name = "inputTextForFiltering";
            this.inputTextForFiltering.Size = new System.Drawing.Size(137, 23);
            this.inputTextForFiltering.TabIndex = 6;
            // 
            // ObjectsView
            // 
            this.ObjectsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ObjectsView.Location = new System.Drawing.Point(186, 12);
            this.ObjectsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ObjectsView.Name = "ObjectsView";
            this.ObjectsView.RowHeadersWidth = 51;
            this.ObjectsView.RowTemplate.Height = 25;
            this.ObjectsView.Size = new System.Drawing.Size(624, 597);
            this.ObjectsView.TabIndex = 7;
            // 
            // EventsLogs
            // 
            this.EventsLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventsLogs.Location = new System.Drawing.Point(816, 12);
            this.EventsLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EventsLogs.Name = "EventsLogs";
            this.EventsLogs.RowTemplate.Height = 25;
            this.EventsLogs.Size = new System.Drawing.Size(294, 597);
            this.EventsLogs.TabIndex = 8;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filter Type";
            // 
            // groupFilters
            // 
            this.groupFilters.Controls.Add(this.containsFilter);
            this.groupFilters.Controls.Add(this.noneFilter);
            this.groupFilters.Controls.Add(this.typeFilter);
            this.groupFilters.Controls.Add(this.creatingFilter);
            this.groupFilters.Location = new System.Drawing.Point(12, 139);
            this.groupFilters.Name = "groupFilters";
            this.groupFilters.Size = new System.Drawing.Size(137, 166);
            this.groupFilters.TabIndex = 10;
            this.groupFilters.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1122, 621);
            this.Controls.Add(this.groupFilters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EventsLogs);
            this.Controls.Add(this.ObjectsView);
            this.Controls.Add(this.inputTextForFiltering);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ObjectsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsLogs)).EndInit();
            this.groupFilters.ResumeLayout(false);
            this.groupFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.RadioButton noneFilter;
        private System.Windows.Forms.RadioButton containsFilter;
        private System.Windows.Forms.RadioButton typeFilter;
        private System.Windows.Forms.RadioButton creatingFilter;
        private System.Windows.Forms.TextBox inputTextForFiltering;
        private System.Windows.Forms.DataGridView ObjectsView;
        private System.Windows.Forms.DataGridView EventsLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupFilters;
    }
}

