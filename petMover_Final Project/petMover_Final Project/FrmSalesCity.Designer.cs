
namespace petMover_Final_Project
{
    partial class FrmSalesCity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.lblNotFound = new System.Windows.Forms.Label();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.lblRank = new System.Windows.Forms.Label();
            this.lblCommonPetType = new System.Windows.Forms.Label();
            this.lblCommonServiceType = new System.Windows.Forms.Label();
            this.lblCommonTreatment = new System.Windows.Forms.Label();
            this.lblTotalTransaction = new System.Windows.Forms.Label();
            this.lblTransactionDailyAvg = new System.Windows.Forms.Label();
            this.lblTransactionMonthlyAvg = new System.Windows.Forms.Label();
            this.lblTransactionYearlyAvg = new System.Windows.Forms.Label();
            this.lblRevenueDailyAverage = new System.Windows.Forms.Label();
            this.lblRevenueMonthlyAverage = new System.Windows.Forms.Label();
            this.lblRevenueYearlyAverage = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pnlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.Thistle;
            this.pnlSearch.Controls.Add(this.btnReport);
            this.pnlSearch.Controls.Add(this.cbCity);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Location = new System.Drawing.Point(36, 127);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(980, 117);
            this.pnlSearch.TabIndex = 37;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.BackColor = System.Drawing.Color.Coral;
            this.btnReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Cocogoose", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Location = new System.Drawing.Point(688, 22);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(258, 65);
            this.btnReport.TabIndex = 29;
            this.btnReport.Text = "View Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cbCity
            // 
            this.cbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCity.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(86, 32);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(498, 41);
            this.cbCity.TabIndex = 14;
            this.cbCity.SelectedIndexChanged += new System.EventHandler(this.cbCity_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cocogoose", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 66);
            this.label1.TabIndex = 5;
            this.label1.Text = "City:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblTitle.Text = "Sales Performance per City";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Montserrat SemiBold", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.Location = new System.Drawing.Point(36, 276);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 62;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(980, 391);
            this.dgvData.TabIndex = 36;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
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
            this.pnlTitle.TabIndex = 38;
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblNotFound
            // 
            this.lblNotFound.BackColor = System.Drawing.Color.Thistle;
            this.lblNotFound.Font = new System.Drawing.Font("Montserrat SemiBold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotFound.ForeColor = System.Drawing.Color.Black;
            this.lblNotFound.Location = new System.Drawing.Point(137, 312);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(765, 340);
            this.lblNotFound.TabIndex = 39;
            this.lblNotFound.Text = "There are no transactions found at {branchName} on {date}!";
            this.lblNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNotFound.Visible = false;
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.BackColor = System.Drawing.Color.Thistle;
            this.pnlReport.Controls.Add(this.lblRank);
            this.pnlReport.Controls.Add(this.lblCommonPetType);
            this.pnlReport.Controls.Add(this.lblCommonServiceType);
            this.pnlReport.Controls.Add(this.lblCommonTreatment);
            this.pnlReport.Controls.Add(this.lblTotalTransaction);
            this.pnlReport.Controls.Add(this.lblTransactionDailyAvg);
            this.pnlReport.Controls.Add(this.lblTransactionMonthlyAvg);
            this.pnlReport.Controls.Add(this.lblTransactionYearlyAvg);
            this.pnlReport.Controls.Add(this.lblRevenueDailyAverage);
            this.pnlReport.Controls.Add(this.lblRevenueMonthlyAverage);
            this.pnlReport.Controls.Add(this.lblRevenueYearlyAverage);
            this.pnlReport.Controls.Add(this.label16);
            this.pnlReport.Controls.Add(this.label14);
            this.pnlReport.Controls.Add(this.label13);
            this.pnlReport.Controls.Add(this.label10);
            this.pnlReport.Controls.Add(this.label11);
            this.pnlReport.Controls.Add(this.label12);
            this.pnlReport.Controls.Add(this.label6);
            this.pnlReport.Controls.Add(this.label8);
            this.pnlReport.Controls.Add(this.label9);
            this.pnlReport.Controls.Add(this.lblTotalRevenue);
            this.pnlReport.Controls.Add(this.label4);
            this.pnlReport.Controls.Add(this.label3);
            this.pnlReport.Controls.Add(this.label2);
            this.pnlReport.Controls.Add(this.lblReportTitle);
            this.pnlReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnlReport.Location = new System.Drawing.Point(36, 276);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(980, 394);
            this.pnlReport.TabIndex = 40;
            this.pnlReport.Visible = false;
            // 
            // lblRank
            // 
            this.lblRank.Font = new System.Drawing.Font("Montserrat", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRank.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRank.Location = new System.Drawing.Point(667, 339);
            this.lblRank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(279, 46);
            this.lblRank.TabIndex = 52;
            this.lblRank.Text = "RANK : #1";
            this.lblRank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCommonPetType
            // 
            this.lblCommonPetType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCommonPetType.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommonPetType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCommonPetType.Location = new System.Drawing.Point(672, 129);
            this.lblCommonPetType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommonPetType.Name = "lblCommonPetType";
            this.lblCommonPetType.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCommonPetType.Size = new System.Drawing.Size(274, 42);
            this.lblCommonPetType.TabIndex = 51;
            this.lblCommonPetType.Text = "Cat";
            this.lblCommonPetType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCommonServiceType
            // 
            this.lblCommonServiceType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCommonServiceType.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommonServiceType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCommonServiceType.Location = new System.Drawing.Point(672, 207);
            this.lblCommonServiceType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommonServiceType.Name = "lblCommonServiceType";
            this.lblCommonServiceType.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCommonServiceType.Size = new System.Drawing.Size(274, 42);
            this.lblCommonServiceType.TabIndex = 50;
            this.lblCommonServiceType.Text = "Express";
            this.lblCommonServiceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCommonTreatment
            // 
            this.lblCommonTreatment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCommonTreatment.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommonTreatment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCommonTreatment.Location = new System.Drawing.Point(672, 285);
            this.lblCommonTreatment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommonTreatment.Name = "lblCommonTreatment";
            this.lblCommonTreatment.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCommonTreatment.Size = new System.Drawing.Size(274, 42);
            this.lblCommonTreatment.TabIndex = 49;
            this.lblCommonTreatment.Text = "Cat Meal";
            this.lblCommonTreatment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalTransaction
            // 
            this.lblTotalTransaction.Font = new System.Drawing.Font("Montserrat", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTransaction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalTransaction.Location = new System.Drawing.Point(347, 339);
            this.lblTotalTransaction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalTransaction.Name = "lblTotalTransaction";
            this.lblTotalTransaction.Size = new System.Drawing.Size(292, 46);
            this.lblTotalTransaction.TabIndex = 48;
            this.lblTotalTransaction.Text = "TOTAL : 192";
            this.lblTotalTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalTransaction.TextChanged += new System.EventHandler(this.lblTotalTransaction_TextChanged);
            // 
            // lblTransactionDailyAvg
            // 
            this.lblTransactionDailyAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionDailyAvg.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionDailyAvg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTransactionDailyAvg.Location = new System.Drawing.Point(352, 129);
            this.lblTransactionDailyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionDailyAvg.Name = "lblTransactionDailyAvg";
            this.lblTransactionDailyAvg.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblTransactionDailyAvg.Size = new System.Drawing.Size(287, 42);
            this.lblTransactionDailyAvg.TabIndex = 47;
            this.lblTransactionDailyAvg.Text = "9";
            this.lblTransactionDailyAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTransactionMonthlyAvg
            // 
            this.lblTransactionMonthlyAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionMonthlyAvg.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionMonthlyAvg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTransactionMonthlyAvg.Location = new System.Drawing.Point(352, 207);
            this.lblTransactionMonthlyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionMonthlyAvg.Name = "lblTransactionMonthlyAvg";
            this.lblTransactionMonthlyAvg.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblTransactionMonthlyAvg.Size = new System.Drawing.Size(287, 42);
            this.lblTransactionMonthlyAvg.TabIndex = 46;
            this.lblTransactionMonthlyAvg.Text = "340";
            this.lblTransactionMonthlyAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTransactionYearlyAvg
            // 
            this.lblTransactionYearlyAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTransactionYearlyAvg.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionYearlyAvg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTransactionYearlyAvg.Location = new System.Drawing.Point(352, 285);
            this.lblTransactionYearlyAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionYearlyAvg.Name = "lblTransactionYearlyAvg";
            this.lblTransactionYearlyAvg.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblTransactionYearlyAvg.Size = new System.Drawing.Size(287, 42);
            this.lblTransactionYearlyAvg.TabIndex = 45;
            this.lblTransactionYearlyAvg.Text = "1210";
            this.lblTransactionYearlyAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevenueDailyAverage
            // 
            this.lblRevenueDailyAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRevenueDailyAverage.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueDailyAverage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRevenueDailyAverage.Location = new System.Drawing.Point(31, 129);
            this.lblRevenueDailyAverage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueDailyAverage.Name = "lblRevenueDailyAverage";
            this.lblRevenueDailyAverage.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblRevenueDailyAverage.Size = new System.Drawing.Size(287, 42);
            this.lblRevenueDailyAverage.TabIndex = 44;
            this.lblRevenueDailyAverage.Text = "Rp435.000,00";
            this.lblRevenueDailyAverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevenueMonthlyAverage
            // 
            this.lblRevenueMonthlyAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRevenueMonthlyAverage.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueMonthlyAverage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRevenueMonthlyAverage.Location = new System.Drawing.Point(31, 207);
            this.lblRevenueMonthlyAverage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueMonthlyAverage.Name = "lblRevenueMonthlyAverage";
            this.lblRevenueMonthlyAverage.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblRevenueMonthlyAverage.Size = new System.Drawing.Size(287, 42);
            this.lblRevenueMonthlyAverage.TabIndex = 43;
            this.lblRevenueMonthlyAverage.Text = "Rp435.000,00";
            this.lblRevenueMonthlyAverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevenueYearlyAverage
            // 
            this.lblRevenueYearlyAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRevenueYearlyAverage.Font = new System.Drawing.Font("Montserrat Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueYearlyAverage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRevenueYearlyAverage.Location = new System.Drawing.Point(31, 285);
            this.lblRevenueYearlyAverage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueYearlyAverage.Name = "lblRevenueYearlyAverage";
            this.lblRevenueYearlyAverage.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblRevenueYearlyAverage.Size = new System.Drawing.Size(287, 42);
            this.lblRevenueYearlyAverage.TabIndex = 42;
            this.lblRevenueYearlyAverage.Text = "Rp435.000,00";
            this.lblRevenueYearlyAverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(667, 178);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(279, 27);
            this.label16.TabIndex = 41;
            this.label16.Text = "Common Service Type";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(347, 100);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(200, 27);
            this.label14.TabIndex = 39;
            this.label14.Text = "Daily Average:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(26, 100);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 27);
            this.label13.TabIndex = 38;
            this.label13.Text = "Daily Average:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(667, 256);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(279, 27);
            this.label10.TabIndex = 37;
            this.label10.Text = "Most Treatment Used";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(667, 100);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(279, 27);
            this.label11.TabIndex = 36;
            this.label11.Text = "Common Pet Types:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Montserrat SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(667, 64);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(279, 27);
            this.label12.TabIndex = 35;
            this.label12.Text = "Additional Information";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(347, 256);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 27);
            this.label6.TabIndex = 34;
            this.label6.Text = "Yearly Average:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(347, 178);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 27);
            this.label8.TabIndex = 33;
            this.label8.Text = "Monthly Average:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Montserrat SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(347, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(279, 27);
            this.label9.TabIndex = 32;
            this.label9.Text = "Number of Transactions";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Font = new System.Drawing.Font("Montserrat", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalRevenue.Location = new System.Drawing.Point(26, 339);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(292, 46);
            this.lblTotalRevenue.TabIndex = 31;
            this.lblTotalRevenue.Text = "TOTAL : Rp1.000.000";
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalRevenue.TextChanged += new System.EventHandler(this.lblTotalRevenue_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(26, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 27);
            this.label4.TabIndex = 30;
            this.label4.Text = "Yearly Average:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(26, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 27);
            this.label3.TabIndex = 29;
            this.label3.Text = "Monthly Average:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(26, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 27);
            this.label2.TabIndex = 28;
            this.label2.Text = "Revenue Gained";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblReportTitle.Location = new System.Drawing.Point(24, 6);
            this.lblReportTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(579, 51);
            this.lblReportTitle.TabIndex = 26;
            this.lblReportTitle.Text = "Sales Performance in <city>";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Plum;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Cocogoose", 12F);
            this.btnPrint.Location = new System.Drawing.Point(693, 697);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(323, 69);
            this.btnPrint.TabIndex = 44;
            this.btnPrint.Text = "Export to Excel";
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
            this.btnClose.Location = new System.Drawing.Point(36, 697);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 69);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmSalesCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1053, 790);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.lblNotFound);
            this.Name = "FrmSalesCity";
            this.Text = "FrmSalesCity";
            this.Load += new System.EventHandler(this.FrmSalesCity_Load);
            this.Resize += new System.EventHandler(this.FrmSalesCity_Resize);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pnlReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        public System.Windows.Forms.ComboBox cbCity;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Label lblNotFound;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label lblRevenueYearlyAverage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRevenueDailyAverage;
        private System.Windows.Forms.Label lblRevenueMonthlyAverage;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.Label lblCommonPetType;
        private System.Windows.Forms.Label lblCommonServiceType;
        private System.Windows.Forms.Label lblCommonTreatment;
        private System.Windows.Forms.Label lblTotalTransaction;
        private System.Windows.Forms.Label lblTransactionDailyAvg;
        private System.Windows.Forms.Label lblTransactionMonthlyAvg;
        private System.Windows.Forms.Label lblTransactionYearlyAvg;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}