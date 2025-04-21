
namespace petMover_Final_Project
{
    partial class FrmTransactionDisplay
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlFormControls = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.tmrMovingText = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTAddress = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.lblTService = new System.Windows.Forms.Label();
            this.lblTDate = new System.Windows.Forms.Label();
            this.lblArrivalDate = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlPay = new System.Windows.Forms.Panel();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblPay = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrVisibility = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlFormControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.pnlPay.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeColumns = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat Medium", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 0);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 28;
            this.dgvProducts.Size = new System.Drawing.Size(804, 620);
            this.dgvProducts.TabIndex = 28;
            this.dgvProducts.Resize += new System.EventHandler(this.dgvProducts_Resize);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Thistle;
            this.pnlTitle.Controls.Add(this.pnlFormControls);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblTitle2);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1280, 80);
            this.pnlTitle.TabIndex = 29;
            this.pnlTitle.MouseEnter += new System.EventHandler(this.pnlTitle_MouseEnter);
            this.pnlTitle.MouseLeave += new System.EventHandler(this.pnlTitle_MouseLeave);
            // 
            // pnlFormControls
            // 
            this.pnlFormControls.Controls.Add(this.btnClose);
            this.pnlFormControls.Controls.Add(this.btnMinimize);
            this.pnlFormControls.Controls.Add(this.btnNormal);
            this.pnlFormControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFormControls.Location = new System.Drawing.Point(1116, 0);
            this.pnlFormControls.Name = "pnlFormControls";
            this.pnlFormControls.Size = new System.Drawing.Size(164, 80);
            this.pnlFormControls.TabIndex = 4;
            this.pnlFormControls.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Thistle;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Space Ranger Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(108, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 39);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Space Ranger Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(5, 20);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(50, 39);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "_";
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.FlatAppearance.BorderSize = 0;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Font = new System.Drawing.Font("Space Ranger Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.Location = new System.Drawing.Point(57, 20);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(50, 39);
            this.btnNormal.TabIndex = 2;
            this.btnNormal.Text = "O";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1718, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Welcome to Pet Shippers! Want to move or travel somewhere with your lovely pet? D" +
    "on\'t worry we got you covered!";
            this.lblTitle.MouseEnter += new System.EventHandler(this.lblTitle_MouseEnter);
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.Location = new System.Drawing.Point(12, 20);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(1718, 39);
            this.lblTitle2.TabIndex = 5;
            this.lblTitle2.Text = "Welcome to Pet Shippers! Want to move or travel somewhere with your lovely pet? D" +
    "on\'t worry we got you covered!";
            this.lblTitle2.Visible = false;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotal.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(301, 23);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(489, 58);
            this.lblGrandTotal.TabIndex = 1;
            this.lblGrandTotal.Text = "TOTAL:     ";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGrandTotal.Visible = false;
            // 
            // tmrMovingText
            // 
            this.tmrMovingText.Enabled = true;
            this.tmrMovingText.Interval = 10;
            this.tmrMovingText.Tick += new System.EventHandler(this.tmrMovingText_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvProducts);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.splitter2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.tlpInfo);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 720);
            this.splitContainer1.SplitterDistance = 807;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblGrandTotal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 100);
            this.panel1.TabIndex = 31;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 720);
            this.splitter2.TabIndex = 29;
            this.splitter2.TabStop = false;
            // 
            // tlpInfo
            // 
            this.tlpInfo.AutoSize = true;
            this.tlpInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpInfo.ColumnCount = 1;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfo.Controls.Add(this.lblTAddress, 0, 1);
            this.tlpInfo.Controls.Add(this.lblAddress, 0, 2);
            this.tlpInfo.Controls.Add(this.lblServiceType, 0, 4);
            this.tlpInfo.Controls.Add(this.lblTService, 0, 3);
            this.tlpInfo.Controls.Add(this.lblTDate, 0, 5);
            this.tlpInfo.Controls.Add(this.lblArrivalDate, 0, 6);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInfo.Location = new System.Drawing.Point(0, 0);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 7;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.8642F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.28395F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.876543F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.53086F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.61728F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.81482F));
            this.tlpInfo.Size = new System.Drawing.Size(472, 439);
            this.tlpInfo.TabIndex = 1;
            this.tlpInfo.Visible = false;
            // 
            // lblTAddress
            // 
            this.lblTAddress.AutoSize = true;
            this.lblTAddress.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTAddress.Location = new System.Drawing.Point(3, 40);
            this.lblTAddress.Name = "lblTAddress";
            this.lblTAddress.Size = new System.Drawing.Size(309, 39);
            this.lblTAddress.TabIndex = 2;
            this.lblTAddress.Text = "Destination Address:";
            this.lblTAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTAddress.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(3, 82);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(198, 39);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Jl. Jemursari";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAddress.Visible = false;
            // 
            // lblServiceType
            // 
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceType.Location = new System.Drawing.Point(3, 189);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(127, 39);
            this.lblServiceType.TabIndex = 4;
            this.lblServiceType.Text = "Express";
            this.lblServiceType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblServiceType.Visible = false;
            // 
            // lblTService
            // 
            this.lblTService.AutoSize = true;
            this.lblTService.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTService.Location = new System.Drawing.Point(3, 150);
            this.lblTService.Name = "lblTService";
            this.lblTService.Size = new System.Drawing.Size(197, 39);
            this.lblTService.TabIndex = 5;
            this.lblTService.Text = "Service Type:";
            this.lblTService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTService.Visible = false;
            // 
            // lblTDate
            // 
            this.lblTDate.AutoSize = true;
            this.lblTDate.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTDate.Location = new System.Drawing.Point(3, 258);
            this.lblTDate.Name = "lblTDate";
            this.lblTDate.Size = new System.Drawing.Size(325, 39);
            this.lblTDate.TabIndex = 6;
            this.lblTDate.Text = "Expected Arrival Date:";
            this.lblTDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTDate.Visible = false;
            // 
            // lblArrivalDate
            // 
            this.lblArrivalDate.AutoSize = true;
            this.lblArrivalDate.Font = new System.Drawing.Font("Montserrat SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalDate.Location = new System.Drawing.Point(3, 299);
            this.lblArrivalDate.Name = "lblArrivalDate";
            this.lblArrivalDate.Size = new System.Drawing.Size(162, 39);
            this.lblArrivalDate.TabIndex = 7;
            this.lblArrivalDate.Text = "12/12/2003";
            this.lblArrivalDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblArrivalDate.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImage = global::petMover_Final_Project.Properties.Resources._8975563;
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Size = new System.Drawing.Size(472, 720);
            this.splitContainer2.SplitterDistance = 428;
            this.splitContainer2.TabIndex = 2;
            // 
            // pnlPay
            // 
            this.pnlPay.Controls.Add(this.lblChange);
            this.pnlPay.Controls.Add(this.lblPay);
            this.pnlPay.Controls.Add(this.lblTotalPay);
            this.pnlPay.Controls.Add(this.panel2);
            this.pnlPay.Controls.Add(this.label3);
            this.pnlPay.Controls.Add(this.label2);
            this.pnlPay.Controls.Add(this.label1);
            this.pnlPay.Location = new System.Drawing.Point(68, 102);
            this.pnlPay.Name = "pnlPay";
            this.pnlPay.Size = new System.Drawing.Size(1150, 478);
            this.pnlPay.TabIndex = 32;
            this.pnlPay.Visible = false;
            this.pnlPay.VisibleChanged += new System.EventHandler(this.pnlPay_VisibleChanged);
            this.pnlPay.DoubleClick += new System.EventHandler(this.pnlPay_DoubleClick);
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold);
            this.lblChange.Location = new System.Drawing.Point(433, 318);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(674, 102);
            this.lblChange.TabIndex = 8;
            this.lblChange.Text = "Rp1.000.000,00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPay
            // 
            this.lblPay.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold);
            this.lblPay.Location = new System.Drawing.Point(429, 155);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(674, 102);
            this.lblPay.TabIndex = 7;
            this.lblPay.Text = "Rp1.000.000,00";
            this.lblPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold);
            this.lblTotalPay.Location = new System.Drawing.Point(429, 34);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(674, 102);
            this.lblTotalPay.TabIndex = 6;
            this.lblTotalPay.Text = "Rp1.000.000,00";
            this.lblTotalPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(56, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1051, 5);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 36F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(39, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(449, 105);
            this.label3.TabIndex = 4;
            this.label3.Text = "CHANGE :     ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 36F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(39, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 105);
            this.label2.TabIndex = 3;
            this.label2.Text = "PAY :     ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 36F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 105);
            this.label1.TabIndex = 2;
            this.label1.Text = "TOTAL :     ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrVisibility
            // 
            this.tmrVisibility.Interval = 10000;
            this.tmrVisibility.Tick += new System.EventHandler(this.tmrVisibility_Tick);
            // 
            // FrmTransactionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.pnlPay);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTransactionDisplay";
            this.Text = "TransactionDisplay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTransactionDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlFormControls.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.tlpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlPay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Timer tmrMovingText;
        public System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Panel pnlFormControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTAddress;
        public System.Windows.Forms.Label lblAddress;
        public System.Windows.Forms.Label lblServiceType;
        public System.Windows.Forms.Label lblTService;
        public System.Windows.Forms.Label lblTDate;
        public System.Windows.Forms.Label lblArrivalDate;
        public System.Windows.Forms.TableLayoutPanel tlpInfo;
        public System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.Label lblChange;
        public System.Windows.Forms.Label lblPay;
        public System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel pnlPay;
        private System.Windows.Forms.Timer tmrVisibility;
    }
}