namespace download_baza_to
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label номерLabel;
            System.Windows.Forms.Label производительLabel;
            System.Windows.Forms.Label наименованиеLabel;
            System.Windows.Forms.Label артикулLabel;
            System.Windows.Forms.Label фотографияLabel;
            System.Windows.Forms.Label ценаLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._1DataSet = new download_baza_to._1DataSet();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableTableAdapter = new download_baza_to._1DataSetTableAdapters.TableTableAdapter();
            this.tableAdapterManager = new download_baza_to._1DataSetTableAdapters.TableAdapterManager();
            this.tableBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tableBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tableDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерTextBox = new System.Windows.Forms.TextBox();
            this.производительTextBox = new System.Windows.Forms.TextBox();
            this.наименованиеTextBox = new System.Windows.Forms.TextBox();
            this.артикулTextBox = new System.Windows.Forms.TextBox();
            this.фотографияPictureBox = new System.Windows.Forms.PictureBox();
            this.ценаTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            номерLabel = new System.Windows.Forms.Label();
            производительLabel = new System.Windows.Forms.Label();
            наименованиеLabel = new System.Windows.Forms.Label();
            артикулLabel = new System.Windows.Forms.Label();
            фотографияLabel = new System.Windows.Forms.Label();
            ценаLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingNavigator)).BeginInit();
            this.tableBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.фотографияPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // номерLabel
            // 
            номерLabel.AutoSize = true;
            номерLabel.Location = new System.Drawing.Point(701, 43);
            номерLabel.Name = "номерLabel";
            номерLabel.Size = new System.Drawing.Size(42, 13);
            номерLabel.TabIndex = 2;
            номерLabel.Text = "номер:";
            // 
            // производительLabel
            // 
            производительLabel.AutoSize = true;
            производительLabel.Location = new System.Drawing.Point(656, 69);
            производительLabel.Name = "производительLabel";
            производительLabel.Size = new System.Drawing.Size(87, 13);
            производительLabel.TabIndex = 4;
            производительLabel.Text = "производитель:";
            // 
            // наименованиеLabel
            // 
            наименованиеLabel.AutoSize = true;
            наименованиеLabel.Location = new System.Drawing.Point(659, 95);
            наименованиеLabel.Name = "наименованиеLabel";
            наименованиеLabel.Size = new System.Drawing.Size(84, 13);
            наименованиеLabel.TabIndex = 6;
            наименованиеLabel.Text = "наименование:";
            // 
            // артикулLabel
            // 
            артикулLabel.AutoSize = true;
            артикулLabel.Location = new System.Drawing.Point(693, 121);
            артикулLabel.Name = "артикулLabel";
            артикулLabel.Size = new System.Drawing.Size(50, 13);
            артикулLabel.TabIndex = 8;
            артикулLabel.Text = "артикул:";
            // 
            // фотографияLabel
            // 
            фотографияLabel.AutoSize = true;
            фотографияLabel.Location = new System.Drawing.Point(787, 12);
            фотографияLabel.Name = "фотографияLabel";
            фотографияLabel.Size = new System.Drawing.Size(72, 13);
            фотографияLabel.TabIndex = 10;
            фотографияLabel.Text = "фотография:";
            // 
            // ценаLabel
            // 
            ценаLabel.AutoSize = true;
            ценаLabel.Location = new System.Drawing.Point(709, 147);
            ценаLabel.Name = "ценаLabel";
            ценаLabel.Size = new System.Drawing.Size(34, 13);
            ценаLabel.TabIndex = 12;
            ценаLabel.Text = "цена:";
            // 
            // _1DataSet
            // 
            this._1DataSet.DataSetName = "_1DataSet";
            this._1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this._1DataSet;
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TableTableAdapter = this.tableTableAdapter;
            this.tableAdapterManager.UpdateOrder = download_baza_to._1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tableBindingNavigator
            // 
            this.tableBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tableBindingNavigator.BindingSource = this.tableBindingSource;
            this.tableBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tableBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tableBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tableBindingNavigatorSaveItem});
            this.tableBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tableBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tableBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tableBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tableBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tableBindingNavigator.Name = "tableBindingNavigator";
            this.tableBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tableBindingNavigator.Size = new System.Drawing.Size(658, 25);
            this.tableBindingNavigator.TabIndex = 0;
            this.tableBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tableBindingNavigatorSaveItem
            // 
            this.tableBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tableBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tableBindingNavigatorSaveItem.Image")));
            this.tableBindingNavigatorSaveItem.Name = "tableBindingNavigatorSaveItem";
            this.tableBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tableBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.tableBindingNavigatorSaveItem.Click += new System.EventHandler(this.tableBindingNavigatorSaveItem_Click_1);
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.AutoGenerateColumns = false;
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn5});
            this.tableDataGridView.DataSource = this.tableBindingSource;
            this.tableDataGridView.Location = new System.Drawing.Point(4, 30);
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.Size = new System.Drawing.Size(642, 228);
            this.tableDataGridView.TabIndex = 1;
            this.tableDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableDataGridView_DataError);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "номер";
            this.dataGridViewTextBoxColumn1.HeaderText = "номер";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "производитель";
            this.dataGridViewTextBoxColumn2.HeaderText = "производитель";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "наименование";
            this.dataGridViewTextBoxColumn3.HeaderText = "наименование";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "артикул";
            this.dataGridViewTextBoxColumn4.HeaderText = "артикул";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "фотография";
            this.dataGridViewImageColumn1.HeaderText = "фотография";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "цена";
            this.dataGridViewTextBoxColumn5.HeaderText = "цена";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // номерTextBox
            // 
            this.номерTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "номер", true));
            this.номерTextBox.Location = new System.Drawing.Point(749, 40);
            this.номерTextBox.Name = "номерTextBox";
            this.номерTextBox.Size = new System.Drawing.Size(100, 20);
            this.номерTextBox.TabIndex = 3;
            // 
            // производительTextBox
            // 
            this.производительTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "производитель", true));
            this.производительTextBox.Location = new System.Drawing.Point(749, 66);
            this.производительTextBox.Name = "производительTextBox";
            this.производительTextBox.Size = new System.Drawing.Size(100, 20);
            this.производительTextBox.TabIndex = 5;
            // 
            // наименованиеTextBox
            // 
            this.наименованиеTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "наименование", true));
            this.наименованиеTextBox.Location = new System.Drawing.Point(749, 92);
            this.наименованиеTextBox.Name = "наименованиеTextBox";
            this.наименованиеTextBox.Size = new System.Drawing.Size(100, 20);
            this.наименованиеTextBox.TabIndex = 7;
            // 
            // артикулTextBox
            // 
            this.артикулTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "артикул", true));
            this.артикулTextBox.Location = new System.Drawing.Point(749, 118);
            this.артикулTextBox.Name = "артикулTextBox";
            this.артикулTextBox.Size = new System.Drawing.Size(100, 20);
            this.артикулTextBox.TabIndex = 9;
            // 
            // фотографияPictureBox
            // 
            this.фотографияPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.tableBindingSource, "фотография", true));
            this.фотографияPictureBox.Location = new System.Drawing.Point(865, 12);
            this.фотографияPictureBox.Name = "фотографияPictureBox";
            this.фотографияPictureBox.Size = new System.Drawing.Size(168, 174);
            this.фотографияPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.фотографияPictureBox.TabIndex = 11;
            this.фотографияPictureBox.TabStop = false;
            // 
            // ценаTextBox
            // 
            this.ценаTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "цена", true));
            this.ценаTextBox.Location = new System.Drawing.Point(749, 144);
            this.ценаTextBox.Name = "ценаTextBox";
            this.ценаTextBox.Size = new System.Drawing.Size(100, 20);
            this.ценаTextBox.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(302, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Сохранение...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 270);
            this.Controls.Add(this.label1);
            this.Controls.Add(ценаLabel);
            this.Controls.Add(this.ценаTextBox);
            this.Controls.Add(фотографияLabel);
            this.Controls.Add(this.фотографияPictureBox);
            this.Controls.Add(артикулLabel);
            this.Controls.Add(this.артикулTextBox);
            this.Controls.Add(наименованиеLabel);
            this.Controls.Add(this.наименованиеTextBox);
            this.Controls.Add(производительLabel);
            this.Controls.Add(this.производительTextBox);
            this.Controls.Add(номерLabel);
            this.Controls.Add(this.номерTextBox);
            this.Controls.Add(this.tableDataGridView);
            this.Controls.Add(this.tableBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(674, 309);
            this.MinimumSize = new System.Drawing.Size(674, 309);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сохраняю в файл.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingNavigator)).EndInit();
            this.tableBindingNavigator.ResumeLayout(false);
            this.tableBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.фотографияPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _1DataSet _1DataSet;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private _1DataSetTableAdapters.TableTableAdapter tableTableAdapter;
        private _1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tableBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tableBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView tableDataGridView;
        private System.Windows.Forms.TextBox номерTextBox;
        private System.Windows.Forms.TextBox производительTextBox;
        private System.Windows.Forms.TextBox наименованиеTextBox;
        private System.Windows.Forms.TextBox артикулTextBox;
        private System.Windows.Forms.PictureBox фотографияPictureBox;
        private System.Windows.Forms.TextBox ценаTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

