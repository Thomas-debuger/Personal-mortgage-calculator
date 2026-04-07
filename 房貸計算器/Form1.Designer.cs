namespace 房貸計算器
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.記錄管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoDownPayPercent = new System.Windows.Forms.RadioButton();
            this.rdoDownPayAmount = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDownPay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoanTerm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGracePeriod = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalLoan = new System.Windows.Forms.Label();
            this.lblMonthlyPayment = new System.Windows.Forms.Label();
            this.lblFirstInterest = new System.Windows.Forms.Label();
            this.lblFirstPrincipal = new System.Windows.Forms.Label();
            this.lblTotalInterest = new System.Windows.Forms.Label();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.記錄管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 記錄管理ToolStripMenuItem
            // 
            this.記錄管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsmLoad,
            this.tsmExport});
            this.記錄管理ToolStripMenuItem.Name = "記錄管理ToolStripMenuItem";
            this.記錄管理ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.記錄管理ToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.記錄管理ToolStripMenuItem.Text = "記錄管理(Ctrl+M)";
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSave.Size = new System.Drawing.Size(319, 26);
            this.tsmSave.Text = "儲存當前資料(Ctrl+S)";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmLoad
            // 
            this.tsmLoad.Name = "tsmLoad";
            this.tsmLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.tsmLoad.Size = new System.Drawing.Size(319, 26);
            this.tsmLoad.Text = "載入資料(Ctrl+L)";
            this.tsmLoad.Click += new System.EventHandler(this.tsmLoad_Click);
            // 
            // tsmExport
            // 
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmExport.Size = new System.Drawing.Size(319, 26);
            this.tsmExport.Text = "匯出紀錄至文字檔(Ctrl+F)";
            this.tsmExport.Click += new System.EventHandler(this.tsmExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnCalculate);
            this.groupBox1.Controls.Add(this.txtGracePeriod);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLoanTerm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtInterestRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDownPay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdoDownPayAmount);
            this.groupBox1.Controls.Add(this.rdoDownPayPercent);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTotalPrice);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(34, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 246);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "輸入區";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(109, 23);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(146, 25);
            this.txtTotalPrice.TabIndex = 0;
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "房屋總價";
            // 
            // rdoDownPayPercent
            // 
            this.rdoDownPayPercent.AutoSize = true;
            this.rdoDownPayPercent.Checked = true;
            this.rdoDownPayPercent.Location = new System.Drawing.Point(23, 61);
            this.rdoDownPayPercent.Name = "rdoDownPayPercent";
            this.rdoDownPayPercent.Size = new System.Drawing.Size(125, 19);
            this.rdoDownPayPercent.TabIndex = 2;
            this.rdoDownPayPercent.TabStop = true;
            this.rdoDownPayPercent.Text = "自備款比例(%)";
            this.rdoDownPayPercent.UseVisualStyleBackColor = true;
            this.rdoDownPayPercent.ClientSizeChanged += new System.EventHandler(this.rdoDownPayPercent_CheckedChanged);
            // 
            // rdoDownPayAmount
            // 
            this.rdoDownPayAmount.AutoSize = true;
            this.rdoDownPayAmount.Location = new System.Drawing.Point(154, 61);
            this.rdoDownPayAmount.Name = "rdoDownPayAmount";
            this.rdoDownPayAmount.Size = new System.Drawing.Size(128, 19);
            this.rdoDownPayAmount.TabIndex = 3;
            this.rdoDownPayAmount.TabStop = true;
            this.rdoDownPayAmount.Text = "自備款金額(元)";
            this.rdoDownPayAmount.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "自備款數值";
            // 
            // txtDownPay
            // 
            this.txtDownPay.Location = new System.Drawing.Point(109, 89);
            this.txtDownPay.Name = "txtDownPay";
            this.txtDownPay.Size = new System.Drawing.Size(100, 25);
            this.txtDownPay.TabIndex = 5;
            this.txtDownPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "貸款利率";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(109, 125);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(100, 25);
            this.txtInterestRate.TabIndex = 7;
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "貸款年限";
            // 
            // txtLoanTerm
            // 
            this.txtLoanTerm.Location = new System.Drawing.Point(109, 161);
            this.txtLoanTerm.Name = "txtLoanTerm";
            this.txtLoanTerm.Size = new System.Drawing.Size(100, 25);
            this.txtLoanTerm.TabIndex = 9;
            this.txtLoanTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "寬限期";
            // 
            // txtGracePeriod
            // 
            this.txtGracePeriod.Location = new System.Drawing.Point(109, 198);
            this.txtGracePeriod.Name = "txtGracePeriod";
            this.txtGracePeriod.Size = new System.Drawing.Size(100, 25);
            this.txtGracePeriod.TabIndex = 11;
            this.txtGracePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(304, 25);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(90, 90);
            this.btnCalculate.TabIndex = 12;
            this.btnCalculate.Text = "開始計算";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(304, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 90);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清除重填";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblTotalPayment);
            this.groupBox2.Controls.Add(this.lblTotalInterest);
            this.groupBox2.Controls.Add(this.lblFirstPrincipal);
            this.groupBox2.Controls.Add(this.lblFirstInterest);
            this.groupBox2.Controls.Add(this.lblMonthlyPayment);
            this.groupBox2.Controls.Add(this.lblTotalLoan);
            this.groupBox2.Location = new System.Drawing.Point(34, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 195);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "結果區";
            // 
            // lblTotalLoan
            // 
            this.lblTotalLoan.Location = new System.Drawing.Point(151, 21);
            this.lblTotalLoan.Name = "lblTotalLoan";
            this.lblTotalLoan.Size = new System.Drawing.Size(243, 23);
            this.lblTotalLoan.TabIndex = 0;
            this.lblTotalLoan.Text = "0.00";
            this.lblTotalLoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMonthlyPayment
            // 
            this.lblMonthlyPayment.Location = new System.Drawing.Point(219, 55);
            this.lblMonthlyPayment.Name = "lblMonthlyPayment";
            this.lblMonthlyPayment.Size = new System.Drawing.Size(175, 15);
            this.lblMonthlyPayment.TabIndex = 1;
            this.lblMonthlyPayment.Text = "0.00";
            this.lblMonthlyPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFirstInterest
            // 
            this.lblFirstInterest.Location = new System.Drawing.Point(219, 80);
            this.lblFirstInterest.Name = "lblFirstInterest";
            this.lblFirstInterest.Size = new System.Drawing.Size(175, 15);
            this.lblFirstInterest.TabIndex = 2;
            this.lblFirstInterest.Text = "0.00";
            this.lblFirstInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFirstPrincipal
            // 
            this.lblFirstPrincipal.Location = new System.Drawing.Point(219, 105);
            this.lblFirstPrincipal.Name = "lblFirstPrincipal";
            this.lblFirstPrincipal.Size = new System.Drawing.Size(175, 15);
            this.lblFirstPrincipal.TabIndex = 3;
            this.lblFirstPrincipal.Text = "0.00";
            this.lblFirstPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalInterest
            // 
            this.lblTotalInterest.Location = new System.Drawing.Point(219, 130);
            this.lblTotalInterest.Name = "lblTotalInterest";
            this.lblTotalInterest.Size = new System.Drawing.Size(175, 15);
            this.lblTotalInterest.TabIndex = 4;
            this.lblTotalInterest.Text = "0.00";
            this.lblTotalInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.Location = new System.Drawing.Point(219, 156);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(175, 15);
            this.lblTotalPayment.TabIndex = 5;
            this.lblTotalPayment.Text = "0.00";
            this.lblTotalPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "貸款總金額：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "每月應繳金額 (首期)：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "首期利息：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "首期本金：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "總利息支出：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "總還款金額：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(215, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 15);
            this.label12.TabIndex = 14;
            this.label12.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(215, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 15);
            this.label13.TabIndex = 15;
            this.label13.Text = "年";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(260, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 15);
            this.label14.TabIndex = 16;
            this.label14.Text = "元";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(215, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 15);
            this.label15.TabIndex = 17;
            this.label15.Text = "(%)或(元)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(215, 201);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 15);
            this.label16.TabIndex = 18;
            this.label16.Text = "年";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(400, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 15);
            this.label17.TabIndex = 17;
            this.label17.Text = "元";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(400, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 15);
            this.label18.TabIndex = 18;
            this.label18.Text = "元";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(400, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 15);
            this.label19.TabIndex = 19;
            this.label19.Text = "元";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(400, 105);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 15);
            this.label20.TabIndex = 20;
            this.label20.Text = "元";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(400, 130);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 15);
            this.label21.TabIndex = 21;
            this.label21.Text = "元";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(400, 156);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(22, 15);
            this.label22.TabIndex = 22;
            this.label22.Text = "元";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 記錄管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripMenuItem tsmLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoDownPayPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtDownPay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoDownPayAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoanTerm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtGracePeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label lblTotalInterest;
        private System.Windows.Forms.Label lblFirstPrincipal;
        private System.Windows.Forms.Label lblFirstInterest;
        private System.Windows.Forms.Label lblMonthlyPayment;
        private System.Windows.Forms.Label lblTotalLoan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}

