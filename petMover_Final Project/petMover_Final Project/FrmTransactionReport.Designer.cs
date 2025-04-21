
namespace petMover_Final_Project
{
    partial class FrmTransactionReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            this.chbAllBranch = new System.Windows.Forms.CheckBox();
            this.chbAllPeriod = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.lblNotFound = new System.Windows.Forms.Label();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.lblCol3Row4 = new System.Windows.Forms.Label();
            this.txt7 = new System.Windows.Forms.Label();
            this.txt8 = new System.Windows.Forms.Label();
            this.txt9 = new System.Windows.Forms.Label();
            this.lblCol2Row4 = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.Label();
            this.txt5 = new System.Windows.Forms.Label();
            this.txt6 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.Label();
            this.lblCol3Row2 = new System.Windows.Forms.Label();
            this.lblCol2Row1 = new System.Windows.Forms.Label();
            this.lblCol1Row1 = new System.Windows.Forms.Label();
            this.lblCol3Row3 = new System.Windows.Forms.Label();
            this.lblCol3Row1 = new System.Windows.Forms.Label();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblCol2Row3 = new System.Windows.Forms.Label();
            this.lblCol2Row2 = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblCol1Row4 = new System.Windows.Forms.Label();
            this.lblCol1Row3 = new System.Windows.Forms.Label();
            this.lblCol1Row2 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rdbDay = new petMover_Final_Project.CustomRadioButton();
            this.rdbMonth = new petMover_Final_Project.CustomRadioButton();
            this.rdbYear = new petMover_Final_Project.CustomRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pnlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Plum;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat SemiBold", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.Location = new System.Drawing.Point(36, 380);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Montserrat SemiBold", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 62;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(980, 282);
            this.dgvData.TabIndex = 27;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Cocogoose", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(980, 66);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Transaction Report";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGenerate.BackColor = System.Drawing.Color.Coral;
            this.btnGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Cocogoose", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Black;
            this.btnGenerate.Location = new System.Drawing.Point(723, 26);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(223, 80);
            this.btnGenerate.TabIndex = 28;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cocogoose", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 66);
            this.label1.TabIndex = 5;
            this.label1.Text = "Branch:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.Thistle;
            this.pnlSearch.Controls.Add(this.lblDesc);
            this.pnlSearch.Controls.Add(this.rdbDay);
            this.pnlSearch.Controls.Add(this.rdbMonth);
            this.pnlSearch.Controls.Add(this.rdbYear);
            this.pnlSearch.Controls.Add(this.chbAllBranch);
            this.pnlSearch.Controls.Add(this.chbAllPeriod);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.btnGenerate);
            this.pnlSearch.Controls.Add(this.dtpDate);
            this.pnlSearch.Controls.Add(this.cbBranch);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Location = new System.Drawing.Point(36, 127);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(980, 225);
            this.pnlSearch.TabIndex = 29;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDesc.BackColor = System.Drawing.Color.Thistle;
            this.lblDesc.Font = new System.Drawing.Font("Montserrat", 9F);
            this.lblDesc.ForeColor = System.Drawing.Color.Black;
            this.lblDesc.Location = new System.Drawing.Point(558, 131);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(388, 77);
            this.lblDesc.TabIndex = 42;
            this.lblDesc.Text = "Generating report for month: December 2023";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbAllBranch
            // 
            this.chbAllBranch.AutoSize = true;
            this.chbAllBranch.Font = new System.Drawing.Font("Montserrat Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllBranch.Location = new System.Drawing.Point(558, 37);
            this.chbAllBranch.Name = "chbAllBranch";
            this.chbAllBranch.Size = new System.Drawing.Size(129, 26);
            this.chbAllBranch.TabIndex = 30;
            this.chbAllBranch.Text = "All Branch";
            this.chbAllBranch.UseVisualStyleBackColor = true;
            this.chbAllBranch.CheckedChanged += new System.EventHandler(this.chbAllBranch_CheckedChanged);
            // 
            // chbAllPeriod
            // 
            this.chbAllPeriod.AutoSize = true;
            this.chbAllPeriod.Font = new System.Drawing.Font("Montserrat Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllPeriod.Location = new System.Drawing.Point(558, 97);
            this.chbAllPeriod.Name = "chbAllPeriod";
            this.chbAllPeriod.Size = new System.Drawing.Size(124, 26);
            this.chbAllPeriod.TabIndex = 29;
            this.chbAllPeriod.Text = "All Period";
            this.chbAllPeriod.UseVisualStyleBackColor = true;
            this.chbAllPeriod.CheckedChanged += new System.EventHandler(this.chbAllPeriod_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cocogoose", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 66);
            this.label2.TabIndex = 27;
            this.label2.Text = "Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Montserrat", 10F);
            this.dtpDate.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(142, 86);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(410, 37);
            this.dtpDate.TabIndex = 26;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpLogTime_ValueChanged);
            // 
            // cbBranch
            // 
            this.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranch.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranch.FormattingEnabled = true;
            this.cbBranch.Location = new System.Drawing.Point(142, 26);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(410, 41);
            this.cbBranch.TabIndex = 14;
            this.cbBranch.SelectedIndexChanged += new System.EventHandler(this.cbBranch_SelectedIndexChanged);
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.BackColor = System.Drawing.Color.Plum;
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Location = new System.Drawing.Point(36, 37);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(980, 66);
            this.pnlTitle.TabIndex = 30;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Image = global::petMover_Final_Project.Properties.Resources.exit2;
            this.btnExit.Location = new System.Drawing.Point(933, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(33, 34);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 7;
            this.btnExit.TabStop = false;
            // 
            // lblNotFound
            // 
            this.lblNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotFound.BackColor = System.Drawing.Color.Thistle;
            this.lblNotFound.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotFound.ForeColor = System.Drawing.Color.Black;
            this.lblNotFound.Location = new System.Drawing.Point(141, 418);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(765, 218);
            this.lblNotFound.TabIndex = 31;
            this.lblNotFound.Text = "There are no transactions found at {branchName} on {date}!";
            this.lblNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNotFound.Visible = false;
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.AutoSize = true;
            this.pnlReport.BackColor = System.Drawing.Color.Thistle;
            this.pnlReport.Controls.Add(this.lblCol3Row4);
            this.pnlReport.Controls.Add(this.txt7);
            this.pnlReport.Controls.Add(this.txt8);
            this.pnlReport.Controls.Add(this.txt9);
            this.pnlReport.Controls.Add(this.lblCol2Row4);
            this.pnlReport.Controls.Add(this.txt4);
            this.pnlReport.Controls.Add(this.txt5);
            this.pnlReport.Controls.Add(this.txt6);
            this.pnlReport.Controls.Add(this.txt1);
            this.pnlReport.Controls.Add(this.txt2);
            this.pnlReport.Controls.Add(this.txt3);
            this.pnlReport.Controls.Add(this.lblCol3Row2);
            this.pnlReport.Controls.Add(this.lblCol2Row1);
            this.pnlReport.Controls.Add(this.lblCol1Row1);
            this.pnlReport.Controls.Add(this.lblCol3Row3);
            this.pnlReport.Controls.Add(this.lblCol3Row1);
            this.pnlReport.Controls.Add(this.lblTitle3);
            this.pnlReport.Controls.Add(this.lblCol2Row3);
            this.pnlReport.Controls.Add(this.lblCol2Row2);
            this.pnlReport.Controls.Add(this.lblTitle2);
            this.pnlReport.Controls.Add(this.lblCol1Row4);
            this.pnlReport.Controls.Add(this.lblCol1Row3);
            this.pnlReport.Controls.Add(this.lblCol1Row2);
            this.pnlReport.Controls.Add(this.lblTitle1);
            this.pnlReport.Controls.Add(this.lblReportTitle);
            this.pnlReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnlReport.Location = new System.Drawing.Point(36, 380);
            this.pnlReport.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(980, 394);
            this.pnlReport.TabIndex = 41;
            this.pnlReport.Visible = false;
            // 
            // lblCol3Row4
            // 
            this.lblCol3Row4.Font = new System.Drawing.Font("Montserrat", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol3Row4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol3Row4.Location = new System.Drawing.Point(667, 339);
            this.lblCol3Row4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol3Row4.Name = "lblCol3Row4";
            this.lblCol3Row4.Size = new System.Drawing.Size(279, 46);
            this.lblCol3Row4.TabIndex = 52;
            this.lblCol3Row4.Text = "RANK : #1";
            this.lblCol3Row4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCol3Row4.TextChanged += new System.EventHandler(this.lblCol3Row4_TextChanged);
            // 
            // txt7
            // 
            this.txt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt7.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt7.Location = new System.Drawing.Point(672, 129);
            this.txt7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt7.Name = "txt7";
            this.txt7.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt7.Size = new System.Drawing.Size(274, 42);
            this.txt7.TabIndex = 51;
            this.txt7.Text = "Cat";
            this.txt7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt8
            // 
            this.txt8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt8.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt8.Location = new System.Drawing.Point(672, 207);
            this.txt8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt8.Name = "txt8";
            this.txt8.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt8.Size = new System.Drawing.Size(274, 42);
            this.txt8.TabIndex = 50;
            this.txt8.Text = "Express";
            this.txt8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt9
            // 
            this.txt9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt9.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt9.Location = new System.Drawing.Point(672, 285);
            this.txt9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt9.Name = "txt9";
            this.txt9.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt9.Size = new System.Drawing.Size(274, 42);
            this.txt9.TabIndex = 49;
            this.txt9.Text = "Cat Meal";
            this.txt9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol2Row4
            // 
            this.lblCol2Row4.Font = new System.Drawing.Font("Montserrat", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol2Row4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol2Row4.Location = new System.Drawing.Point(347, 339);
            this.lblCol2Row4.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCol2Row4.Name = "lblCol2Row4";
            this.lblCol2Row4.Size = new System.Drawing.Size(292, 46);
            this.lblCol2Row4.TabIndex = 48;
            this.lblCol2Row4.Text = "TOTAL : 192";
            this.lblCol2Row4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCol2Row4.TextChanged += new System.EventHandler(this.lblCol2Row4_TextChanged);
            // 
            // txt4
            // 
            this.txt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt4.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt4.Location = new System.Drawing.Point(352, 129);
            this.txt4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt4.Name = "txt4";
            this.txt4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt4.Size = new System.Drawing.Size(287, 42);
            this.txt4.TabIndex = 47;
            this.txt4.Text = "9";
            this.txt4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt5
            // 
            this.txt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt5.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt5.Location = new System.Drawing.Point(352, 207);
            this.txt5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt5.Name = "txt5";
            this.txt5.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt5.Size = new System.Drawing.Size(287, 42);
            this.txt5.TabIndex = 46;
            this.txt5.Text = "340";
            this.txt5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt6
            // 
            this.txt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt6.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt6.Location = new System.Drawing.Point(352, 285);
            this.txt6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt6.Name = "txt6";
            this.txt6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt6.Size = new System.Drawing.Size(287, 42);
            this.txt6.TabIndex = 45;
            this.txt6.Text = "1210";
            this.txt6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt1
            // 
            this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt1.Location = new System.Drawing.Point(31, 129);
            this.txt1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt1.Name = "txt1";
            this.txt1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt1.Size = new System.Drawing.Size(287, 42);
            this.txt1.TabIndex = 44;
            this.txt1.Text = "Rp435.000,00";
            this.txt1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt2
            // 
            this.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt2.Location = new System.Drawing.Point(31, 207);
            this.txt2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt2.Name = "txt2";
            this.txt2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt2.Size = new System.Drawing.Size(287, 42);
            this.txt2.TabIndex = 43;
            this.txt2.Text = "Rp435.000,00";
            this.txt2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt3
            // 
            this.txt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt3.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt3.Location = new System.Drawing.Point(31, 285);
            this.txt3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt3.Name = "txt3";
            this.txt3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.txt3.Size = new System.Drawing.Size(287, 42);
            this.txt3.TabIndex = 42;
            this.txt3.Text = "Rp435.000,00";
            this.txt3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol3Row2
            // 
            this.lblCol3Row2.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol3Row2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol3Row2.Location = new System.Drawing.Point(667, 178);
            this.lblCol3Row2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol3Row2.Name = "lblCol3Row2";
            this.lblCol3Row2.Size = new System.Drawing.Size(279, 27);
            this.lblCol3Row2.TabIndex = 41;
            this.lblCol3Row2.Text = "Common Service Type";
            this.lblCol3Row2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol2Row1
            // 
            this.lblCol2Row1.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol2Row1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol2Row1.Location = new System.Drawing.Point(347, 100);
            this.lblCol2Row1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol2Row1.Name = "lblCol2Row1";
            this.lblCol2Row1.Size = new System.Drawing.Size(292, 27);
            this.lblCol2Row1.TabIndex = 39;
            this.lblCol2Row1.Text = "Daily Average:";
            this.lblCol2Row1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol1Row1
            // 
            this.lblCol1Row1.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol1Row1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol1Row1.Location = new System.Drawing.Point(26, 100);
            this.lblCol1Row1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol1Row1.Name = "lblCol1Row1";
            this.lblCol1Row1.Size = new System.Drawing.Size(292, 27);
            this.lblCol1Row1.TabIndex = 38;
            this.lblCol1Row1.Text = "Daily Average:";
            this.lblCol1Row1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol3Row3
            // 
            this.lblCol3Row3.AutoSize = true;
            this.lblCol3Row3.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol3Row3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol3Row3.Location = new System.Drawing.Point(667, 256);
            this.lblCol3Row3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol3Row3.Name = "lblCol3Row3";
            this.lblCol3Row3.Size = new System.Drawing.Size(230, 27);
            this.lblCol3Row3.TabIndex = 37;
            this.lblCol3Row3.Text = "Most Treatment Used";
            this.lblCol3Row3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol3Row1
            // 
            this.lblCol3Row1.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol3Row1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol3Row1.Location = new System.Drawing.Point(667, 100);
            this.lblCol3Row1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol3Row1.Name = "lblCol3Row1";
            this.lblCol3Row1.Size = new System.Drawing.Size(279, 27);
            this.lblCol3Row1.TabIndex = 36;
            this.lblCol3Row1.Text = "Common Pet Types:";
            this.lblCol3Row1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle3
            // 
            this.lblTitle3.Font = new System.Drawing.Font("Montserrat SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitle3.Location = new System.Drawing.Point(667, 64);
            this.lblTitle3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(279, 27);
            this.lblTitle3.TabIndex = 35;
            this.lblTitle3.Text = "Additional Information";
            this.lblTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol2Row3
            // 
            this.lblCol2Row3.AutoSize = true;
            this.lblCol2Row3.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol2Row3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol2Row3.Location = new System.Drawing.Point(347, 256);
            this.lblCol2Row3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol2Row3.Name = "lblCol2Row3";
            this.lblCol2Row3.Size = new System.Drawing.Size(163, 27);
            this.lblCol2Row3.TabIndex = 34;
            this.lblCol2Row3.Text = "Yearly Average:";
            this.lblCol2Row3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol2Row2
            // 
            this.lblCol2Row2.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol2Row2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol2Row2.Location = new System.Drawing.Point(347, 178);
            this.lblCol2Row2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol2Row2.Name = "lblCol2Row2";
            this.lblCol2Row2.Size = new System.Drawing.Size(292, 27);
            this.lblCol2Row2.TabIndex = 33;
            this.lblCol2Row2.Text = "Monthly Average:";
            this.lblCol2Row2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle2
            // 
            this.lblTitle2.Font = new System.Drawing.Font("Montserrat SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitle2.Location = new System.Drawing.Point(347, 64);
            this.lblTitle2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(279, 27);
            this.lblTitle2.TabIndex = 32;
            this.lblTitle2.Text = "Number of Transactions";
            this.lblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol1Row4
            // 
            this.lblCol1Row4.Font = new System.Drawing.Font("Montserrat", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol1Row4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol1Row4.Location = new System.Drawing.Point(26, 339);
            this.lblCol1Row4.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblCol1Row4.Name = "lblCol1Row4";
            this.lblCol1Row4.Size = new System.Drawing.Size(292, 46);
            this.lblCol1Row4.TabIndex = 31;
            this.lblCol1Row4.Text = "TOTAL : Rp1.000.000";
            this.lblCol1Row4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCol1Row4.TextChanged += new System.EventHandler(this.lblCol1Row4_TextChanged);
            // 
            // lblCol1Row3
            // 
            this.lblCol1Row3.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol1Row3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol1Row3.Location = new System.Drawing.Point(26, 256);
            this.lblCol1Row3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol1Row3.Name = "lblCol1Row3";
            this.lblCol1Row3.Size = new System.Drawing.Size(292, 27);
            this.lblCol1Row3.TabIndex = 30;
            this.lblCol1Row3.Text = "Yearly Average:";
            this.lblCol1Row3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCol1Row2
            // 
            this.lblCol1Row2.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol1Row2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCol1Row2.Location = new System.Drawing.Point(26, 178);
            this.lblCol1Row2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol1Row2.Name = "lblCol1Row2";
            this.lblCol1Row2.Size = new System.Drawing.Size(292, 27);
            this.lblCol1Row2.TabIndex = 29;
            this.lblCol1Row2.Text = "Monthly Average:";
            this.lblCol1Row2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle1
            // 
            this.lblTitle1.Font = new System.Drawing.Font("Montserrat SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitle1.Location = new System.Drawing.Point(26, 64);
            this.lblTitle1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(200, 27);
            this.lblTitle1.TabIndex = 28;
            this.lblTitle1.Text = "Revenue Gained";
            this.lblTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblReportTitle.Location = new System.Drawing.Point(24, 6);
            this.lblReportTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(922, 51);
            this.lblReportTitle.TabIndex = 26;
            this.lblReportTitle.Text = "Sales Performance in <branch> on <date>";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Plum;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Cocogoose", 12F);
            this.btnPrint.Location = new System.Drawing.Point(693, 686);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(323, 69);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Text = "Print Report to PDF";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.Coral;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Cocogoose", 12F);
            this.btnClose.Location = new System.Drawing.Point(36, 689);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 69);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdbDay
            // 
            this.rdbDay.AutoSize = true;
            this.rdbDay.CheckedColor = System.Drawing.Color.Coral;
            this.rdbDay.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDay.Location = new System.Drawing.Point(37, 148);
            this.rdbDay.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbDay.Name = "rdbDay";
            this.rdbDay.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbDay.Size = new System.Drawing.Size(99, 37);
            this.rdbDay.TabIndex = 36;
            this.rdbDay.TabStop = true;
            this.rdbDay.Text = "Day";
            this.rdbDay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdbDay.UnCheckedColor = System.Drawing.Color.Black;
            this.rdbDay.UseVisualStyleBackColor = true;
            this.rdbDay.CheckedChanged += new System.EventHandler(this.rdbDay_CheckedChanged);
            // 
            // rdbMonth
            // 
            this.rdbMonth.AutoSize = true;
            this.rdbMonth.CheckedColor = System.Drawing.Color.Coral;
            this.rdbMonth.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMonth.Location = new System.Drawing.Point(224, 148);
            this.rdbMonth.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbMonth.Name = "rdbMonth";
            this.rdbMonth.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbMonth.Size = new System.Drawing.Size(130, 37);
            this.rdbMonth.TabIndex = 35;
            this.rdbMonth.TabStop = true;
            this.rdbMonth.Text = "Month";
            this.rdbMonth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdbMonth.UnCheckedColor = System.Drawing.Color.Black;
            this.rdbMonth.UseVisualStyleBackColor = true;
            this.rdbMonth.CheckedChanged += new System.EventHandler(this.rdbMonth_CheckedChanged);
            // 
            // rdbYear
            // 
            this.rdbYear.AutoSize = true;
            this.rdbYear.CheckedColor = System.Drawing.Color.Coral;
            this.rdbYear.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbYear.Location = new System.Drawing.Point(447, 148);
            this.rdbYear.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbYear.Name = "rdbYear";
            this.rdbYear.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbYear.Size = new System.Drawing.Size(105, 37);
            this.rdbYear.TabIndex = 34;
            this.rdbYear.TabStop = true;
            this.rdbYear.Text = "Year";
            this.rdbYear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdbYear.UnCheckedColor = System.Drawing.Color.Black;
            this.rdbYear.UseVisualStyleBackColor = true;
            this.rdbYear.CheckedChanged += new System.EventHandler(this.rdbYear_CheckedChanged);
            // 
            // FrmTransactionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1053, 887);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.lblNotFound);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlTitle);
            this.Name = "FrmTransactionReport";
            this.Text = "Transaction Report";
            this.Load += new System.EventHandler(this.FrmTransactionReport_Load);
            this.Click += new System.EventHandler(this.FrmTransactionReport_Click);
            this.Resize += new System.EventHandler(this.FrmTransactionReport_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox btnExit;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.ComboBox cbBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbAllPeriod;
        private System.Windows.Forms.CheckBox chbAllBranch;
        private System.Windows.Forms.Label lblNotFound;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Label lblCol3Row4;
        private System.Windows.Forms.Label txt7;
        private System.Windows.Forms.Label txt8;
        private System.Windows.Forms.Label txt9;
        private System.Windows.Forms.Label lblCol2Row4;
        private System.Windows.Forms.Label txt4;
        private System.Windows.Forms.Label txt5;
        private System.Windows.Forms.Label txt6;
        private System.Windows.Forms.Label txt1;
        private System.Windows.Forms.Label txt2;
        private System.Windows.Forms.Label txt3;
        private System.Windows.Forms.Label lblCol3Row2;
        private System.Windows.Forms.Label lblCol2Row1;
        private System.Windows.Forms.Label lblCol1Row1;
        private System.Windows.Forms.Label lblCol3Row3;
        private System.Windows.Forms.Label lblCol3Row1;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Label lblCol2Row3;
        private System.Windows.Forms.Label lblCol2Row2;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblCol1Row4;
        private System.Windows.Forms.Label lblCol1Row3;
        private System.Windows.Forms.Label lblCol1Row2;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblReportTitle;
        private CustomRadioButton rdbYear;
        private CustomRadioButton rdbDay;
        private CustomRadioButton rdbMonth;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}