namespace load__baze
{
    using System.Windows.Forms;
    public class DoubleBufferedDataGridView : DataGridView
    {
        protected override bool DoubleBuffered { get => true; }
    }

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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.номерLabel = new System.Windows.Forms.Label();
            this.производительLabel = new System.Windows.Forms.Label();
            this.наименованиеLabel = new System.Windows.Forms.Label();
            this.артикулLabel = new System.Windows.Forms.Label();
            this.ценаLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tableDataGridView = new load__baze.DoubleBufferedDataGridView();
            this.номерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.производительDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.артикулDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фотографияDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ценаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.данные = new load__baze.данные();
            this.dataGridView_зависимость = new load__baze.DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripрасчетка = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemрассчёткакопировать = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemрасчткавставить = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_расчёт_2 = new load__baze.DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Примечание = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_муляж = new load__baze.DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDel2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_del_row_strip = new System.Windows.Forms.ToolStripButton();
            this.tableBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.номерTextBox = new System.Windows.Forms.TextBox();
            this.производительTextBox = new System.Windows.Forms.TextBox();
            this.наименованиеTextBox = new System.Windows.Forms.TextBox();
            this.артикулTextBox = new System.Windows.Forms.TextBox();
            this.ценаTextBox = new System.Windows.Forms.TextBox();
            this.button_загрузить_изображение = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_скриншот = new System.Windows.Forms.Button();
            this.button_сохр_изобр_в_фаил = new System.Windows.Forms.Button();
            this.button_поиск_копий_в_базе = new System.Windows.Forms.Button();
            this.фотографияPictureBox = new System.Windows.Forms.PictureBox();
            this.label_consol = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.button_добавить_значение_в_табл = new System.Windows.Forms.Button();
            this.pictureBox_new_image = new System.Windows.Forms.PictureBox();
            this.button_new_foto = new System.Windows.Forms.Button();
            this.button_new_foto_down = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox_new_артикул = new System.Windows.Forms.TextBox();
            this.textBox_new_наименование = new System.Windows.Forms.TextBox();
            this.textBox_new_производитель = new System.Windows.Forms.TextBox();
            this.button_ctroky_v_bazy = new System.Windows.Forms.Button();
            this.button_perenos_obratno = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button_поиск_по_баз_замен = new System.Windows.Forms.Button();
            this.button_поиск_по_баз_под = new System.Windows.Forms.Button();
            this.button_поиск_по_баз_доб = new System.Windows.Forms.Button();
            this.comboBox_цена_поиск_по_базе = new System.Windows.Forms.ComboBox();
            this.comboBox_артикул_поиск_по_базе = new System.Windows.Forms.ComboBox();
            this.comboBox_наименование_поиск_по_базе = new System.Windows.Forms.ComboBox();
            this.comboBox1_поиск = new System.Windows.Forms.ComboBox();
            this.textBox_new_stolbeth = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button_new_razdel_vmesto = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button_new_razdel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label_consol_2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button_no_image_for_excel = new System.Windows.Forms.Button();
            this.button_save_to_pdf3 = new System.Windows.Forms.Button();
            this.button_save_to_pdf2 = new System.Windows.Forms.Button();
            this.button_new_ophins = new System.Windows.Forms.Button();
            this.button_new_ophins2 = new System.Windows.Forms.Button();
            this.groupBox_Расчеты = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox_елупни = new System.Windows.Forms.ComboBox();
            this.button_взять_актуальные_цены_с_базы = new System.Windows.Forms.Button();
            this.button_расчитать = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_P_S = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tableTableAdapter = new load__baze.данныеTableAdapters.TableTableAdapter();
            this.tableAdapterManager = new load__baze.данныеTableAdapters.TableAdapterManager();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.новыйРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьРасчетВPDFБезЦенToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.загрузитьПрайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьПрайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьКопиюПрайсаВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.вРазработкеСоздатьШаблонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатьССайтаПрайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеОПрайсеНаСайтеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискОдинаковыхАртикуловВПрайсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьЦенуСФайлаExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьНаЦенуПроизводителяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.натройкиДляОбновлениеЦенИзExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пробник2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаПоПрайсуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаПоРасчетуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаПоТаблицеЗависимостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.справкаПоПрайсуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.радиоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уцуToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.сменитьВолнуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиДрстанцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отладочнаяКнопкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label16 = new System.Windows.Forms.Label();
            this.label_rachetka = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button_сохранить_расчёт_быстро = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.button_pase = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_Calk = new System.Windows.Forms.Button();
            this.button_del_razhet_end = new System.Windows.Forms.Button();
            this.button_del_razhet = new System.Windows.Forms.Button();
            this.button_del_zavisim = new System.Windows.Forms.Button();
            this.button_new_zavisim = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button_del_zavis = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.математика = new System.Windows.Forms.Timer(this.components);
            this.duble_art_art = new System.Windows.Forms.Timer(this.components);
            this.button_Baza_RACHET = new System.Windows.Forms.Button();
            this.groupBox_baza = new System.Windows.Forms.GroupBox();
            this.label_info_ftp = new System.Windows.Forms.Label();
            this.groupBox_поиск = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_удалить_изобр_в_фаил = new System.Windows.Forms.Button();
            this.pictureBox_no_image = new System.Windows.Forms.PictureBox();
            this.label_добавленно = new System.Windows.Forms.Label();
            this.button_добавить = new System.Windows.Forms.Button();
            this.button_поиск = new System.Windows.Forms.Button();
            this.groupBox_добавить = new System.Windows.Forms.GroupBox();
            this.button_del_new_image = new System.Windows.Forms.Button();
            this.pictureBox_no_image_добавить_в_прайс = new System.Windows.Forms.PictureBox();
            this.groupBox_razhet = new System.Windows.Forms.GroupBox();
            this.groupBox_asq = new System.Windows.Forms.GroupBox();
            this.button_dowload_asq = new System.Windows.Forms.Button();
            this.textBox_mess_asq = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new load__baze.DoubleBufferedDataGridView();
            this.дата = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Имя = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Сообщение = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_asq = new System.Windows.Forms.Button();
            this.pictureBox_Raz = new System.Windows.Forms.PictureBox();
            this.razhet_label = new System.Windows.Forms.Label();
            this.groupBox_картинка_расчетки = new System.Windows.Forms.GroupBox();
            this.button_расчет_фото_удалить = new System.Windows.Forms.Button();
            this.button_расчет_фото_в_буфер = new System.Windows.Forms.Button();
            this.button_расчет_фото_сохранить = new System.Windows.Forms.Button();
            this.button_расчет_фото_доб = new System.Windows.Forms.Button();
            this.button_расчет_фото_из_буфера = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_создать_шаблон = new System.Windows.Forms.Button();
            this.timer_labe_добавленна = new System.Windows.Forms.Timer(this.components);
            this.button_догрузить_шаблон = new System.Windows.Forms.Button();
            this.button_редактировать_шаблон = new System.Windows.Forms.Button();
            this.timer_dual_mouse = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_reset_pass_save = new System.Windows.Forms.Timer(this.components);
            this.timerlogo1 = new System.Windows.Forms.Timer(this.components);
            this.timerlogo2 = new System.Windows.Forms.Timer(this.components);
            this.timer_save_new_praise = new System.Windows.Forms.Timer(this.components);
            this.timer_auto_update = new System.Windows.Forms.Timer(this.components);
            this.timer_chat = new System.Windows.Forms.Timer(this.components);
            this.groupBox_url_praise = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button_return_ftp_praise = new System.Windows.Forms.Button();
            this.button_upload_praise_ftp = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_bite = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button_проверить_url_praise = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.данные)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_зависимость)).BeginInit();
            this.contextMenuStripрасчетка.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_расчёт_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_муляж)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingNavigator)).BeginInit();
            this.tableBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.фотографияPictureBox)).BeginInit();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_new_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox_Расчеты.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox_baza.SuspendLayout();
            this.groupBox_поиск.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_no_image)).BeginInit();
            this.groupBox_добавить.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_no_image_добавить_в_прайс)).BeginInit();
            this.groupBox_razhet.SuspendLayout();
            this.groupBox_asq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Raz)).BeginInit();
            this.groupBox_картинка_расчетки.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_url_praise.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 13);
            label1.TabIndex = 21;
            label1.Text = "Производитель:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(201, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(86, 13);
            label2.TabIndex = 21;
            label2.Text = "Наименование:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(4, 15);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(89, 13);
            label8.TabIndex = 21;
            label8.Text = "Производитель:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 39);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(86, 13);
            label5.TabIndex = 22;
            label5.Text = "Наименование:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(42, 64);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 13);
            label6.TabIndex = 23;
            label6.Text = "Артикул:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Артикул:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(744, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Цена:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(768, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Фото:";
            // 
            // номерLabel
            // 
            this.номерLabel.AutoSize = true;
            this.номерLabel.Location = new System.Drawing.Point(663, 2);
            this.номерLabel.Name = "номерLabel";
            this.номерLabel.Size = new System.Drawing.Size(44, 13);
            this.номерLabel.TabIndex = 2;
            this.номерLabel.Text = "Номер:";
            this.номерLabel.Visible = false;
            // 
            // производительLabel
            // 
            this.производительLabel.AutoSize = true;
            this.производительLabel.Location = new System.Drawing.Point(619, 11);
            this.производительLabel.Name = "производительLabel";
            this.производительLabel.Size = new System.Drawing.Size(89, 13);
            this.производительLabel.TabIndex = 4;
            this.производительLabel.Text = "Производитель:";
            // 
            // наименованиеLabel
            // 
            this.наименованиеLabel.AutoSize = true;
            this.наименованиеLabel.Location = new System.Drawing.Point(622, 37);
            this.наименованиеLabel.Name = "наименованиеLabel";
            this.наименованиеLabel.Size = new System.Drawing.Size(86, 13);
            this.наименованиеLabel.TabIndex = 6;
            this.наименованиеLabel.Text = "Наименование:";
            // 
            // артикулLabel
            // 
            this.артикулLabel.AutoSize = true;
            this.артикулLabel.Location = new System.Drawing.Point(657, 63);
            this.артикулLabel.Name = "артикулLabel";
            this.артикулLabel.Size = new System.Drawing.Size(51, 13);
            this.артикулLabel.TabIndex = 8;
            this.артикулLabel.Text = "Артикул:";
            // 
            // ценаLabel
            // 
            this.ценаLabel.AutoSize = true;
            this.ценаLabel.Location = new System.Drawing.Point(671, 89);
            this.ценаLabel.Name = "ценаLabel";
            this.ценаLabel.Size = new System.Drawing.Size(36, 13);
            this.ценаLabel.TabIndex = 10;
            this.ценаLabel.Text = "Цена:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Цена:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(471, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Количество:";
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.AutoGenerateColumns = false;
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерDataGridViewTextBoxColumn,
            this.производительDataGridViewTextBoxColumn,
            this.наименованиеDataGridViewTextBoxColumn,
            this.артикулDataGridViewTextBoxColumn,
            this.фотографияDataGridViewImageColumn,
            this.ценаDataGridViewTextBoxColumn});
            this.tableDataGridView.DataSource = this.tableBindingSource;
            this.tableDataGridView.Location = new System.Drawing.Point(6, 135);
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.Size = new System.Drawing.Size(1197, 549);
            this.tableDataGridView.TabIndex = 1;
            this.tableDataGridView.TabStop = false;
            this.tableDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableDataGridView_CellContentClick_1);
            this.tableDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableDataGridView_CellEndEdit);
            this.tableDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tableDataGridView_CellMouseClick);
            this.tableDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableDataGridView_CellValidated);
            this.tableDataGridView.CurrentCellChanged += new System.EventHandler(this.tableDataGridView_CurrentCellChanged);
            this.tableDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableDataGridView_DataError_1);
            this.tableDataGridView.DoubleClick += new System.EventHandler(this.tableDataGridView_DoubleClick);
            this.tableDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableDataGridView_MouseClick);
            // 
            // номерDataGridViewTextBoxColumn
            // 
            this.номерDataGridViewTextBoxColumn.DataPropertyName = "номер";
            this.номерDataGridViewTextBoxColumn.FillWeight = 50F;
            this.номерDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.номерDataGridViewTextBoxColumn.Name = "номерDataGridViewTextBoxColumn";
            this.номерDataGridViewTextBoxColumn.Visible = false;
            this.номерDataGridViewTextBoxColumn.Width = 50;
            // 
            // производительDataGridViewTextBoxColumn
            // 
            this.производительDataGridViewTextBoxColumn.DataPropertyName = "производитель";
            this.производительDataGridViewTextBoxColumn.FillWeight = 220F;
            this.производительDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.производительDataGridViewTextBoxColumn.Name = "производительDataGridViewTextBoxColumn";
            this.производительDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.производительDataGridViewTextBoxColumn.Width = 220;
            // 
            // наименованиеDataGridViewTextBoxColumn
            // 
            this.наименованиеDataGridViewTextBoxColumn.DataPropertyName = "наименование";
            this.наименованиеDataGridViewTextBoxColumn.FillWeight = 300F;
            this.наименованиеDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.Name = "наименованиеDataGridViewTextBoxColumn";
            this.наименованиеDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.наименованиеDataGridViewTextBoxColumn.Width = 300;
            // 
            // артикулDataGridViewTextBoxColumn
            // 
            this.артикулDataGridViewTextBoxColumn.DataPropertyName = "артикул";
            this.артикулDataGridViewTextBoxColumn.FillWeight = 150F;
            this.артикулDataGridViewTextBoxColumn.HeaderText = "Артикул";
            this.артикулDataGridViewTextBoxColumn.Name = "артикулDataGridViewTextBoxColumn";
            this.артикулDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.артикулDataGridViewTextBoxColumn.Width = 150;
            // 
            // фотографияDataGridViewImageColumn
            // 
            this.фотографияDataGridViewImageColumn.DataPropertyName = "фотография";
            this.фотографияDataGridViewImageColumn.HeaderText = "Фотография";
            this.фотографияDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.фотографияDataGridViewImageColumn.Name = "фотографияDataGridViewImageColumn";
            // 
            // ценаDataGridViewTextBoxColumn
            // 
            this.ценаDataGridViewTextBoxColumn.DataPropertyName = "цена";
            this.ценаDataGridViewTextBoxColumn.FillWeight = 70F;
            this.ценаDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.ценаDataGridViewTextBoxColumn.Name = "ценаDataGridViewTextBoxColumn";
            this.ценаDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ценаDataGridViewTextBoxColumn.Width = 70;
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataMember = "Table";
            this.tableBindingSource.DataSource = this.данные;
            // 
            // данные
            // 
            this.данные.DataSetName = "данные";
            this.данные.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView_зависимость
            // 
            this.dataGridView_зависимость.AllowUserToAddRows = false;
            this.dataGridView_зависимость.AllowUserToDeleteRows = false;
            this.dataGridView_зависимость.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView_зависимость.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_зависимость.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_зависимость.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_зависимость.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_зависимость.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column34});
            this.dataGridView_зависимость.Cursor = System.Windows.Forms.Cursors.No;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_зависимость.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_зависимость.EnableHeadersVisualStyles = false;
            this.dataGridView_зависимость.GridColor = System.Drawing.Color.Red;
            this.dataGridView_зависимость.Location = new System.Drawing.Point(1155, 6);
            this.dataGridView_зависимость.Name = "dataGridView_зависимость";
            this.dataGridView_зависимость.ReadOnly = true;
            this.dataGridView_зависимость.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_зависимость.RowHeadersVisible = false;
            this.dataGridView_зависимость.Size = new System.Drawing.Size(600, 145);
            this.dataGridView_зависимость.TabIndex = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Чис";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Арт.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "x/-+";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.ToolTipText = "множитель";
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn5.HeaderText = "Множитель";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // Column34
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.Column34.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column34.HeaderText = "ID Art.";
            this.Column34.Name = "Column34";
            this.Column34.ReadOnly = true;
            this.Column34.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column34.Width = 90;
            // 
            // contextMenuStripрасчетка
            // 
            this.contextMenuStripрасчетка.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemрассчёткакопировать,
            this.toolStripMenuItemрасчткавставить});
            this.contextMenuStripрасчетка.Name = "contextMenuStrip1";
            this.contextMenuStripрасчетка.Size = new System.Drawing.Size(140, 48);
            // 
            // toolStripMenuItemрассчёткакопировать
            // 
            this.toolStripMenuItemрассчёткакопировать.Name = "toolStripMenuItemрассчёткакопировать";
            this.toolStripMenuItemрассчёткакопировать.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItemрассчёткакопировать.Text = "Копировать";
            this.toolStripMenuItemрассчёткакопировать.Click += new System.EventHandler(this.toolStripMenuItemрассчёткакопировать_Click);
            // 
            // toolStripMenuItemрасчткавставить
            // 
            this.toolStripMenuItemрасчткавставить.Name = "toolStripMenuItemрасчткавставить";
            this.toolStripMenuItemрасчткавставить.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItemрасчткавставить.Text = "Вставить";
            this.toolStripMenuItemрасчткавставить.Click += new System.EventHandler(this.toolStripMenuItemрасчткавставить_Click);
            // 
            // dataGridView_расчёт_2
            // 
            this.dataGridView_расчёт_2.AllowUserToDeleteRows = false;
            this.dataGridView_расчёт_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_расчёт_2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.Column33,
            this.Column35,
            this.Примечание});
            this.dataGridView_расчёт_2.Location = new System.Drawing.Point(6, 179);
            this.dataGridView_расчёт_2.MultiSelect = false;
            this.dataGridView_расчёт_2.Name = "dataGridView_расчёт_2";
            this.dataGridView_расчёт_2.RowHeadersWidth = 11;
            this.dataGridView_расчёт_2.Size = new System.Drawing.Size(1133, 530);
            this.dataGridView_расчёт_2.TabIndex = 48;
            this.dataGridView_расчёт_2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_расчёт_2_CellBeginEdit);
            this.dataGridView_расчёт_2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_расчёт_2_CellEndEdit);
            this.dataGridView_расчёт_2.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_расчёт_2_CellLeave);
            this.dataGridView_расчёт_2.CurrentCellChanged += new System.EventHandler(this.dataGridView_расчёт_2_CurrentCellChanged);
            this.dataGridView_расчёт_2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_расчёт_2_RowEnter);
            this.dataGridView_расчёт_2.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_расчёт_2_RowLeave);
            this.dataGridView_расчёт_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_расчёт_2_KeyDown);
            this.dataGridView_расчёт_2.Validated += new System.EventHandler(this.dataGridView_расчёт_2_Validated);
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "№__";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn33.Width = 40;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn34.Width = 110;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn35.Width = 340;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.HeaderText = "Артикул";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn36.Width = 180;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Картинка";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn37.Width = 85;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.HeaderText = "Кол";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn38.Width = 75;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.HeaderText = "Цена всего";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn39.Width = 85;
            // 
            // Column33
            // 
            this.Column33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Transparent;
            this.Column33.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column33.HeaderText = "ID";
            this.Column33.MinimumWidth = 2;
            this.Column33.Name = "Column33";
            this.Column33.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column33.Width = 2;
            // 
            // Column35
            // 
            this.Column35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.Column35.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column35.HeaderText = "ID Art.";
            this.Column35.MinimumWidth = 2;
            this.Column35.Name = "Column35";
            this.Column35.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column35.Width = 2;
            // 
            // Примечание
            // 
            this.Примечание.HeaderText = "Примечание";
            this.Примечание.Name = "Примечание";
            this.Примечание.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Примечание.Width = 85;
            // 
            // dataGridView_муляж
            // 
            this.dataGridView_муляж.AllowUserToDeleteRows = false;
            this.dataGridView_муляж.AllowUserToResizeColumns = false;
            this.dataGridView_муляж.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_муляж.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn8,
            this.Column36});
            this.dataGridView_муляж.Location = new System.Drawing.Point(6, 30);
            this.dataGridView_муляж.MultiSelect = false;
            this.dataGridView_муляж.Name = "dataGridView_муляж";
            this.dataGridView_муляж.RowHeadersVisible = false;
            this.dataGridView_муляж.Size = new System.Drawing.Size(478, 119);
            this.dataGridView_муляж.TabIndex = 52;
            this.dataGridView_муляж.TabStop = false;
            this.dataGridView_муляж.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_муляж_CellBeginEdit);
            this.dataGridView_муляж.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_муляж_CellEnter);
            this.dataGridView_муляж.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_муляж_CellValidated);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "№";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Чис";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 270;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "x/-+";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "x",
            "/",
            "-",
            "+"});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.ToolTipText = "множитель";
            this.dataGridViewComboBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Множитель";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // Column36
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            this.Column36.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column36.HeaderText = "ID Art.";
            this.Column36.MinimumWidth = 2;
            this.Column36.Name = "Column36";
            this.Column36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column36.Width = 2;
            // 
            // tableBindingNavigator
            // 
            this.tableBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tableBindingNavigator.BindingSource = this.tableBindingSource;
            this.tableBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tableBindingNavigator.DeleteItem = null;
            this.tableBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
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
            this.toolStripButtonDel2,
            this.toolStripButton_del_row_strip,
            this.tableBindingNavigatorSaveItem,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton4});
            this.tableBindingNavigator.Location = new System.Drawing.Point(7, 110);
            this.tableBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tableBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tableBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tableBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tableBindingNavigator.Name = "tableBindingNavigator";
            this.tableBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tableBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tableBindingNavigator.Size = new System.Drawing.Size(378, 25);
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
            this.bindingNavigatorAddNewItem.Text = "Добавить пустую строку в конец прайса";
            this.bindingNavigatorAddNewItem.Visible = false;
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.bindingNavigatorMoveLastItem.Text = "Переместиться в конец строк";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDel2
            // 
            this.toolStripButtonDel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDel2.Image")));
            this.toolStripButtonDel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel2.Name = "toolStripButtonDel2";
            this.toolStripButtonDel2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDel2.Text = "Удалить выбранную строку";
            this.toolStripButtonDel2.Click += new System.EventHandler(this.toolStripButtonDel2_Click);
            // 
            // toolStripButton_del_row_strip
            // 
            this.toolStripButton_del_row_strip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_del_row_strip.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_del_row_strip.Image")));
            this.toolStripButton_del_row_strip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_del_row_strip.Name = "toolStripButton_del_row_strip";
            this.toolStripButton_del_row_strip.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_del_row_strip.Text = "Удалить определенного производителя из прайса";
            this.toolStripButton_del_row_strip.Click += new System.EventHandler(this.toolStripButton_del_row_strip_Click);
            // 
            // tableBindingNavigatorSaveItem
            // 
            this.tableBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tableBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tableBindingNavigatorSaveItem.Image")));
            this.tableBindingNavigatorSaveItem.Name = "tableBindingNavigatorSaveItem";
            this.tableBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tableBindingNavigatorSaveItem.Text = "Сохранить в прайс текущие изменения";
            this.tableBindingNavigatorSaveItem.Click += new System.EventHandler(this.tableBindingNavigatorSaveItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Упорядочить данные в прайсе.";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Загрузить заново данные с прайса.";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Быстрый поиск";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.BackgroundImage")));
            this.toolStripButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Давайте кнопке придумает название id359";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // номерTextBox
            // 
            this.номерTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "номер", true));
            this.номерTextBox.Location = new System.Drawing.Point(711, -1);
            this.номерTextBox.Name = "номерTextBox";
            this.номерTextBox.Size = new System.Drawing.Size(223, 20);
            this.номерTextBox.TabIndex = 3;
            this.номерTextBox.Visible = false;
            // 
            // производительTextBox
            // 
            this.производительTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "производитель", true));
            this.производительTextBox.Location = new System.Drawing.Point(711, 8);
            this.производительTextBox.Name = "производительTextBox";
            this.производительTextBox.Size = new System.Drawing.Size(223, 20);
            this.производительTextBox.TabIndex = 5;
            // 
            // наименованиеTextBox
            // 
            this.наименованиеTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "наименование", true));
            this.наименованиеTextBox.Location = new System.Drawing.Point(711, 34);
            this.наименованиеTextBox.Name = "наименованиеTextBox";
            this.наименованиеTextBox.Size = new System.Drawing.Size(223, 20);
            this.наименованиеTextBox.TabIndex = 7;
            // 
            // артикулTextBox
            // 
            this.артикулTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "артикул", true));
            this.артикулTextBox.Location = new System.Drawing.Point(711, 60);
            this.артикулTextBox.Name = "артикулTextBox";
            this.артикулTextBox.Size = new System.Drawing.Size(223, 20);
            this.артикулTextBox.TabIndex = 9;
            // 
            // ценаTextBox
            // 
            this.ценаTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBindingSource, "цена", true));
            this.ценаTextBox.Location = new System.Drawing.Point(711, 86);
            this.ценаTextBox.Name = "ценаTextBox";
            this.ценаTextBox.Size = new System.Drawing.Size(223, 20);
            this.ценаTextBox.TabIndex = 11;
            this.ценаTextBox.Leave += new System.EventHandler(this.ценаTextBox_Leave);
            // 
            // button_загрузить_изображение
            // 
            this.button_загрузить_изображение.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_загрузить_изображение.BackgroundImage")));
            this.button_загрузить_изображение.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_загрузить_изображение.Location = new System.Drawing.Point(1080, 40);
            this.button_загрузить_изображение.Name = "button_загрузить_изображение";
            this.button_загрузить_изображение.Size = new System.Drawing.Size(30, 30);
            this.button_загрузить_изображение.TabIndex = 14;
            this.button_загрузить_изображение.UseVisualStyleBackColor = true;
            this.button_загрузить_изображение.Click += new System.EventHandler(this.Button1_загрузить_изображение);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(1080, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_скриншот
            // 
            this.button_скриншот.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_скриншот.BackgroundImage")));
            this.button_скриншот.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_скриншот.Location = new System.Drawing.Point(1, 39);
            this.button_скриншот.Name = "button_скриншот";
            this.button_скриншот.Size = new System.Drawing.Size(30, 30);
            this.button_скриншот.TabIndex = 17;
            this.button_скриншот.UseVisualStyleBackColor = true;
            this.button_скриншот.Click += new System.EventHandler(this.button_скриншот_Click);
            // 
            // button_сохр_изобр_в_фаил
            // 
            this.button_сохр_изобр_в_фаил.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_сохр_изобр_в_фаил.BackgroundImage")));
            this.button_сохр_изобр_в_фаил.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_сохр_изобр_в_фаил.Location = new System.Drawing.Point(1, 9);
            this.button_сохр_изобр_в_фаил.Name = "button_сохр_изобр_в_фаил";
            this.button_сохр_изобр_в_фаил.Size = new System.Drawing.Size(30, 30);
            this.button_сохр_изобр_в_фаил.TabIndex = 18;
            this.button_сохр_изобр_в_фаил.UseVisualStyleBackColor = true;
            this.button_сохр_изобр_в_фаил.Click += new System.EventHandler(this.button_сохр_изобр_в_фаил_Click);
            // 
            // button_поиск_копий_в_базе
            // 
            this.button_поиск_копий_в_базе.Location = new System.Drawing.Point(633, 111);
            this.button_поиск_копий_в_базе.Name = "button_поиск_копий_в_базе";
            this.button_поиск_копий_в_базе.Size = new System.Drawing.Size(121, 22);
            this.button_поиск_копий_в_базе.TabIndex = 37;
            this.button_поиск_копий_в_базе.Text = "Поиск одинаковых";
            this.button_поиск_копий_в_базе.UseVisualStyleBackColor = true;
            this.button_поиск_копий_в_базе.Visible = false;
            this.button_поиск_копий_в_базе.Click += new System.EventHandler(this.button2_Click);
            // 
            // фотографияPictureBox
            // 
            this.фотографияPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.фотографияPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.tableBindingSource, "фотография", true));
            this.фотографияPictureBox.Location = new System.Drawing.Point(940, 11);
            this.фотографияPictureBox.Name = "фотографияPictureBox";
            this.фотографияPictureBox.Size = new System.Drawing.Size(135, 89);
            this.фотографияPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.фотографияPictureBox.TabIndex = 13;
            this.фотографияPictureBox.TabStop = false;
            this.фотографияPictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.фотографияPictureBox_LoadCompleted);
            this.фотографияPictureBox.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.фотографияPictureBox_LoadProgressChanged);
            this.фотографияPictureBox.BackgroundImageChanged += new System.EventHandler(this.фотографияPictureBox_BackgroundImageChanged);
            this.фотографияPictureBox.Click += new System.EventHandler(this.фотографияPictureBox_Click);
            this.фотографияPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.фотографияPictureBox_Paint);
            this.фотографияPictureBox.DoubleClick += new System.EventHandler(this.фотографияPictureBox_DoubleClick);
            // 
            // label_consol
            // 
            this.label_consol.AutoSize = true;
            this.label_consol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_consol.Location = new System.Drawing.Point(2, 688);
            this.label_consol.Margin = new System.Windows.Forms.Padding(0);
            this.label_consol.Name = "label_consol";
            this.label_consol.Size = new System.Drawing.Size(121, 13);
            this.label_consol.TabIndex = 19;
            this.label_consol.Text = "Привет. Я консолька..";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(310, 0);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(310, 25);
            this.toolStripContainer1.TabIndex = 20;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // button_добавить_значение_в_табл
            // 
            this.button_добавить_значение_в_табл.Location = new System.Drawing.Point(7, 62);
            this.button_добавить_значение_в_табл.Name = "button_добавить_значение_в_табл";
            this.button_добавить_значение_в_табл.Size = new System.Drawing.Size(729, 33);
            this.button_добавить_значение_в_табл.TabIndex = 21;
            this.button_добавить_значение_в_табл.Text = "Добавить новое значение в конец прайса";
            this.button_добавить_значение_в_табл.UseVisualStyleBackColor = true;
            this.button_добавить_значение_в_табл.Click += new System.EventHandler(this.button_добавить_значение_в_табл_Click);
            // 
            // pictureBox_new_image
            // 
            this.pictureBox_new_image.Location = new System.Drawing.Point(812, 11);
            this.pictureBox_new_image.Name = "pictureBox_new_image";
            this.pictureBox_new_image.Size = new System.Drawing.Size(110, 93);
            this.pictureBox_new_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_new_image.TabIndex = 26;
            this.pictureBox_new_image.TabStop = false;
            this.pictureBox_new_image.Click += new System.EventHandler(this.pictureBox_new_image_Click);
            this.pictureBox_new_image.DoubleClick += new System.EventHandler(this.pictureBox_new_image_DoubleClick);
            // 
            // button_new_foto
            // 
            this.button_new_foto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_new_foto.BackgroundImage")));
            this.button_new_foto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_new_foto.Location = new System.Drawing.Point(930, 11);
            this.button_new_foto.Name = "button_new_foto";
            this.button_new_foto.Size = new System.Drawing.Size(47, 39);
            this.button_new_foto.TabIndex = 19;
            this.button_new_foto.UseVisualStyleBackColor = true;
            this.button_new_foto.Click += new System.EventHandler(this.button_new_foto_Click);
            // 
            // button_new_foto_down
            // 
            this.button_new_foto_down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_new_foto_down.BackgroundImage")));
            this.button_new_foto_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_new_foto_down.Location = new System.Drawing.Point(984, 12);
            this.button_new_foto_down.Name = "button_new_foto_down";
            this.button_new_foto_down.Size = new System.Drawing.Size(47, 39);
            this.button_new_foto_down.TabIndex = 19;
            this.button_new_foto_down.UseVisualStyleBackColor = true;
            this.button_new_foto_down.Click += new System.EventHandler(this.button_new_foto_down_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 4;
            this.numericUpDown1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericUpDown1.Location = new System.Drawing.Point(742, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown1.TabIndex = 25;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Click += new System.EventHandler(this.numericUpDown1_Click);
            this.numericUpDown1.DoubleClick += new System.EventHandler(this.numericUpDown1_DoubleClick);
            this.numericUpDown1.Enter += new System.EventHandler(this.numericUpDown1_Enter);
            this.numericUpDown1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyUp);
            this.numericUpDown1.Leave += new System.EventHandler(this.numericUpDown1_Leave);
            this.numericUpDown1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseClick);
            // 
            // textBox_new_артикул
            // 
            this.textBox_new_артикул.Location = new System.Drawing.Point(551, 32);
            this.textBox_new_артикул.Name = "textBox_new_артикул";
            this.textBox_new_артикул.Size = new System.Drawing.Size(185, 20);
            this.textBox_new_артикул.TabIndex = 24;
            this.textBox_new_артикул.Text = "Пусто";
            this.textBox_new_артикул.Enter += new System.EventHandler(this.textBox_new_артикул_Enter);
            this.textBox_new_артикул.Leave += new System.EventHandler(this.textBox_new_артикул_Leave);
            // 
            // textBox_new_наименование
            // 
            this.textBox_new_наименование.Location = new System.Drawing.Point(198, 32);
            this.textBox_new_наименование.Name = "textBox_new_наименование";
            this.textBox_new_наименование.Size = new System.Drawing.Size(348, 20);
            this.textBox_new_наименование.TabIndex = 23;
            this.textBox_new_наименование.Text = "Пусто";
            this.textBox_new_наименование.Enter += new System.EventHandler(this.textBox_new_наименование_Enter);
            this.textBox_new_наименование.Leave += new System.EventHandler(this.textBox_new_наименование_Leave);
            // 
            // textBox_new_производитель
            // 
            this.textBox_new_производитель.Location = new System.Drawing.Point(2, 32);
            this.textBox_new_производитель.Name = "textBox_new_производитель";
            this.textBox_new_производитель.Size = new System.Drawing.Size(191, 20);
            this.textBox_new_производитель.TabIndex = 22;
            this.textBox_new_производитель.Text = "Пусто";
            this.textBox_new_производитель.TextChanged += new System.EventHandler(this.textBox_new_производитель_TextChanged);
            this.textBox_new_производитель.Enter += new System.EventHandler(this.textBox_new_производитель_Enter);
            this.textBox_new_производитель.Leave += new System.EventHandler(this.textBox_new_производитель_Leave);
            // 
            // button_ctroky_v_bazy
            // 
            this.button_ctroky_v_bazy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ctroky_v_bazy.BackgroundImage")));
            this.button_ctroky_v_bazy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ctroky_v_bazy.Location = new System.Drawing.Point(210, 6);
            this.button_ctroky_v_bazy.Name = "button_ctroky_v_bazy";
            this.button_ctroky_v_bazy.Size = new System.Drawing.Size(35, 28);
            this.button_ctroky_v_bazy.TabIndex = 44;
            this.button_ctroky_v_bazy.UseVisualStyleBackColor = true;
            this.button_ctroky_v_bazy.Click += new System.EventHandler(this.button_ctroky_v_bazy_Click);
            // 
            // button_perenos_obratno
            // 
            this.button_perenos_obratno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_perenos_obratno.BackgroundImage")));
            this.button_perenos_obratno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_perenos_obratno.Location = new System.Drawing.Point(245, 6);
            this.button_perenos_obratno.Name = "button_perenos_obratno";
            this.button_perenos_obratno.Size = new System.Drawing.Size(47, 28);
            this.button_perenos_obratno.TabIndex = 41;
            this.button_perenos_obratno.UseVisualStyleBackColor = true;
            this.button_perenos_obratno.Click += new System.EventHandler(this.button_perenos_obratno_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(544, 61);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown3.TabIndex = 35;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(529, 113);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 17);
            this.checkBox2.TabIndex = 34;
            this.checkBox2.Text = "ниже перейти?";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button_поиск_по_баз_замен
            // 
            this.button_поиск_по_баз_замен.Location = new System.Drawing.Point(418, 84);
            this.button_поиск_по_баз_замен.Name = "button_поиск_по_баз_замен";
            this.button_поиск_по_баз_замен.Size = new System.Drawing.Size(160, 22);
            this.button_поиск_по_баз_замен.TabIndex = 33;
            this.button_поиск_по_баз_замен.Text = "Заменить в расчётке строку";
            this.button_поиск_по_баз_замен.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_поиск_по_баз_замен.UseVisualStyleBackColor = true;
            this.button_поиск_по_баз_замен.Click += new System.EventHandler(this.button_поиск_по_баз_замен_Click);
            // 
            // button_поиск_по_баз_под
            // 
            this.button_поиск_по_баз_под.Location = new System.Drawing.Point(219, 84);
            this.button_поиск_по_баз_под.Name = "button_поиск_по_баз_под";
            this.button_поиск_по_баз_под.Size = new System.Drawing.Size(195, 22);
            this.button_поиск_по_баз_под.TabIndex = 32;
            this.button_поиск_по_баз_под.Text = "Добавить в расчётку. Под строкой.";
            this.button_поиск_по_баз_под.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_поиск_по_баз_под.UseVisualStyleBackColor = true;
            this.button_поиск_по_баз_под.Click += new System.EventHandler(this.button_поиск_по_баз_под_Click);
            // 
            // button_поиск_по_баз_доб
            // 
            this.button_поиск_по_баз_доб.Location = new System.Drawing.Point(4, 84);
            this.button_поиск_по_баз_доб.Name = "button_поиск_по_баз_доб";
            this.button_поиск_по_баз_доб.Size = new System.Drawing.Size(210, 22);
            this.button_поиск_по_баз_доб.TabIndex = 31;
            this.button_поиск_по_баз_доб.Text = "Добавить в расчётку. В конец списка.";
            this.button_поиск_по_баз_доб.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_поиск_по_баз_доб.UseVisualStyleBackColor = true;
            this.button_поиск_по_баз_доб.Click += new System.EventHandler(this.button_поиск_по_баз_доб_Click);
            // 
            // comboBox_цена_поиск_по_базе
            // 
            this.comboBox_цена_поиск_по_базе.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_цена_поиск_по_базе.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_цена_поиск_по_базе.FormattingEnabled = true;
            this.comboBox_цена_поиск_по_базе.Location = new System.Drawing.Point(362, 60);
            this.comboBox_цена_поиск_по_базе.Name = "comboBox_цена_поиск_по_базе";
            this.comboBox_цена_поиск_по_базе.Size = new System.Drawing.Size(105, 21);
            this.comboBox_цена_поиск_по_базе.TabIndex = 30;
            this.comboBox_цена_поиск_по_базе.SelectedIndexChanged += new System.EventHandler(this.comboBox_цена_поиск_по_базе_SelectedIndexChanged);
            this.comboBox_цена_поиск_по_базе.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_цена_поиск_по_базе_KeyDown);
            this.comboBox_цена_поиск_по_базе.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox_цена_поиск_по_базе_KeyUp);
            // 
            // comboBox_артикул_поиск_по_базе
            // 
            this.comboBox_артикул_поиск_по_базе.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_артикул_поиск_по_базе.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_артикул_поиск_по_базе.FormattingEnabled = true;
            this.comboBox_артикул_поиск_по_базе.Location = new System.Drawing.Point(96, 60);
            this.comboBox_артикул_поиск_по_базе.Name = "comboBox_артикул_поиск_по_базе";
            this.comboBox_артикул_поиск_по_базе.Size = new System.Drawing.Size(224, 21);
            this.comboBox_артикул_поиск_по_базе.TabIndex = 28;
            this.comboBox_артикул_поиск_по_базе.SelectedIndexChanged += new System.EventHandler(this.comboBox_артикул_поиск_по_базе_SelectedIndexChanged);
            this.comboBox_артикул_поиск_по_базе.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_артикул_поиск_по_базе_KeyDown);
            this.comboBox_артикул_поиск_по_базе.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox_артикул_поиск_по_базе_KeyUp);
            // 
            // comboBox_наименование_поиск_по_базе
            // 
            this.comboBox_наименование_поиск_по_базе.AutoCompleteCustomSource.AddRange(new string[] {
            "2222",
            "3333",
            "2222",
            "1111"});
            this.comboBox_наименование_поиск_по_базе.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_наименование_поиск_по_базе.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_наименование_поиск_по_базе.FormattingEnabled = true;
            this.comboBox_наименование_поиск_по_базе.Location = new System.Drawing.Point(96, 35);
            this.comboBox_наименование_поиск_по_базе.Name = "comboBox_наименование_поиск_по_базе";
            this.comboBox_наименование_поиск_по_базе.Size = new System.Drawing.Size(511, 21);
            this.comboBox_наименование_поиск_по_базе.TabIndex = 27;
            this.comboBox_наименование_поиск_по_базе.SelectedIndexChanged += new System.EventHandler(this.comboBox_наименование_поиск_по_базе_SelectedIndexChanged);
            this.comboBox_наименование_поиск_по_базе.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_наименование_поиск_по_базе_KeyDown);
            this.comboBox_наименование_поиск_по_базе.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox_наименование_поиск_по_базе_KeyUp);
            // 
            // comboBox1_поиск
            // 
            this.comboBox1_поиск.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox1_поиск.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1_поиск.FormattingEnabled = true;
            this.comboBox1_поиск.Location = new System.Drawing.Point(96, 10);
            this.comboBox1_поиск.Name = "comboBox1_поиск";
            this.comboBox1_поиск.Size = new System.Drawing.Size(511, 21);
            this.comboBox1_поиск.TabIndex = 25;
            this.comboBox1_поиск.SelectedIndexChanged += new System.EventHandler(this.comboBox1_поиск_SelectedIndexChanged);
            this.comboBox1_поиск.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_поиск_KeyDown);
            this.comboBox1_поиск.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_поиск_KeyUp);
            // 
            // textBox_new_stolbeth
            // 
            this.textBox_new_stolbeth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.textBox_new_stolbeth.Location = new System.Drawing.Point(87, 15);
            this.textBox_new_stolbeth.Name = "textBox_new_stolbeth";
            this.textBox_new_stolbeth.Size = new System.Drawing.Size(286, 20);
            this.textBox_new_stolbeth.TabIndex = 29;
            this.textBox_new_stolbeth.Text = "Раздел";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Controls.Add(this.button_new_razdel_vmesto);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.numericUpDown2);
            this.groupBox4.Controls.Add(this.button_new_razdel);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox_new_stolbeth);
            this.groupBox4.Location = new System.Drawing.Point(755, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 95);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Создание раздела в таблице расчетки";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "Создать над текущей строкой";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(274, 39);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(102, 17);
            this.checkBox3.TabIndex = 37;
            this.checkBox3.Text = "ниже перейти?";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button_new_razdel_vmesto
            // 
            this.button_new_razdel_vmesto.Location = new System.Drawing.Point(10, 62);
            this.button_new_razdel_vmesto.Name = "button_new_razdel_vmesto";
            this.button_new_razdel_vmesto.Size = new System.Drawing.Size(162, 23);
            this.button_new_razdel_vmesto.TabIndex = 36;
            this.button_new_razdel_vmesto.Text = "Изменить в текущей строке";
            this.button_new_razdel_vmesto.UseVisualStyleBackColor = true;
            this.button_new_razdel_vmesto.Click += new System.EventHandler(this.button_new_razdel_vmesto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(176, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "В столбец:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(238, 38);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(30, 20);
            this.numericUpDown2.TabIndex = 32;
            this.numericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // button_new_razdel
            // 
            this.button_new_razdel.Location = new System.Drawing.Point(10, 37);
            this.button_new_razdel.Name = "button_new_razdel";
            this.button_new_razdel.Size = new System.Drawing.Size(162, 23);
            this.button_new_razdel.TabIndex = 31;
            this.button_new_razdel.Text = "Добавить в конец таблицы";
            this.button_new_razdel.UseVisualStyleBackColor = true;
            this.button_new_razdel.MarginChanged += new System.EventHandler(this.button_new_razdel_MarginChanged);
            this.button_new_razdel.Click += new System.EventHandler(this.button_new_razdel_Click);
            this.button_new_razdel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_new_razdel_MouseClick);
            this.button_new_razdel.MouseCaptureChanged += new System.EventHandler(this.button_new_razdel_MouseCaptureChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Имя раздела";
            // 
            // label_consol_2
            // 
            this.label_consol_2.AutoSize = true;
            this.label_consol_2.Location = new System.Drawing.Point(3, 731);
            this.label_consol_2.Margin = new System.Windows.Forms.Padding(0);
            this.label_consol_2.Name = "label_consol_2";
            this.label_consol_2.Size = new System.Drawing.Size(136, 13);
            this.label_consol_2.TabIndex = 31;
            this.label_consol_2.Text = "Привет. Я консолька 2....";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.button_no_image_for_excel);
            this.groupBox6.Controls.Add(this.button_save_to_pdf3);
            this.groupBox6.Controls.Add(this.button_save_to_pdf2);
            this.groupBox6.Controls.Add(this.button_new_ophins);
            this.groupBox6.Controls.Add(this.button_new_ophins2);
            this.groupBox6.Location = new System.Drawing.Point(755, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(386, 60);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Экспорт расчетки";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(209, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "РЕМОНТ!!";
            // 
            // button_no_image_for_excel
            // 
            this.button_no_image_for_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_no_image_for_excel.Location = new System.Drawing.Point(87, 29);
            this.button_no_image_for_excel.Name = "button_no_image_for_excel";
            this.button_no_image_for_excel.Size = new System.Drawing.Size(30, 27);
            this.button_no_image_for_excel.TabIndex = 47;
            this.button_no_image_for_excel.UseVisualStyleBackColor = true;
            this.button_no_image_for_excel.Click += new System.EventHandler(this.button_no_image_for_excel_Click);
            // 
            // button_save_to_pdf3
            // 
            this.button_save_to_pdf3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_save_to_pdf3.BackgroundImage")));
            this.button_save_to_pdf3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_save_to_pdf3.Location = new System.Drawing.Point(291, 12);
            this.button_save_to_pdf3.Name = "button_save_to_pdf3";
            this.button_save_to_pdf3.Size = new System.Drawing.Size(91, 44);
            this.button_save_to_pdf3.TabIndex = 44;
            this.button_save_to_pdf3.UseVisualStyleBackColor = true;
            this.button_save_to_pdf3.Click += new System.EventHandler(this.button_save_to_pdf3_Click);
            // 
            // button_save_to_pdf2
            // 
            this.button_save_to_pdf2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_save_to_pdf2.BackgroundImage")));
            this.button_save_to_pdf2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_save_to_pdf2.Enabled = false;
            this.button_save_to_pdf2.Location = new System.Drawing.Point(197, 13);
            this.button_save_to_pdf2.Name = "button_save_to_pdf2";
            this.button_save_to_pdf2.Size = new System.Drawing.Size(91, 44);
            this.button_save_to_pdf2.TabIndex = 43;
            this.button_save_to_pdf2.UseVisualStyleBackColor = true;
            this.button_save_to_pdf2.Click += new System.EventHandler(this.button_save_to_pdf2_Click);
            // 
            // button_new_ophins
            // 
            this.button_new_ophins.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_new_ophins.BackgroundImage")));
            this.button_new_ophins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_new_ophins.Location = new System.Drawing.Point(7, 13);
            this.button_new_ophins.Name = "button_new_ophins";
            this.button_new_ophins.Size = new System.Drawing.Size(93, 44);
            this.button_new_ophins.TabIndex = 41;
            this.button_new_ophins.UseVisualStyleBackColor = true;
            this.button_new_ophins.Click += new System.EventHandler(this.button_new_ophins_Click);
            // 
            // button_new_ophins2
            // 
            this.button_new_ophins2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_new_ophins2.BackgroundImage")));
            this.button_new_ophins2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_new_ophins2.Location = new System.Drawing.Point(102, 13);
            this.button_new_ophins2.Name = "button_new_ophins2";
            this.button_new_ophins2.Size = new System.Drawing.Size(93, 44);
            this.button_new_ophins2.TabIndex = 46;
            this.button_new_ophins2.UseVisualStyleBackColor = true;
            this.button_new_ophins2.Click += new System.EventHandler(this.button_new_ophins2_Click);
            // 
            // groupBox_Расчеты
            // 
            this.groupBox_Расчеты.Controls.Add(this.label18);
            this.groupBox_Расчеты.Controls.Add(this.comboBox_елупни);
            this.groupBox_Расчеты.Controls.Add(this.button_взять_актуальные_цены_с_базы);
            this.groupBox_Расчеты.Controls.Add(this.button_расчитать);
            this.groupBox_Расчеты.Location = new System.Drawing.Point(490, 122);
            this.groupBox_Расчеты.Name = "groupBox_Расчеты";
            this.groupBox_Расчеты.Size = new System.Drawing.Size(213, 42);
            this.groupBox_Расчеты.TabIndex = 40;
            this.groupBox_Расчеты.TabStop = false;
            this.groupBox_Расчеты.Text = "Настройка цены: ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(276, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "ххх";
            // 
            // comboBox_елупни
            // 
            this.comboBox_елупни.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_елупни.FormattingEnabled = true;
            this.comboBox_елупни.Location = new System.Drawing.Point(5, 15);
            this.comboBox_елупни.Name = "comboBox_елупни";
            this.comboBox_елупни.Size = new System.Drawing.Size(145, 21);
            this.comboBox_елупни.TabIndex = 42;
            this.comboBox_елупни.SelectedIndexChanged += new System.EventHandler(this.comboBox_елупни_SelectedIndexChanged);
            // 
            // button_взять_актуальные_цены_с_базы
            // 
            this.button_взять_актуальные_цены_с_базы.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_взять_актуальные_цены_с_базы.BackgroundImage")));
            this.button_взять_актуальные_цены_с_базы.Location = new System.Drawing.Point(154, 10);
            this.button_взять_актуальные_цены_с_базы.Name = "button_взять_актуальные_цены_с_базы";
            this.button_взять_актуальные_цены_с_базы.Size = new System.Drawing.Size(25, 25);
            this.button_взять_актуальные_цены_с_базы.TabIndex = 40;
            this.button_взять_актуальные_цены_с_базы.UseVisualStyleBackColor = true;
            this.button_взять_актуальные_цены_с_базы.Click += new System.EventHandler(this.button_взять_актуальные_цены_с_базы_Click);
            // 
            // button_расчитать
            // 
            this.button_расчитать.Image = ((System.Drawing.Image)(resources.GetObject("button_расчитать.Image")));
            this.button_расчитать.Location = new System.Drawing.Point(181, 9);
            this.button_расчитать.Name = "button_расчитать";
            this.button_расчитать.Size = new System.Drawing.Size(28, 28);
            this.button_расчитать.TabIndex = 4;
            this.button_расчитать.UseVisualStyleBackColor = true;
            this.button_расчитать.Click += new System.EventHandler(this.button_расчитать_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 715);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 46;
            this.label13.Text = "P.S.:";
            // 
            // textBox_P_S
            // 
            this.textBox_P_S.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_P_S.Location = new System.Drawing.Point(37, 712);
            this.textBox_P_S.Name = "textBox_P_S";
            this.textBox_P_S.Size = new System.Drawing.Size(1101, 20);
            this.textBox_P_S.TabIndex = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(-654, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "Таблица зависимостей:";
            // 
            // tableTableAdapter
            // 
            this.tableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TableTableAdapter = this.tableTableAdapter;
            this.tableAdapterManager.UpdateOrder = load__baze.данныеTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.Location = new System.Drawing.Point(707, 14);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 76);
            this.trackBar1.TabIndex = 46;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 50;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.данныеToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2603, 24);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.новыйРасчетToolStripMenuItem,
            this.загрузитьРасчетToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.сохранитьРасчетToolStripMenuItem,
            this.toolStripSeparator1,
            this.сохранитьРасчетВPDFБезЦенToolStripMenuItem,
            this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem,
            this.сохранитьВExcelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.загрузитьПрайсToolStripMenuItem,
            this.сохранитьПрайсToolStripMenuItem,
            this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem,
            this.сделатьКопиюПрайсаВToolStripMenuItem,
            this.toolStripSeparator3,
            this.вРазработкеСоздатьШаблонToolStripMenuItem,
            this.скачатьССайтаПрайсToolStripMenuItem,
            this.данныеОПрайсеНаСайтеToolStripMenuItem});
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.загрузитьToolStripMenuItem.Text = "Файл";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AccessibleDescription = "расчётка";
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(345, 6);
            // 
            // новыйРасчетToolStripMenuItem
            // 
            this.новыйРасчетToolStripMenuItem.BackColor = System.Drawing.Color.Cornsilk;
            this.новыйРасчетToolStripMenuItem.Name = "новыйРасчетToolStripMenuItem";
            this.новыйРасчетToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.новыйРасчетToolStripMenuItem.Text = "Новый расчет                                         Ctrl+N";
            this.новыйРасчетToolStripMenuItem.Click += new System.EventHandler(this.новыйРасчетToolStripMenuItem_Click);
            // 
            // загрузитьРасчетToolStripMenuItem
            // 
            this.загрузитьРасчетToolStripMenuItem.BackColor = System.Drawing.Color.Cornsilk;
            this.загрузитьРасчетToolStripMenuItem.Name = "загрузитьРасчетToolStripMenuItem";
            this.загрузитьРасчетToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.загрузитьРасчетToolStripMenuItem.Text = "Загрузить расчет                                    Ctrl+O";
            this.загрузитьРасчетToolStripMenuItem.Click += new System.EventHandler(this.загрузитьРасчетToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.BackColor = System.Drawing.Color.Cornsilk;
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить расчёт                                  Ctrl+S";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // сохранитьРасчетToolStripMenuItem
            // 
            this.сохранитьРасчетToolStripMenuItem.BackColor = System.Drawing.Color.Cornsilk;
            this.сохранитьРасчетToolStripMenuItem.Name = "сохранитьРасчетToolStripMenuItem";
            this.сохранитьРасчетToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.сохранитьРасчетToolStripMenuItem.Text = "Сохранить расчёт как...";
            this.сохранитьРасчетToolStripMenuItem.Click += new System.EventHandler(this.сохранитьРасчетToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Blue;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Navy;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(345, 6);
            // 
            // сохранитьРасчетВPDFБезЦенToolStripMenuItem
            // 
            this.сохранитьРасчетВPDFБезЦенToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.сохранитьРасчетВPDFБезЦенToolStripMenuItem.Name = "сохранитьРасчетВPDFБезЦенToolStripMenuItem";
            this.сохранитьРасчетВPDFБезЦенToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.сохранитьРасчетВPDFБезЦенToolStripMenuItem.Text = "Сохранить расчет в PDF без цен";
            this.сохранитьРасчетВPDFБезЦенToolStripMenuItem.Click += new System.EventHandler(this.сохранитьРасчетВPDFБезЦенToolStripMenuItem_Click);
            // 
            // сохранитьРасчетВPDFСЦенамиToolStripMenuItem
            // 
            this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem.Name = "сохранитьРасчетВPDFСЦенамиToolStripMenuItem";
            this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem.Text = "Сохранить расчет в PDF с ценами";
            this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem.Click += new System.EventHandler(this.сохранитьРасчетВPDFСЦенамиToolStripMenuItem_Click);
            // 
            // сохранитьВExcelToolStripMenuItem
            // 
            this.сохранитьВExcelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.сохранитьВExcelToolStripMenuItem.Name = "сохранитьВExcelToolStripMenuItem";
            this.сохранитьВExcelToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.сохранитьВExcelToolStripMenuItem.Text = "Cохранить в Excel";
            this.сохранитьВExcelToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВExcelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(348, 22);
            this.toolStripMenuItem1.Text = "Добавить листом в Excel";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(345, 6);
            // 
            // загрузитьПрайсToolStripMenuItem
            // 
            this.загрузитьПрайсToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.загрузитьПрайсToolStripMenuItem.Name = "загрузитьПрайсToolStripMenuItem";
            this.загрузитьПрайсToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.загрузитьПрайсToolStripMenuItem.Text = "Загрузить прайс из др.источника        Ctrl+Shift+O";
            this.загрузитьПрайсToolStripMenuItem.Click += new System.EventHandler(this.загрузитьПрайсToolStripMenuItem_Click);
            // 
            // сохранитьПрайсToolStripMenuItem
            // 
            this.сохранитьПрайсToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.сохранитьПрайсToolStripMenuItem.Name = "сохранитьПрайсToolStripMenuItem";
            this.сохранитьПрайсToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.сохранитьПрайсToolStripMenuItem.Text = "Сохранить прайс                                     Ctrl+Shift+S";
            this.сохранитьПрайсToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПрайсToolStripMenuItem_Click);
            // 
            // загрузитьБазуЗаногоБезСохраненийToolStripMenuItem
            // 
            this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Name = "загрузитьБазуЗаногоБезСохраненийToolStripMenuItem";
            this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Text = "Загрузить прайс заново без сохранений";
            this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem.Click += new System.EventHandler(this.загрузитьБазуЗаногоБезСохраненийToolStripMenuItem_Click);
            // 
            // сделатьКопиюПрайсаВToolStripMenuItem
            // 
            this.сделатьКопиюПрайсаВToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.сделатьКопиюПрайсаВToolStripMenuItem.Name = "сделатьКопиюПрайсаВToolStripMenuItem";
            this.сделатьКопиюПрайсаВToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.сделатьКопиюПрайсаВToolStripMenuItem.Text = "Сделать копию прайса в";
            this.сделатьКопиюПрайсаВToolStripMenuItem.Click += new System.EventHandler(this.сделатьКопиюПрайсаВToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(345, 6);
            // 
            // вРазработкеСоздатьШаблонToolStripMenuItem
            // 
            this.вРазработкеСоздатьШаблонToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.вРазработкеСоздатьШаблонToolStripMenuItem.Name = "вРазработкеСоздатьШаблонToolStripMenuItem";
            this.вРазработкеСоздатьШаблонToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.вРазработкеСоздатьШаблонToolStripMenuItem.Text = "Шаблоны прайса                                     Ctrl+H";
            this.вРазработкеСоздатьШаблонToolStripMenuItem.Click += new System.EventHandler(this.вРазработкеСоздатьШаблонToolStripMenuItem_Click);
            // 
            // скачатьССайтаПрайсToolStripMenuItem
            // 
            this.скачатьССайтаПрайсToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.скачатьССайтаПрайсToolStripMenuItem.Name = "скачатьССайтаПрайсToolStripMenuItem";
            this.скачатьССайтаПрайсToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.скачатьССайтаПрайсToolStripMenuItem.Text = "Скачать с сайта прайс";
            this.скачатьССайтаПрайсToolStripMenuItem.Click += new System.EventHandler(this.скачатьССайтаПрайсToolStripMenuItem_Click);
            // 
            // данныеОПрайсеНаСайтеToolStripMenuItem
            // 
            this.данныеОПрайсеНаСайтеToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.данныеОПрайсеНаСайтеToolStripMenuItem.Name = "данныеОПрайсеНаСайтеToolStripMenuItem";
            this.данныеОПрайсеНаСайтеToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.данныеОПрайсеНаСайтеToolStripMenuItem.Text = "Данные о прайсе на сайте";
            this.данныеОПрайсеНаСайтеToolStripMenuItem.Click += new System.EventHandler(this.данныеОПрайсеНаСайтеToolStripMenuItem_Click);
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem,
            this.перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem,
            this.поискОдинаковыхАртикуловВПрайсеToolStripMenuItem,
            this.toolStripSeparator4,
            this.загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem,
            this.получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem,
            this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem,
            this.обновитьЦенуСФайлаExcelToolStripMenuItem,
            this.изменитьНаЦенуПроизводителяToolStripMenuItem});
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.данныеToolStripMenuItem.Text = "Данные";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(439, 6);
            // 
            // перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem
            // 
            this.перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem.Name = "перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem";
            this.перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem.Text = "Перенести выбранную строку из расчетки в конец прайса";
            this.перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem.Click += new System.EventHandler(this.перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem_Click);
            // 
            // перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem
            // 
            this.перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem.Name = "перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem";
            this.перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem.Text = "Перенести все данные из расчетки в конец прайса ";
            this.перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem.Click += new System.EventHandler(this.перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem_Click);
            // 
            // поискОдинаковыхАртикуловВПрайсеToolStripMenuItem
            // 
            this.поискОдинаковыхАртикуловВПрайсеToolStripMenuItem.Name = "поискОдинаковыхАртикуловВПрайсеToolStripMenuItem";
            this.поискОдинаковыхАртикуловВПрайсеToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.поискОдинаковыхАртикуловВПрайсеToolStripMenuItem.Text = "Поиск одинаковых артикулов в прайсе";
            this.поискОдинаковыхАртикуловВПрайсеToolStripMenuItem.Click += new System.EventHandler(this.поискОдинаковыхАртикуловВПрайсеToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(439, 6);
            // 
            // загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem
            // 
            this.загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem.Name = "загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem";
            this.загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem.Text = "Загрузка из Excel файла с данными в расчет для переноса в прайс ";
            this.загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem.Click += new System.EventHandler(this.загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem_Click);
            // 
            // получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem
            // 
            this.получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem.Name = "получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem";
            this.получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem.Text = "Получить заготовку Excel файла с фотографиями для переноса";
            this.получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem.Click += new System.EventHandler(this.получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem_Click);
            // 
            // получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem
            // 
            this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem.Name = "получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem";
            this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem.Text = "Перенести в Excel из прайса определенного производителя";
            this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem.Click += new System.EventHandler(this.получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem_Click);
            // 
            // обновитьЦенуСФайлаExcelToolStripMenuItem
            // 
            this.обновитьЦенуСФайлаExcelToolStripMenuItem.Name = "обновитьЦенуСФайлаExcelToolStripMenuItem";
            this.обновитьЦенуСФайлаExcelToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.обновитьЦенуСФайлаExcelToolStripMenuItem.Text = "Обновить цену с файла Excel";
            this.обновитьЦенуСФайлаExcelToolStripMenuItem.Click += new System.EventHandler(this.обновитьЦенуСФайлаExcelToolStripMenuItem_Click);
            // 
            // изменитьНаЦенуПроизводителяToolStripMenuItem
            // 
            this.изменитьНаЦенуПроизводителяToolStripMenuItem.Name = "изменитьНаЦенуПроизводителяToolStripMenuItem";
            this.изменитьНаЦенуПроизводителяToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.изменитьНаЦенуПроизводителяToolStripMenuItem.Text = "Изменить на % цену производителя";
            this.изменитьНаЦенуПроизводителяToolStripMenuItem.Click += new System.EventHandler(this.изменитьНаЦенуПроизводителяToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.натройкиДляОбновлениеЦенИзExcelToolStripMenuItem,
            this.пробник2ToolStripMenuItem,
            this.настройкиToolStripMenuItem1});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // натройкиДляОбновлениеЦенИзExcelToolStripMenuItem
            // 
            this.натройкиДляОбновлениеЦенИзExcelToolStripMenuItem.Name = "натройкиДляОбновлениеЦенИзExcelToolStripMenuItem";
            this.натройкиДляОбновлениеЦенИзExcelToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.натройкиДляОбновлениеЦенИзExcelToolStripMenuItem.Text = "Наcтройки обновления цен из Excel";
            this.натройкиДляОбновлениеЦенИзExcelToolStripMenuItem.Click += new System.EventHandler(this.натройкиДляОбновлениеЦенИзExcelToolStripMenuItem_Click);
            // 
            // пробник2ToolStripMenuItem
            // 
            this.пробник2ToolStripMenuItem.Name = "пробник2ToolStripMenuItem";
            this.пробник2ToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.пробник2ToolStripMenuItem.Text = "Назад в расчете";
            this.пробник2ToolStripMenuItem.Click += new System.EventHandler(this.пробник2ToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem1
            // 
            this.настройкиToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("настройкиToolStripMenuItem1.Image")));
            this.настройкиToolStripMenuItem1.Name = "настройкиToolStripMenuItem1";
            this.настройкиToolStripMenuItem1.Size = new System.Drawing.Size(272, 22);
            this.настройкиToolStripMenuItem1.Text = "Настройки";
            this.настройкиToolStripMenuItem1.Click += new System.EventHandler(this.настройкиToolStripMenuItem1_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаПоПрайсуToolStripMenuItem1,
            this.справкаПоРасчетуToolStripMenuItem,
            this.справкаПоТаблицеЗависимостиToolStripMenuItem,
            this.toolStripSeparator5,
            this.справкаПоПрайсуToolStripMenuItem,
            this.радиоToolStripMenuItem,
            this.отладочнаяКнопкаToolStripMenuItem});
            this.справкаToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // справкаПоПрайсуToolStripMenuItem1
            // 
            this.справкаПоПрайсуToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("справкаПоПрайсуToolStripMenuItem1.Image")));
            this.справкаПоПрайсуToolStripMenuItem1.Name = "справкаПоПрайсуToolStripMenuItem1";
            this.справкаПоПрайсуToolStripMenuItem1.Size = new System.Drawing.Size(251, 22);
            this.справкаПоПрайсуToolStripMenuItem1.Text = "Передать привет Автору!";
            this.справкаПоПрайсуToolStripMenuItem1.Click += new System.EventHandler(this.справкаПоПрайсуToolStripMenuItem1_Click);
            // 
            // справкаПоРасчетуToolStripMenuItem
            // 
            this.справкаПоРасчетуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("справкаПоРасчетуToolStripMenuItem.Image")));
            this.справкаПоРасчетуToolStripMenuItem.Name = "справкаПоРасчетуToolStripMenuItem";
            this.справкаПоРасчетуToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.справкаПоРасчетуToolStripMenuItem.Text = "Искусственный интеллект 2002г";
            this.справкаПоРасчетуToolStripMenuItem.Click += new System.EventHandler(this.справкаПоРасчетуToolStripMenuItem_Click);
            // 
            // справкаПоТаблицеЗависимостиToolStripMenuItem
            // 
            this.справкаПоТаблицеЗависимостиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("справкаПоТаблицеЗависимостиToolStripMenuItem.Image")));
            this.справкаПоТаблицеЗависимостиToolStripMenuItem.Name = "справкаПоТаблицеЗависимостиToolStripMenuItem";
            this.справкаПоТаблицеЗависимостиToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.справкаПоТаблицеЗависимостиToolStripMenuItem.Text = "Телик";
            this.справкаПоТаблицеЗависимостиToolStripMenuItem.Click += new System.EventHandler(this.справкаПоТаблицеЗависимостиToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(248, 6);
            // 
            // справкаПоПрайсуToolStripMenuItem
            // 
            this.справкаПоПрайсуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("справкаПоПрайсуToolStripMenuItem.Image")));
            this.справкаПоПрайсуToolStripMenuItem.Name = "справкаПоПрайсуToolStripMenuItem";
            this.справкаПоПрайсуToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.справкаПоПрайсуToolStripMenuItem.Text = "О программе";
            this.справкаПоПрайсуToolStripMenuItem.Click += new System.EventHandler(this.справкаПоПрайсуToolStripMenuItem_Click);
            // 
            // радиоToolStripMenuItem
            // 
            this.радиоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьToolStripMenuItem,
            this.выключитьToolStripMenuItem,
            this.уцуToolStripMenuItem,
            this.сменитьВолнуToolStripMenuItem,
            this.найтиДрстанцииToolStripMenuItem});
            this.радиоToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("радиоToolStripMenuItem.Image")));
            this.радиоToolStripMenuItem.Name = "радиоToolStripMenuItem";
            this.радиоToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.радиоToolStripMenuItem.Text = "Радио";
            this.радиоToolStripMenuItem.Click += new System.EventHandler(this.радиоToolStripMenuItem_Click);
            // 
            // включитьToolStripMenuItem
            // 
            this.включитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("включитьToolStripMenuItem.Image")));
            this.включитьToolStripMenuItem.Name = "включитьToolStripMenuItem";
            this.включитьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.включитьToolStripMenuItem.Text = "Включить";
            this.включитьToolStripMenuItem.Click += new System.EventHandler(this.включитьToolStripMenuItem_Click);
            // 
            // выключитьToolStripMenuItem
            // 
            this.выключитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выключитьToolStripMenuItem.Image")));
            this.выключитьToolStripMenuItem.Name = "выключитьToolStripMenuItem";
            this.выключитьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.выключитьToolStripMenuItem.Text = "Выключить";
            this.выключитьToolStripMenuItem.Click += new System.EventHandler(this.выключитьToolStripMenuItem_Click);
            // 
            // уцуToolStripMenuItem
            // 
            this.уцуToolStripMenuItem.Name = "уцуToolStripMenuItem";
            this.уцуToolStripMenuItem.Size = new System.Drawing.Size(155, 6);
            // 
            // сменитьВолнуToolStripMenuItem
            // 
            this.сменитьВолнуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сменитьВолнуToolStripMenuItem.Image")));
            this.сменитьВолнуToolStripMenuItem.Name = "сменитьВолнуToolStripMenuItem";
            this.сменитьВолнуToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.сменитьВолнуToolStripMenuItem.Text = "Сменить волну";
            this.сменитьВолнуToolStripMenuItem.Click += new System.EventHandler(this.сменитьВолнуToolStripMenuItem_Click);
            // 
            // найтиДрстанцииToolStripMenuItem
            // 
            this.найтиДрстанцииToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("найтиДрстанцииToolStripMenuItem.Image")));
            this.найтиДрстанцииToolStripMenuItem.Name = "найтиДрстанцииToolStripMenuItem";
            this.найтиДрстанцииToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.найтиДрстанцииToolStripMenuItem.Text = "Архив станций";
            this.найтиДрстанцииToolStripMenuItem.Click += new System.EventHandler(this.найтиДрстанцииToolStripMenuItem_Click);
            // 
            // отладочнаяКнопкаToolStripMenuItem
            // 
            this.отладочнаяКнопкаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("отладочнаяКнопкаToolStripMenuItem.Image")));
            this.отладочнаяКнопкаToolStripMenuItem.Name = "отладочнаяКнопкаToolStripMenuItem";
            this.отладочнаяКнопкаToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.отладочнаяКнопкаToolStripMenuItem.Text = "Инфо о прайсе";
            this.отладочнаяКнопкаToolStripMenuItem.Click += new System.EventHandler(this.отладочнаяКнопкаToolStripMenuItem_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Зависимости:";
            // 
            // label_rachetka
            // 
            this.label_rachetka.AutoSize = true;
            this.label_rachetka.Location = new System.Drawing.Point(390, 163);
            this.label_rachetka.Name = "label_rachetka";
            this.label_rachetka.Size = new System.Drawing.Size(92, 13);
            this.label_rachetka.TabIndex = 55;
            this.label_rachetka.Text = "Расчетка: Новая";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.button_сохранить_расчёт_быстро);
            this.groupBox5.Controls.Add(this.button_copy);
            this.groupBox5.Controls.Add(this.button_pase);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button_ctroky_v_bazy);
            this.groupBox5.Controls.Add(this.button_perenos_obratno);
            this.groupBox5.Controls.Add(this.button_Calk);
            this.groupBox5.Controls.Add(this.button_del_razhet_end);
            this.groupBox5.Controls.Add(this.button_del_razhet);
            this.groupBox5.Controls.Add(this.button_del_zavisim);
            this.groupBox5.Controls.Add(this.button_new_zavisim);
            this.groupBox5.Location = new System.Drawing.Point(5, 144);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(380, 33);
            this.groupBox5.TabIndex = 56;
            this.groupBox5.TabStop = false;
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.Location = new System.Drawing.Point(124, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(28, 28);
            this.button7.TabIndex = 49;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button_сохранить_расчёт_быстро
            // 
            this.button_сохранить_расчёт_быстро.Image = ((System.Drawing.Image)(resources.GetObject("button_сохранить_расчёт_быстро.Image")));
            this.button_сохранить_расчёт_быстро.Location = new System.Drawing.Point(348, 6);
            this.button_сохранить_расчёт_быстро.Name = "button_сохранить_расчёт_быстро";
            this.button_сохранить_расчёт_быстро.Size = new System.Drawing.Size(28, 28);
            this.button_сохранить_расчёт_быстро.TabIndex = 48;
            this.button_сохранить_расчёт_быстро.UseVisualStyleBackColor = true;
            this.button_сохранить_расчёт_быстро.Click += new System.EventHandler(this.button_сохранить_расчёт_быстро_Click);
            // 
            // button_copy
            // 
            this.button_copy.Image = ((System.Drawing.Image)(resources.GetObject("button_copy.Image")));
            this.button_copy.Location = new System.Drawing.Point(152, 6);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(28, 28);
            this.button_copy.TabIndex = 47;
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // button_pase
            // 
            this.button_pase.Enabled = false;
            this.button_pase.Image = ((System.Drawing.Image)(resources.GetObject("button_pase.Image")));
            this.button_pase.Location = new System.Drawing.Point(182, 6);
            this.button_pase.Name = "button_pase";
            this.button_pase.Size = new System.Drawing.Size(28, 28);
            this.button_pase.TabIndex = 46;
            this.button_pase.UseVisualStyleBackColor = true;
            this.button_pase.Click += new System.EventHandler(this.button_pase_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(292, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 28);
            this.button4.TabIndex = 45;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_Calk
            // 
            this.button_Calk.Image = ((System.Drawing.Image)(resources.GetObject("button_Calk.Image")));
            this.button_Calk.Location = new System.Drawing.Point(320, 6);
            this.button_Calk.Name = "button_Calk";
            this.button_Calk.Size = new System.Drawing.Size(28, 28);
            this.button_Calk.TabIndex = 5;
            this.button_Calk.UseVisualStyleBackColor = true;
            this.button_Calk.Click += new System.EventHandler(this.button_Calk_Click);
            // 
            // button_del_razhet_end
            // 
            this.button_del_razhet_end.Image = ((System.Drawing.Image)(resources.GetObject("button_del_razhet_end.Image")));
            this.button_del_razhet_end.Location = new System.Drawing.Point(33, 6);
            this.button_del_razhet_end.Name = "button_del_razhet_end";
            this.button_del_razhet_end.Size = new System.Drawing.Size(28, 28);
            this.button_del_razhet_end.TabIndex = 3;
            this.button_del_razhet_end.UseVisualStyleBackColor = true;
            this.button_del_razhet_end.Click += new System.EventHandler(this.button_del_razhet_end_Click);
            // 
            // button_del_razhet
            // 
            this.button_del_razhet.Image = ((System.Drawing.Image)(resources.GetObject("button_del_razhet.Image")));
            this.button_del_razhet.Location = new System.Drawing.Point(4, 6);
            this.button_del_razhet.Name = "button_del_razhet";
            this.button_del_razhet.Size = new System.Drawing.Size(28, 28);
            this.button_del_razhet.TabIndex = 2;
            this.button_del_razhet.UseVisualStyleBackColor = true;
            this.button_del_razhet.Click += new System.EventHandler(this.button_del_razhet_Click);
            // 
            // button_del_zavisim
            // 
            this.button_del_zavisim.Image = ((System.Drawing.Image)(resources.GetObject("button_del_zavisim.Image")));
            this.button_del_zavisim.Location = new System.Drawing.Point(91, 6);
            this.button_del_zavisim.Name = "button_del_zavisim";
            this.button_del_zavisim.Size = new System.Drawing.Size(28, 28);
            this.button_del_zavisim.TabIndex = 1;
            this.button_del_zavisim.UseVisualStyleBackColor = true;
            this.button_del_zavisim.Click += new System.EventHandler(this.button_del_zavisim_Click);
            // 
            // button_new_zavisim
            // 
            this.button_new_zavisim.Image = ((System.Drawing.Image)(resources.GetObject("button_new_zavisim.Image")));
            this.button_new_zavisim.Location = new System.Drawing.Point(62, 6);
            this.button_new_zavisim.Name = "button_new_zavisim";
            this.button_new_zavisim.Size = new System.Drawing.Size(28, 28);
            this.button_new_zavisim.TabIndex = 0;
            this.button_new_zavisim.UseVisualStyleBackColor = true;
            this.button_new_zavisim.Click += new System.EventHandler(this.button_new_zavisim_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Controls.Add(this.button_del_zavis);
            this.groupBox7.Location = new System.Drawing.Point(485, 24);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(30, 74);
            this.groupBox7.TabIndex = 57;
            this.groupBox7.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(2, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 28);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_del_zavis
            // 
            this.button_del_zavis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_del_zavis.BackgroundImage")));
            this.button_del_zavis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_del_zavis.Location = new System.Drawing.Point(2, 40);
            this.button_del_zavis.Name = "button_del_zavis";
            this.button_del_zavis.Size = new System.Drawing.Size(28, 28);
            this.button_del_zavis.TabIndex = 0;
            this.button_del_zavis.UseVisualStyleBackColor = true;
            this.button_del_zavis.Click += new System.EventHandler(this.button_del_zavis_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // математика
            // 
            this.математика.Interval = 1;
            this.математика.Tick += new System.EventHandler(this.математика_Tick);
            // 
            // duble_art_art
            // 
            this.duble_art_art.Tick += new System.EventHandler(this.duble_art_art_Tick);
            // 
            // button_Baza_RACHET
            // 
            this.button_Baza_RACHET.BackColor = System.Drawing.Color.LightPink;
            this.button_Baza_RACHET.Location = new System.Drawing.Point(2, 25);
            this.button_Baza_RACHET.Name = "button_Baza_RACHET";
            this.button_Baza_RACHET.Size = new System.Drawing.Size(1209, 23);
            this.button_Baza_RACHET.TabIndex = 58;
            this.button_Baza_RACHET.Text = "ПРАЙС > РАСЧЁТ";
            this.button_Baza_RACHET.UseVisualStyleBackColor = false;
            this.button_Baza_RACHET.Click += new System.EventHandler(this.button_Baza_RACHET_Click);
            // 
            // groupBox_baza
            // 
            this.groupBox_baza.Controls.Add(this.label_info_ftp);
            this.groupBox_baza.Controls.Add(this.groupBox_поиск);
            this.groupBox_baza.Controls.Add(this.label_добавленно);
            this.groupBox_baza.Controls.Add(this.button_добавить);
            this.groupBox_baza.Controls.Add(this.button_поиск);
            this.groupBox_baza.Controls.Add(this.tableDataGridView);
            this.groupBox_baza.Controls.Add(this.label_consol);
            this.groupBox_baza.Controls.Add(this.tableBindingNavigator);
            this.groupBox_baza.Controls.Add(this.checkBox2);
            this.groupBox_baza.Controls.Add(this.button_поиск_копий_в_базе);
            this.groupBox_baza.Controls.Add(this.groupBox_добавить);
            this.groupBox_baza.Location = new System.Drawing.Point(2, 47);
            this.groupBox_baza.Name = "groupBox_baza";
            this.groupBox_baza.Size = new System.Drawing.Size(1199, 719);
            this.groupBox_baza.TabIndex = 59;
            this.groupBox_baza.TabStop = false;
            this.groupBox_baza.Text = "Прайс";
            // 
            // label_info_ftp
            // 
            this.label_info_ftp.AutoEllipsis = true;
            this.label_info_ftp.BackColor = System.Drawing.Color.Orange;
            this.label_info_ftp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.label_info_ftp.ForeColor = System.Drawing.Color.Blue;
            this.label_info_ftp.Location = new System.Drawing.Point(758, 114);
            this.label_info_ftp.Name = "label_info_ftp";
            this.label_info_ftp.Size = new System.Drawing.Size(375, 16);
            this.label_info_ftp.TabIndex = 38;
            this.label_info_ftp.Text = "Выполняю запрос интернете";
            // 
            // groupBox_поиск
            // 
            this.groupBox_поиск.Controls.Add(this.ценаLabel);
            this.groupBox_поиск.Controls.Add(this.ценаTextBox);
            this.groupBox_поиск.Controls.Add(this.артикулLabel);
            this.groupBox_поиск.Controls.Add(this.артикулTextBox);
            this.groupBox_поиск.Controls.Add(this.наименованиеLabel);
            this.groupBox_поиск.Controls.Add(this.наименованиеTextBox);
            this.groupBox_поиск.Controls.Add(this.производительTextBox);
            this.groupBox_поиск.Controls.Add(this.производительLabel);
            this.groupBox_поиск.Controls.Add(this.button1);
            this.groupBox_поиск.Controls.Add(this.groupBox1);
            this.groupBox_поиск.Controls.Add(this.label12);
            this.groupBox_поиск.Controls.Add(this.numericUpDown3);
            this.groupBox_поиск.Controls.Add(label8);
            this.groupBox_поиск.Controls.Add(label5);
            this.groupBox_поиск.Controls.Add(this.button_поиск_по_баз_замен);
            this.groupBox_поиск.Controls.Add(label6);
            this.groupBox_поиск.Controls.Add(this.button_загрузить_изображение);
            this.groupBox_поиск.Controls.Add(this.button_поиск_по_баз_под);
            this.groupBox_поиск.Controls.Add(this.label7);
            this.groupBox_поиск.Controls.Add(this.номерTextBox);
            this.groupBox_поиск.Controls.Add(this.button_поиск_по_баз_доб);
            this.groupBox_поиск.Controls.Add(this.comboBox1_поиск);
            this.groupBox_поиск.Controls.Add(this.номерLabel);
            this.groupBox_поиск.Controls.Add(this.comboBox_цена_поиск_по_базе);
            this.groupBox_поиск.Controls.Add(this.comboBox_наименование_поиск_по_базе);
            this.groupBox_поиск.Controls.Add(this.comboBox_артикул_поиск_по_базе);
            this.groupBox_поиск.Controls.Add(this.pictureBox_no_image);
            this.groupBox_поиск.Controls.Add(this.фотографияPictureBox);
            this.groupBox_поиск.Location = new System.Drawing.Point(58, -2);
            this.groupBox_поиск.Name = "groupBox_поиск";
            this.groupBox_поиск.Size = new System.Drawing.Size(1148, 113);
            this.groupBox_поиск.TabIndex = 30;
            this.groupBox_поиск.TabStop = false;
            this.groupBox_поиск.Text = "Поиск по прайсу";
            this.groupBox_поиск.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_сохр_изобр_в_фаил);
            this.groupBox1.Controls.Add(this.button_удалить_изобр_в_фаил);
            this.groupBox1.Controls.Add(this.button_скриншот);
            this.groupBox1.Location = new System.Drawing.Point(1113, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(32, 103);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            // 
            // button_удалить_изобр_в_фаил
            // 
            this.button_удалить_изобр_в_фаил.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_удалить_изобр_в_фаил.BackgroundImage")));
            this.button_удалить_изобр_в_фаил.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_удалить_изобр_в_фаил.Location = new System.Drawing.Point(1, 70);
            this.button_удалить_изобр_в_фаил.Name = "button_удалить_изобр_в_фаил";
            this.button_удалить_изобр_в_фаил.Size = new System.Drawing.Size(30, 30);
            this.button_удалить_изобр_в_фаил.TabIndex = 38;
            this.button_удалить_изобр_в_фаил.UseVisualStyleBackColor = true;
            this.button_удалить_изобр_в_фаил.Click += new System.EventHandler(this.button_удалить_изобр_в_фаил_Click);
            // 
            // pictureBox_no_image
            // 
            this.pictureBox_no_image.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_no_image.Image")));
            this.pictureBox_no_image.Location = new System.Drawing.Point(940, 10);
            this.pictureBox_no_image.Name = "pictureBox_no_image";
            this.pictureBox_no_image.Size = new System.Drawing.Size(135, 92);
            this.pictureBox_no_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_no_image.TabIndex = 59;
            this.pictureBox_no_image.TabStop = false;
            this.pictureBox_no_image.Visible = false;
            // 
            // label_добавленно
            // 
            this.label_добавленно.AutoSize = true;
            this.label_добавленно.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label_добавленно.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_добавленно.ForeColor = System.Drawing.Color.Blue;
            this.label_добавленно.Location = new System.Drawing.Point(386, 110);
            this.label_добавленно.Name = "label_добавленно";
            this.label_добавленно.Size = new System.Drawing.Size(141, 25);
            this.label_добавленно.TabIndex = 32;
            this.label_добавленно.Text = "Добавленно!";
            this.label_добавленно.Visible = false;
            this.label_добавленно.Click += new System.EventHandler(this.label_добавленно_Click);
            // 
            // button_добавить
            // 
            this.button_добавить.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_добавить.BackgroundImage")));
            this.button_добавить.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_добавить.Enabled = false;
            this.button_добавить.Location = new System.Drawing.Point(3, 56);
            this.button_добавить.Name = "button_добавить";
            this.button_добавить.Size = new System.Drawing.Size(55, 55);
            this.button_добавить.TabIndex = 29;
            this.button_добавить.UseVisualStyleBackColor = true;
            this.button_добавить.Click += new System.EventHandler(this.button_добавить_Click);
            // 
            // button_поиск
            // 
            this.button_поиск.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_поиск.BackgroundImage")));
            this.button_поиск.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_поиск.Location = new System.Drawing.Point(3, 1);
            this.button_поиск.Name = "button_поиск";
            this.button_поиск.Size = new System.Drawing.Size(55, 55);
            this.button_поиск.TabIndex = 28;
            this.button_поиск.UseVisualStyleBackColor = true;
            this.button_поиск.Click += new System.EventHandler(this.button_поиск_Click);
            // 
            // groupBox_добавить
            // 
            this.groupBox_добавить.Controls.Add(this.button_del_new_image);
            this.groupBox_добавить.Controls.Add(this.pictureBox_no_image_добавить_в_прайс);
            this.groupBox_добавить.Controls.Add(this.label14);
            this.groupBox_добавить.Controls.Add(this.button_добавить_значение_в_табл);
            this.groupBox_добавить.Controls.Add(this.pictureBox_new_image);
            this.groupBox_добавить.Controls.Add(label1);
            this.groupBox_добавить.Controls.Add(this.button_new_foto);
            this.groupBox_добавить.Controls.Add(label2);
            this.groupBox_добавить.Controls.Add(this.button_new_foto_down);
            this.groupBox_добавить.Controls.Add(this.label3);
            this.groupBox_добавить.Controls.Add(this.numericUpDown1);
            this.groupBox_добавить.Controls.Add(this.label4);
            this.groupBox_добавить.Controls.Add(this.textBox_new_артикул);
            this.groupBox_добавить.Controls.Add(this.textBox_new_производитель);
            this.groupBox_добавить.Controls.Add(this.textBox_new_наименование);
            this.groupBox_добавить.Location = new System.Drawing.Point(62, 0);
            this.groupBox_добавить.Name = "groupBox_добавить";
            this.groupBox_добавить.Size = new System.Drawing.Size(1039, 111);
            this.groupBox_добавить.TabIndex = 31;
            this.groupBox_добавить.TabStop = false;
            this.groupBox_добавить.Text = "Добавить в прайс";
            // 
            // button_del_new_image
            // 
            this.button_del_new_image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_del_new_image.BackgroundImage")));
            this.button_del_new_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_del_new_image.Location = new System.Drawing.Point(958, 58);
            this.button_del_new_image.Name = "button_del_new_image";
            this.button_del_new_image.Size = new System.Drawing.Size(47, 39);
            this.button_del_new_image.TabIndex = 61;
            this.button_del_new_image.UseVisualStyleBackColor = true;
            this.button_del_new_image.Click += new System.EventHandler(this.button_del_new_image_Click);
            // 
            // pictureBox_no_image_добавить_в_прайс
            // 
            this.pictureBox_no_image_добавить_в_прайс.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_no_image_добавить_в_прайс.Image")));
            this.pictureBox_no_image_добавить_в_прайс.Location = new System.Drawing.Point(815, 15);
            this.pictureBox_no_image_добавить_в_прайс.Name = "pictureBox_no_image_добавить_в_прайс";
            this.pictureBox_no_image_добавить_в_прайс.Size = new System.Drawing.Size(107, 88);
            this.pictureBox_no_image_добавить_в_прайс.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_no_image_добавить_в_прайс.TabIndex = 60;
            this.pictureBox_no_image_добавить_в_прайс.TabStop = false;
            // 
            // groupBox_razhet
            // 
            this.groupBox_razhet.Controls.Add(this.groupBox_asq);
            this.groupBox_razhet.Controls.Add(this.button_asq);
            this.groupBox_razhet.Controls.Add(this.pictureBox_Raz);
            this.groupBox_razhet.Controls.Add(this.razhet_label);
            this.groupBox_razhet.Controls.Add(this.groupBox_картинка_расчетки);
            this.groupBox_razhet.Controls.Add(this.button_расчет_фото_доб);
            this.groupBox_razhet.Controls.Add(this.groupBox6);
            this.groupBox_razhet.Controls.Add(this.button_расчет_фото_из_буфера);
            this.groupBox_razhet.Controls.Add(this.groupBox_Расчеты);
            this.groupBox_razhet.Controls.Add(this.label13);
            this.groupBox_razhet.Controls.Add(this.trackBar1);
            this.groupBox_razhet.Controls.Add(this.textBox_P_S);
            this.groupBox_razhet.Controls.Add(this.label16);
            this.groupBox_razhet.Controls.Add(this.dataGridView_муляж);
            this.groupBox_razhet.Controls.Add(this.groupBox7);
            this.groupBox_razhet.Controls.Add(this.dataGridView_расчёт_2);
            this.groupBox_razhet.Controls.Add(this.label_rachetka);
            this.groupBox_razhet.Controls.Add(this.groupBox5);
            this.groupBox_razhet.Controls.Add(this.label_consol_2);
            this.groupBox_razhet.Controls.Add(this.groupBox4);
            this.groupBox_razhet.Controls.Add(this.pictureBox1);
            this.groupBox_razhet.Controls.Add(this.dataGridView_зависимость);
            this.groupBox_razhet.Location = new System.Drawing.Point(1245, 22);
            this.groupBox_razhet.Name = "groupBox_razhet";
            this.groupBox_razhet.Size = new System.Drawing.Size(1358, 750);
            this.groupBox_razhet.TabIndex = 60;
            this.groupBox_razhet.TabStop = false;
            this.groupBox_razhet.Text = "Расчёт";
            this.groupBox_razhet.Visible = false;
            // 
            // groupBox_asq
            // 
            this.groupBox_asq.Controls.Add(this.button_dowload_asq);
            this.groupBox_asq.Controls.Add(this.textBox_mess_asq);
            this.groupBox_asq.Controls.Add(this.dataGridView1);
            this.groupBox_asq.Location = new System.Drawing.Point(1142, 203);
            this.groupBox_asq.Name = "groupBox_asq";
            this.groupBox_asq.Size = new System.Drawing.Size(390, 243);
            this.groupBox_asq.TabIndex = 64;
            this.groupBox_asq.TabStop = false;
            this.groupBox_asq.Text = "Чатик";
            // 
            // button_dowload_asq
            // 
            this.button_dowload_asq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_dowload_asq.BackgroundImage")));
            this.button_dowload_asq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_dowload_asq.Location = new System.Drawing.Point(346, 210);
            this.button_dowload_asq.Name = "button_dowload_asq";
            this.button_dowload_asq.Size = new System.Drawing.Size(41, 32);
            this.button_dowload_asq.TabIndex = 6;
            this.button_dowload_asq.UseVisualStyleBackColor = true;
            this.button_dowload_asq.Click += new System.EventHandler(this.button_dowload_asq_Click);
            // 
            // textBox_mess_asq
            // 
            this.textBox_mess_asq.Location = new System.Drawing.Point(6, 215);
            this.textBox_mess_asq.Name = "textBox_mess_asq";
            this.textBox_mess_asq.Size = new System.Drawing.Size(334, 20);
            this.textBox_mess_asq.TabIndex = 8;
            this.textBox_mess_asq.TextChanged += new System.EventHandler(this.textBox_mess_asq_TextChanged);
            this.textBox_mess_asq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mess_asq_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.дата,
            this.Имя,
            this.Сообщение});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(390, 195);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // дата
            // 
            this.дата.HeaderText = "Дата";
            this.дата.Name = "дата";
            this.дата.ReadOnly = true;
            this.дата.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.дата.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.дата.Width = 65;
            // 
            // Имя
            // 
            this.Имя.HeaderText = "Ник";
            this.Имя.Name = "Имя";
            this.Имя.ReadOnly = true;
            this.Имя.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Сообщение
            // 
            this.Сообщение.HeaderText = "Сообщение";
            this.Сообщение.Name = "Сообщение";
            this.Сообщение.ReadOnly = true;
            this.Сообщение.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Сообщение.Width = 200;
            // 
            // button_asq
            // 
            this.button_asq.BackColor = System.Drawing.Color.PeachPuff;
            this.button_asq.ForeColor = System.Drawing.Color.PeachPuff;
            this.button_asq.Location = new System.Drawing.Point(1127, 208);
            this.button_asq.Name = "button_asq";
            this.button_asq.Size = new System.Drawing.Size(16, 84);
            this.button_asq.TabIndex = 63;
            this.button_asq.UseVisualStyleBackColor = false;
            this.button_asq.Click += new System.EventHandler(this.button_asq_Click);
            // 
            // pictureBox_Raz
            // 
            this.pictureBox_Raz.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Raz.Image")));
            this.pictureBox_Raz.Location = new System.Drawing.Point(518, 11);
            this.pictureBox_Raz.Name = "pictureBox_Raz";
            this.pictureBox_Raz.Size = new System.Drawing.Size(122, 112);
            this.pictureBox_Raz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Raz.TabIndex = 60;
            this.pictureBox_Raz.TabStop = false;
            this.pictureBox_Raz.Click += new System.EventHandler(this.pictureBox_Raz_Click);
            this.pictureBox_Raz.DoubleClick += new System.EventHandler(this.pictureBox_Raz_DoubleClick);
            // 
            // razhet_label
            // 
            this.razhet_label.AutoSize = true;
            this.razhet_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.razhet_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.razhet_label.ForeColor = System.Drawing.Color.Red;
            this.razhet_label.Location = new System.Drawing.Point(135, 10);
            this.razhet_label.Name = "razhet_label";
            this.razhet_label.Size = new System.Drawing.Size(113, 15);
            this.razhet_label.TabIndex = 33;
            this.razhet_label.Text = "Требуется расчёт!";
            this.razhet_label.Visible = false;
            this.razhet_label.VisibleChanged += new System.EventHandler(this.razhet_label_VisibleChanged);
            // 
            // groupBox_картинка_расчетки
            // 
            this.groupBox_картинка_расчетки.Controls.Add(this.button_расчет_фото_удалить);
            this.groupBox_картинка_расчетки.Controls.Add(this.button_расчет_фото_в_буфер);
            this.groupBox_картинка_расчетки.Controls.Add(this.button_расчет_фото_сохранить);
            this.groupBox_картинка_расчетки.Location = new System.Drawing.Point(644, 7);
            this.groupBox_картинка_расчетки.Name = "groupBox_картинка_расчетки";
            this.groupBox_картинка_расчетки.Size = new System.Drawing.Size(30, 94);
            this.groupBox_картинка_расчетки.TabIndex = 58;
            this.groupBox_картинка_расчетки.TabStop = false;
            // 
            // button_расчет_фото_удалить
            // 
            this.button_расчет_фото_удалить.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_расчет_фото_удалить.BackgroundImage")));
            this.button_расчет_фото_удалить.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_расчет_фото_удалить.Location = new System.Drawing.Point(1, 64);
            this.button_расчет_фото_удалить.Name = "button_расчет_фото_удалить";
            this.button_расчет_фото_удалить.Size = new System.Drawing.Size(28, 28);
            this.button_расчет_фото_удалить.TabIndex = 64;
            this.button_расчет_фото_удалить.UseVisualStyleBackColor = true;
            this.button_расчет_фото_удалить.Click += new System.EventHandler(this.button_расчет_фото_удалить_Click);
            // 
            // button_расчет_фото_в_буфер
            // 
            this.button_расчет_фото_в_буфер.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_расчет_фото_в_буфер.BackgroundImage")));
            this.button_расчет_фото_в_буфер.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_расчет_фото_в_буфер.Location = new System.Drawing.Point(1, 35);
            this.button_расчет_фото_в_буфер.Name = "button_расчет_фото_в_буфер";
            this.button_расчет_фото_в_буфер.Size = new System.Drawing.Size(28, 28);
            this.button_расчет_фото_в_буфер.TabIndex = 63;
            this.button_расчет_фото_в_буфер.UseVisualStyleBackColor = true;
            this.button_расчет_фото_в_буфер.Click += new System.EventHandler(this.button_расчет_фото_в_буфер_Click);
            // 
            // button_расчет_фото_сохранить
            // 
            this.button_расчет_фото_сохранить.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_расчет_фото_сохранить.BackgroundImage")));
            this.button_расчет_фото_сохранить.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_расчет_фото_сохранить.Location = new System.Drawing.Point(1, 7);
            this.button_расчет_фото_сохранить.Name = "button_расчет_фото_сохранить";
            this.button_расчет_фото_сохранить.Size = new System.Drawing.Size(28, 28);
            this.button_расчет_фото_сохранить.TabIndex = 61;
            this.button_расчет_фото_сохранить.UseVisualStyleBackColor = true;
            this.button_расчет_фото_сохранить.Click += new System.EventHandler(this.button_расчет_фото_сохранить_Click);
            // 
            // button_расчет_фото_доб
            // 
            this.button_расчет_фото_доб.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_расчет_фото_доб.BackgroundImage")));
            this.button_расчет_фото_доб.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_расчет_фото_доб.Location = new System.Drawing.Point(677, 14);
            this.button_расчет_фото_доб.Name = "button_расчет_фото_доб";
            this.button_расчет_фото_доб.Size = new System.Drawing.Size(28, 28);
            this.button_расчет_фото_доб.TabIndex = 2;
            this.button_расчет_фото_доб.UseVisualStyleBackColor = true;
            this.button_расчет_фото_доб.Click += new System.EventHandler(this.button_расчет_фото_доб_Click);
            // 
            // button_расчет_фото_из_буфера
            // 
            this.button_расчет_фото_из_буфера.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_расчет_фото_из_буфера.BackgroundImage")));
            this.button_расчет_фото_из_буфера.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_расчет_фото_из_буфера.Location = new System.Drawing.Point(677, 42);
            this.button_расчет_фото_из_буфера.Name = "button_расчет_фото_из_буфера";
            this.button_расчет_фото_из_буфера.Size = new System.Drawing.Size(28, 28);
            this.button_расчет_фото_из_буфера.TabIndex = 62;
            this.button_расчет_фото_из_буфера.UseVisualStyleBackColor = true;
            this.button_расчет_фото_из_буфера.Click += new System.EventHandler(this.button_расчет_фото_из_буфера_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // button_создать_шаблон
            // 
            this.button_создать_шаблон.Location = new System.Drawing.Point(1214, 201);
            this.button_создать_шаблон.Name = "button_создать_шаблон";
            this.button_создать_шаблон.Size = new System.Drawing.Size(28, 23);
            this.button_создать_шаблон.TabIndex = 61;
            this.button_создать_шаблон.UseVisualStyleBackColor = true;
            this.button_создать_шаблон.Visible = false;
            this.button_создать_шаблон.Click += new System.EventHandler(this.button_создать_шаблон_Click);
            // 
            // timer_labe_добавленна
            // 
            this.timer_labe_добавленна.Interval = 600;
            this.timer_labe_добавленна.Tick += new System.EventHandler(this.timer_labe_добавленна_Tick);
            // 
            // button_догрузить_шаблон
            // 
            this.button_догрузить_шаблон.Location = new System.Drawing.Point(1214, 230);
            this.button_догрузить_шаблон.Name = "button_догрузить_шаблон";
            this.button_догрузить_шаблон.Size = new System.Drawing.Size(28, 23);
            this.button_догрузить_шаблон.TabIndex = 62;
            this.button_догрузить_шаблон.UseVisualStyleBackColor = true;
            this.button_догрузить_шаблон.Visible = false;
            this.button_догрузить_шаблон.Click += new System.EventHandler(this.button_догрузить_шаблон_Click);
            // 
            // button_редактировать_шаблон
            // 
            this.button_редактировать_шаблон.Location = new System.Drawing.Point(1214, 259);
            this.button_редактировать_шаблон.Name = "button_редактировать_шаблон";
            this.button_редактировать_шаблон.Size = new System.Drawing.Size(28, 23);
            this.button_редактировать_шаблон.TabIndex = 63;
            this.button_редактировать_шаблон.UseVisualStyleBackColor = true;
            this.button_редактировать_шаблон.Visible = false;
            this.button_редактировать_шаблон.Click += new System.EventHandler(this.button_редактировать_шаблон_Click);
            // 
            // timer_dual_mouse
            // 
            this.timer_dual_mouse.Tick += new System.EventHandler(this.timer_dual_mouse_Tick);
            // 
            // timerlogo1
            // 
            this.timerlogo1.Interval = 5300;
            this.timerlogo1.Tick += new System.EventHandler(this.timerlogo1_Tick);
            // 
            // timerlogo2
            // 
            this.timerlogo2.Interval = 20;
            this.timerlogo2.Tick += new System.EventHandler(this.timerlogo2_Tick);
            // 
            // timer_save_new_praise
            // 
            this.timer_save_new_praise.Tick += new System.EventHandler(this.timer_save_new_praise_Tick);
            // 
            // timer_auto_update
            // 
            this.timer_auto_update.Interval = 1000;
            this.timer_auto_update.Tick += new System.EventHandler(this.timer_auto_update_Tick);
            // 
            // timer_chat
            // 
            this.timer_chat.Enabled = true;
            this.timer_chat.Interval = 1000;
            this.timer_chat.Tick += new System.EventHandler(this.timer_chat_Tick);
            // 
            // groupBox_url_praise
            // 
            this.groupBox_url_praise.Controls.Add(this.button8);
            this.groupBox_url_praise.Controls.Add(this.button6);
            this.groupBox_url_praise.Controls.Add(this.button_return_ftp_praise);
            this.groupBox_url_praise.Controls.Add(this.button_upload_praise_ftp);
            this.groupBox_url_praise.Controls.Add(this.progressBar1);
            this.groupBox_url_praise.Controls.Add(this.label_bite);
            this.groupBox_url_praise.Controls.Add(this.button5);
            this.groupBox_url_praise.Controls.Add(this.button_проверить_url_praise);
            this.groupBox_url_praise.Location = new System.Drawing.Point(366, 180);
            this.groupBox_url_praise.Name = "groupBox_url_praise";
            this.groupBox_url_praise.Size = new System.Drawing.Size(127, 118);
            this.groupBox_url_praise.TabIndex = 64;
            this.groupBox_url_praise.TabStop = false;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.button8.Location = new System.Drawing.Point(107, 48);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(18, 20);
            this.button8.TabIndex = 57;
            this.button8.Text = "i";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.button6.Location = new System.Drawing.Point(107, 69);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(18, 20);
            this.button6.TabIndex = 56;
            this.button6.Text = "i";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button_return_ftp_praise
            // 
            this.button_return_ftp_praise.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.button_return_ftp_praise.Location = new System.Drawing.Point(1, 69);
            this.button_return_ftp_praise.Name = "button_return_ftp_praise";
            this.button_return_ftp_praise.Size = new System.Drawing.Size(107, 20);
            this.button_return_ftp_praise.TabIndex = 55;
            this.button_return_ftp_praise.Text = "Восстановить прайс";
            this.button_return_ftp_praise.UseVisualStyleBackColor = true;
            this.button_return_ftp_praise.Click += new System.EventHandler(this.button_return_ftp_praise_Click);
            // 
            // button_upload_praise_ftp
            // 
            this.button_upload_praise_ftp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.button_upload_praise_ftp.Location = new System.Drawing.Point(1, 48);
            this.button_upload_praise_ftp.Name = "button_upload_praise_ftp";
            this.button_upload_praise_ftp.Size = new System.Drawing.Size(107, 20);
            this.button_upload_praise_ftp.TabIndex = 54;
            this.button_upload_praise_ftp.Text = "Загрузить на сайт прайс";
            this.button_upload_praise_ftp.UseVisualStyleBackColor = true;
            this.button_upload_praise_ftp.Click += new System.EventHandler(this.button_upload_praise_ftp_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 90);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(120, 10);
            this.progressBar1.TabIndex = 52;
            this.progressBar1.Visible = false;
            // 
            // label_bite
            // 
            this.label_bite.AutoSize = true;
            this.label_bite.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.label_bite.Location = new System.Drawing.Point(3, 103);
            this.label_bite.Name = "label_bite";
            this.label_bite.Size = new System.Drawing.Size(44, 12);
            this.label_bite.TabIndex = 51;
            this.label_bite.Text = "label_bite";
            this.label_bite.Visible = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.button5.Location = new System.Drawing.Point(1, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 20);
            this.button5.TabIndex = 50;
            this.button5.Text = "Скачать с сайта прайс";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button_проверить_url_praise
            // 
            this.button_проверить_url_praise.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.button_проверить_url_praise.Location = new System.Drawing.Point(1, 6);
            this.button_проверить_url_praise.Name = "button_проверить_url_praise";
            this.button_проверить_url_praise.Size = new System.Drawing.Size(124, 20);
            this.button_проверить_url_praise.TabIndex = 49;
            this.button_проверить_url_praise.Text = "Данные о прайсе";
            this.button_проверить_url_praise.UseVisualStyleBackColor = true;
            this.button_проверить_url_praise.Click += new System.EventHandler(this.button_проверить_url_praise_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1924, 748);
            this.Controls.Add(this.groupBox_url_praise);
            this.Controls.Add(this.button_редактировать_шаблон);
            this.Controls.Add(this.button_догрузить_шаблон);
            this.Controls.Add(this.button_создать_шаблон);
            this.Controls.Add(this.groupBox_razhet);
            this.Controls.Add(this.groupBox_baza);
            this.Controls.Add(this.button_Baza_RACHET);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "Form1";
            this.Text = "Прайс Дахмиры";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.данные)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_зависимость)).EndInit();
            this.contextMenuStripрасчетка.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_расчёт_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_муляж)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingNavigator)).EndInit();
            this.tableBindingNavigator.ResumeLayout(false);
            this.tableBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.фотографияPictureBox)).EndInit();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_new_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox_Расчеты.ResumeLayout(false);
            this.groupBox_Расчеты.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox_baza.ResumeLayout(false);
            this.groupBox_baza.PerformLayout();
            this.groupBox_поиск.ResumeLayout(false);
            this.groupBox_поиск.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_no_image)).EndInit();
            this.groupBox_добавить.ResumeLayout(false);
            this.groupBox_добавить.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_no_image_добавить_в_прайс)).EndInit();
            this.groupBox_razhet.ResumeLayout(false);
            this.groupBox_razhet.PerformLayout();
            this.groupBox_asq.ResumeLayout(false);
            this.groupBox_asq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Raz)).EndInit();
            this.groupBox_картинка_расчетки.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_url_praise.ResumeLayout(false);
            this.groupBox_url_praise.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private данные данные;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private данныеTableAdapters.TableTableAdapter tableTableAdapter;
        private данныеTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tableBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tableBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox номерTextBox;
        private System.Windows.Forms.TextBox производительTextBox;
        private System.Windows.Forms.TextBox наименованиеTextBox;
        private System.Windows.Forms.TextBox артикулTextBox;
        private System.Windows.Forms.TextBox ценаTextBox;
        private System.Windows.Forms.PictureBox фотографияPictureBox;
        private System.Windows.Forms.Button button_загрузить_изображение;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_скриншот;
        private System.Windows.Forms.Button button_сохр_изобр_в_фаил;
        private System.Windows.Forms.Label label_consol;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button button_добавить_значение_в_табл;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox_new_артикул;
        private System.Windows.Forms.TextBox textBox_new_наименование;
        private System.Windows.Forms.TextBox textBox_new_производитель;
        private System.Windows.Forms.Button button_new_foto;
        private System.Windows.Forms.Button button_new_foto_down;
        private System.Windows.Forms.PictureBox pictureBox_new_image;
        private System.Windows.Forms.ComboBox comboBox1_поиск;
        private System.Windows.Forms.ComboBox comboBox_наименование_поиск_по_базе;
        private System.Windows.Forms.ComboBox comboBox_артикул_поиск_по_базе;
        private System.Windows.Forms.ComboBox comboBox_цена_поиск_по_базе;
        private System.Windows.Forms.Button button_поиск_по_баз_доб;
        private System.Windows.Forms.TextBox textBox_new_stolbeth;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button button_new_razdel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_consol_2;
        private System.Windows.Forms.Button button_поиск_по_баз_замен;
        private System.Windows.Forms.Button button_поиск_по_баз_под;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button_new_razdel_vmesto;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button button_поиск_копий_в_базе;
        private System.Windows.Forms.GroupBox groupBox_Расчеты;
        private System.Windows.Forms.Button button_взять_актуальные_цены_с_базы;
        private System.Windows.Forms.Button button_perenos_obratno;
        private System.Windows.Forms.Button button_ctroky_v_bazy;
        private System.Windows.Forms.Button button_new_ophins;
        private System.Windows.Forms.Button button_save_to_pdf2;
        private System.Windows.Forms.Button button_save_to_pdf3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_P_S;
        private System.Windows.Forms.ToolStripButton toolStripButton_del_row_strip;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripрасчетка;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemрассчёткакопировать;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemрасчткавставить;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйРасчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьРасчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРасчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРасчетВPDFБезЦенToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРасчетВPDFСЦенамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьПрайсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьПрайсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перенестиВыделеннуюСтрокуИзРасчеткиВКонецПрайсаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перенестиВсеДанныеИзРасчеткиВКонецПрайсаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискОдинаковыхАртикуловВПрайсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаИзExcelФайлаСДаннымиВРасчетДляПереносаВПрайсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаПоПрайсуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаПоРасчетуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаПоТаблицеЗависимостиToolStripMenuItem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_rachetka;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_del_zavisim;
        private System.Windows.Forms.Button button_new_zavisim;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button_del_zavis;
        private System.Windows.Forms.Button button_del_razhet;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer математика;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column34;
        private System.Windows.Forms.Timer duble_art_art;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьБазуЗаногоБезСохраненийToolStripMenuItem;
        private System.Windows.Forms.Button button_del_razhet_end;
        private System.Windows.Forms.Button button_расчитать;
        private System.Windows.Forms.Button button_Calk;
        private System.Windows.Forms.Button button_Baza_RACHET;
        private System.Windows.Forms.GroupBox groupBox_baza;
        private System.Windows.Forms.GroupBox groupBox_razhet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem получитьЗаготовкуExcelФайлаСФотографиямиДляПереносаToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox_Raz;
        private System.Windows.Forms.ToolStripMenuItem радиоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выключитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьВолнуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найтиДрстанцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator уцуToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox_елупни;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolStripMenuItem справкаПоПрайсуToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox_добавить;
        private System.Windows.Forms.GroupBox groupBox_поиск;
        private System.Windows.Forms.Button button_добавить;
        private System.Windows.Forms.Button button_поиск;
        private System.Windows.Forms.Timer timer_labe_добавленна;
        private System.Windows.Forms.Label label_добавленно;
        private System.Windows.Forms.ToolStripMenuItem вРазработкеСоздатьШаблонToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        public System.Windows.Forms.Button button_создать_шаблон;
        public System.Windows.Forms.Button button_догрузить_шаблон;
        public System.Windows.Forms.Button button_редактировать_шаблон;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_расчет_фото_в_буфер;
        private System.Windows.Forms.Button button_расчет_фото_из_буфера;
        private System.Windows.Forms.Button button_расчет_фото_сохранить;
        private System.Windows.Forms.Button button_расчет_фото_доб;
        private System.Windows.Forms.GroupBox groupBox_картинка_расчетки;
        private System.Windows.Forms.Button button_расчет_фото_удалить;
        private System.Windows.Forms.Button button_удалить_изобр_в_фаил;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox_no_image;
        private System.Windows.Forms.PictureBox pictureBox_no_image_добавить_в_прайс;
        private System.Windows.Forms.Button button_del_new_image;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel2;
        private System.Windows.Forms.ToolStripMenuItem получитьИзПрайсаОпределенногоПроизводителяToolStripMenuItem;
        private System.Windows.Forms.Timer timer_dual_mouse;
        private ToolStripMenuItem сделатьКопиюПрайсаВToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private Timer timer_reset_pass_save;
        private Timer timerlogo1;
        private Timer timerlogo2;
        private Timer timer_save_new_praise;
        private DataGridViewTextBoxColumn номерDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn производительDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn артикулDataGridViewTextBoxColumn;
        private DataGridViewImageColumn фотографияDataGridViewImageColumn;
        private DataGridViewTextBoxColumn ценаDataGridViewTextBoxColumn;
        private Button button_copy;
        private Button button_pase;
        private Label razhet_label;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewTextBoxColumn Column33;
        private DataGridViewTextBoxColumn Column35;
        private DataGridViewTextBoxColumn Примечание;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Column36;
        private Button button_сохранить_расчёт_быстро;
        private ToolStripMenuItem отладочнаяКнопкаToolStripMenuItem;
        private ToolStripMenuItem обновитьЦенуСФайлаExcelToolStripMenuItem;
        private ToolStripMenuItem натройкиДляОбновлениеЦенИзExcelToolStripMenuItem;
        private ToolStripButton toolStripButton2;
        private ToolStripMenuItem пробник2ToolStripMenuItem;
        private ToolStripMenuItem изменитьНаЦенуПроизводителяToolStripMenuItem;
        private Button button_new_ophins2;
        private Label номерLabel;
        private Label производительLabel;
        private Label наименованиеLabel;
        private Label артикулLabel;
        private Label ценаLabel;
        private Label label7;
        private Label label12;
        private Label label14;
        private Label label4;
        private Label label3;
        private Button button7;
        private ToolStripMenuItem toolStripMenuItem1;
        private Timer timer_auto_update;
        private ToolStripMenuItem настройкиToolStripMenuItem1;
        private Button button_no_image_for_excel;
        private ToolStripButton toolStripButton3;
        private Button button_asq;
        private GroupBox groupBox_asq;
        private Button button_dowload_asq;
        private TextBox textBox_mess_asq;
        private Timer timer_chat;
        private DataGridViewTextBoxColumn дата;
        private DataGridViewTextBoxColumn Имя;
        private DataGridViewTextBoxColumn Сообщение;
        private ToolStripButton toolStripButton4;
        private GroupBox groupBox_url_praise;
        private Button button_проверить_url_praise;
        private Label label11;
        private ProgressBar progressBar1;
        private Label label_bite;
        private Button button5;
        private Button button_return_ftp_praise;
        private Button button_upload_praise_ftp;
        private Button button6;
        private Label label_info_ftp;
        private ToolStripMenuItem скачатьССайтаПрайсToolStripMenuItem;
        private ToolStripMenuItem данныеОПрайсеНаСайтеToolStripMenuItem;
        private Button button8;
        private DoubleBufferedDataGridView tableDataGridView;
        private DoubleBufferedDataGridView dataGridView_зависимость;
        private DoubleBufferedDataGridView dataGridView_расчёт_2;
        private DoubleBufferedDataGridView dataGridView_муляж;
        private DoubleBufferedDataGridView dataGridView1;
    }
}

