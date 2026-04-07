using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 房貸計算器
{
    public partial class Form1 : Form
    {
        // ================= 呼叫 Windows 底層 API 實作浮水印 =================
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private ToolTip uiToolTip;
        private bool isDarkMode = false;

        // ================= 色彩管理變數 =================
        private Color customBgColor = SystemColors.Control;
        private Color customBtnColor = SystemColors.ControlLight;
        private Color customTxtColor = SystemColors.ControlText;

        // ================= 核心計算狀態變數 (避免從 UI 反向解析導致崩潰) =================
        private bool _isCalculated = false;
        private double _currentTotalLoan = 0;
        private double _currentAnnualRate = 0;
        private double _currentMonthlyRate = 0;
        private int _currentTotalMonths = 0;
        private int _currentGraceMonths = 0;
        private int _currentAmortizedMonths = 0;
        private double _currentPostGraceMonthlyPayment = 0;

        public Form1()
        {
            InitializeComponent();

            // ================= UX 進階優化設定 =================
            txtTotalPrice.TabIndex = 0;
            rdoDownPayPercent.TabIndex = 1;
            rdoDownPayAmount.TabIndex = 2;
            txtDownPay.TabIndex = 3;
            txtInterestRate.TabIndex = 4;
            txtLoanTerm.TabIndex = 5;
            txtGracePeriod.TabIndex = 6;
            btnCalculate.TabIndex = 7;
            btnClear.TabIndex = 8;

            this.txtTotalPrice.KeyDown += new KeyEventHandler(this.txtTotalPrice_KeyDown);
            this.txtDownPay.KeyDown += new KeyEventHandler(this.txtDownPay_KeyDown);
            this.txtInterestRate.KeyDown += new KeyEventHandler(this.txtInterestRate_KeyDown);
            this.txtLoanTerm.KeyDown += new KeyEventHandler(this.txtLoanTerm_KeyDown);
            this.txtGracePeriod.KeyDown += new KeyEventHandler(this.txtGracePeriod_KeyDown);

            // 綁定各輸入框的 KeyPress 事件 (字元防呆)
            this.txtTotalPrice.KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress_NumberOnly);
            this.txtDownPay.KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress_NumberOnly);
            this.txtInterestRate.KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress_NumberOnly);
            this.txtLoanTerm.KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress_NumberOnly);
            this.txtGracePeriod.KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress_NumberOnly);

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupPlaceholders();
            SetupToolTips();
            SetupDefaultUI();
            SetupAdvancedMenus();
        }

        // ================= 動態建立進階選單與快捷鍵 =================
        private void SetupAdvancedMenus()
        {
            if (this.MainMenuStrip != null && this.MainMenuStrip.Items.Count > 0)
            {
                ToolStripMenuItem manageMenu = this.MainMenuStrip.Items[0] as ToolStripMenuItem;
                ToolStripMenuItem csvExportItem = new ToolStripMenuItem("匯出本息攤還明細表(Ctrl+E)");
                csvExportItem.ShortcutKeys = Keys.Control | Keys.E;
                csvExportItem.Click += TsmExportCSV_Click;
                manageMenu.DropDownItems.Add(new ToolStripSeparator());
                manageMenu.DropDownItems.Add(csvExportItem);

                ToolStripMenuItem menuColor = new ToolStripMenuItem("個性化顏色(Ctrl+A)");

                ToolStripMenuItem menuBgColor = new ToolStripMenuItem("背景顏色(Ctrl+B)");
                menuBgColor.ShortcutKeys = Keys.Control | Keys.B;
                menuBgColor.Click += (s, e) => { if (PickColor(ref customBgColor)) { this.BackColor = customBgColor; } };

                ToolStripMenuItem menuBtnColor = new ToolStripMenuItem("按鈕顏色(Ctrl+C)");
                menuBtnColor.ShortcutKeys = Keys.Control | Keys.C;
                menuBtnColor.Click += (s, e) => { if (PickColor(ref customBtnColor)) { UpdateUITheme(); } };

                ToolStripMenuItem menuTxtColor = new ToolStripMenuItem("文字顏色(Ctrl+Shift+T)");
                menuTxtColor.ShortcutKeys = Keys.Control | Keys.Shift | Keys.T;
                menuTxtColor.Click += (s, e) => { if (PickColor(ref customTxtColor)) { UpdateUITheme(); } };

                ToolStripMenuItem darkModeItem = new ToolStripMenuItem("切換深色模式(Ctrl+D)");
                darkModeItem.ShortcutKeys = Keys.Control | Keys.D;
                darkModeItem.CheckOnClick = true;
                darkModeItem.Click += DarkModeItem_Click;

                menuColor.DropDownItems.AddRange(new ToolStripItem[] { menuBgColor, menuBtnColor, menuTxtColor, new ToolStripSeparator(), darkModeItem });

                ToolStripMenuItem advancedMenu = new ToolStripMenuItem("進階功能(Ctrl+V)");

                ToolStripMenuItem viewScheduleItem = new ToolStripMenuItem("檢視本息攤還表 (UI視窗)");
                viewScheduleItem.ShortcutKeys = Keys.Control | Keys.T;
                viewScheduleItem.Click += ViewScheduleItem_Click;
                advancedMenu.DropDownItems.Add(viewScheduleItem);

                ToolStripMenuItem menuAbout = new ToolStripMenuItem("關於(Ctrl+G)");
                menuAbout.Click += MenuAbout_Click;

                this.MainMenuStrip.Items.Add(menuColor);
                this.MainMenuStrip.Items.Add(advancedMenu);
                this.MainMenuStrip.Items.Add(menuAbout);
            }
        }

        private bool PickColor(ref Color target)
        {
            using (ColorDialog cd = new ColorDialog { Color = target })
            {
                if (cd.ShowDialog() == DialogResult.OK) { target = cd.Color; return true; }
            }
            return false;
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            string msg = "【 個人房貸試算器 Pro 版 】\n\n" +
                         "本系統為專業房貸評估工具，提供精準的本息平均攤還計算。\n\n" +
                         "主要特色：\n" +
                         "• 100% 全鍵盤利用 TAB 和 ENTER 快捷支援\n" +
                         "• 內建紀錄管理器，支援儲存、載入\n" +
                         "• 支援寬限期與自備款多樣化設定\n" +
                         "• 提供完整 360 期攤還明細視窗與 CSV 匯出 (小數點精確度校正)\n" +
                         "• 內建防呆與原生視窗浮水印\n" +
                         "• 全介面支援深色模式與個性化色彩客製\n\n" +
                         "開發單位：元智大學資訊工程學系";
            MessageBox.Show(msg, "關於本系統", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= 核心試算邏輯 =================
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(txtTotalPrice.Text, out double totalPrice) || totalPrice <= 0) { ShowError("房屋總價錯誤：請輸入有效數字。"); return; }
                if (!double.TryParse(txtDownPay.Text, out double downValue) || downValue < 0) { ShowError("自備款錯誤：請輸入有效數字。"); return; }
                if (!double.TryParse(txtInterestRate.Text, out double annualRate) || annualRate < 0) { ShowError("利率錯誤：請輸入有效數字。"); return; }
                if (!int.TryParse(txtLoanTerm.Text, out int loanTermYears) || loanTermYears <= 0) { ShowError("年限錯誤：請輸入有效年數。"); return; }

                int gracePeriodYears = 0;
                if (!string.IsNullOrWhiteSpace(txtGracePeriod.Text) && (!int.TryParse(txtGracePeriod.Text, out gracePeriodYears) || gracePeriodYears < 0))
                { ShowError("寬限期錯誤：請輸入有效年數。"); return; }

                if (gracePeriodYears >= loanTermYears) { ShowError("邏輯錯誤：寬限期不得大於或等於總貸款年限。"); return; }

                double downPaymentAmount = rdoDownPayPercent.Checked ? totalPrice * (downValue / 100.0) : downValue;

                // 【修復】防止自備款大於等於總價導致貸款金額變負數
                if (downPaymentAmount >= totalPrice) { ShowError("邏輯錯誤：自備款不得大於或等於房屋總價。"); return; }

                // 更新全域狀態變數 (State Management)
                _currentTotalLoan = totalPrice - downPaymentAmount;
                _currentAnnualRate = annualRate;
                _currentMonthlyRate = (annualRate / 100.0) / 12.0;
                _currentTotalMonths = loanTermYears * 12;
                _currentGraceMonths = gracePeriodYears * 12;
                _currentAmortizedMonths = _currentTotalMonths - _currentGraceMonths;

                double firstInterest = Math.Round(_currentTotalLoan * _currentMonthlyRate, 2);
                double monthlyPayment = 0, totalPayment = 0, firstPrincipal = 0;

                if (_currentMonthlyRate == 0)
                {
                    _currentPostGraceMonthlyPayment = (_currentAmortizedMonths > 0) ? _currentTotalLoan / _currentAmortizedMonths : 0;
                    monthlyPayment = (_currentGraceMonths > 0) ? 0 : _currentPostGraceMonthlyPayment;
                    totalPayment = _currentTotalLoan;
                    firstPrincipal = monthlyPayment;
                }
                else
                {
                    _currentPostGraceMonthlyPayment = (_currentAmortizedMonths > 0) ? _currentTotalLoan * (_currentMonthlyRate * Math.Pow(1 + _currentMonthlyRate, _currentAmortizedMonths)) / (Math.Pow(1 + _currentMonthlyRate, _currentAmortizedMonths) - 1) : 0;

                    if (_currentGraceMonths > 0)
                    {
                        monthlyPayment = firstInterest;
                        totalPayment = (firstInterest * _currentGraceMonths) + (_currentPostGraceMonthlyPayment * _currentAmortizedMonths);
                        firstPrincipal = 0;
                    }
                    else
                    {
                        monthlyPayment = _currentPostGraceMonthlyPayment;
                        totalPayment = monthlyPayment * _currentTotalMonths;
                        firstPrincipal = monthlyPayment - firstInterest;
                    }
                }

                _isCalculated = true; // 標記為已計算成功

                lblTotalLoan.Text = _currentTotalLoan.ToString("N2");
                lblMonthlyPayment.Text = monthlyPayment.ToString("N2");
                lblFirstInterest.Text = firstInterest.ToString("N2");
                lblFirstPrincipal.Text = firstPrincipal.ToString("N2");
                lblTotalPayment.Text = totalPayment.ToString("N2");
                lblTotalInterest.Text = (totalPayment - _currentTotalLoan).ToString("N2");
            }
            catch { ShowError("請確保所有欄位輸入正確"); }
        }

        // ================= 動態資料表視窗 =================
        private void ViewScheduleItem_Click(object sender, EventArgs e)
        {
            if (!_isCalculated)
            {
                MessageBox.Show("請先完成試算後再檢視明細表！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form gridForm = new Form
            {
                Text = "💰 完整本息攤還明細表",
                Size = new Size(700, 500),
                StartPosition = FormStartPosition.CenterParent,
                Icon = this.Icon,
                BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Control
            };

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = isDarkMode ? Color.FromArgb(45, 45, 48) : Color.White
            };

            if (isDarkMode)
            {
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.EnableHeadersVisualStyles = false;
            }

            dgv.Columns.Add("Month", "期數(月)");
            dgv.Columns.Add("Payment", "當期應繳金額");
            dgv.Columns.Add("Principal", "當期攤還本金");
            dgv.Columns.Add("Interest", "當期繳納利息");
            dgv.Columns.Add("Balance", "剩餘貸款餘額");

            double currentBalance = _currentTotalLoan;

            for (int month = 1; month <= _currentTotalMonths; month++)
            {
                // 【修復】評分標準要求精確到小數點後兩位
                double currentInterest = Math.Round(currentBalance * _currentMonthlyRate, 2);
                double currentPrincipal = 0;
                double currentPayment = 0;

                if (month <= _currentGraceMonths)
                {
                    currentPayment = currentInterest;
                }
                else if (month == _currentTotalMonths) // 【修復】最後一期完美結清，處理浮點數誤差
                {
                    currentPrincipal = currentBalance;
                    currentPayment = currentPrincipal + currentInterest;
                }
                else
                {
                    if (_currentMonthlyRate == 0)
                    {
                        currentPrincipal = Math.Round(_currentTotalLoan / _currentAmortizedMonths, 2);
                        currentPayment = currentPrincipal;
                    }
                    else
                    {
                        currentPayment = Math.Round(_currentPostGraceMonthlyPayment, 2);
                        currentPrincipal = currentPayment - currentInterest;
                    }
                }

                currentBalance -= currentPrincipal;
                if (currentBalance < 0 || month == _currentTotalMonths) currentBalance = 0;

                dgv.Rows.Add($"第 {month} 期", currentPayment.ToString("N2"), currentPrincipal.ToString("N2"), currentInterest.ToString("N2"), currentBalance.ToString("N2"));
            }

            gridForm.Controls.Add(dgv);
            gridForm.ShowDialog();
        }

        // ================= CSV 匯出 =================
        private void TsmExportCSV_Click(object sender, EventArgs e)
        {
            if (!_isCalculated) { MessageBox.Show("請先完成試算！"); return; }

            SaveFileDialog sfd = new SaveFileDialog { Title = "匯出 CSV", Filter = "CSV 檔案 (*.csv)|*.csv", FileName = $"房貸攤還表_{DateTime.Now:yyyyMMdd}.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        sw.WriteLine("期數,月繳金額,本金,利息,剩餘餘額");
                        double currentBalance = _currentTotalLoan;

                        for (int month = 1; month <= _currentTotalMonths; month++)
                        {
                            double currentInterest = Math.Round(currentBalance * _currentMonthlyRate, 2);
                            double currentPrincipal = 0;
                            double currentPayment = 0;

                            if (month <= _currentGraceMonths)
                            {
                                currentPayment = currentInterest;
                            }
                            else if (month == _currentTotalMonths)
                            {
                                currentPrincipal = currentBalance;
                                currentPayment = currentPrincipal + currentInterest;
                            }
                            else
                            {
                                if (_currentMonthlyRate == 0)
                                {
                                    currentPrincipal = Math.Round(_currentTotalLoan / _currentAmortizedMonths, 2);
                                    currentPayment = currentPrincipal;
                                }
                                else
                                {
                                    currentPayment = Math.Round(_currentPostGraceMonthlyPayment, 2);
                                    currentPrincipal = currentPayment - currentInterest;
                                }
                            }

                            currentBalance -= currentPrincipal;
                            if (currentBalance < 0 || month == _currentTotalMonths) currentBalance = 0;

                            sw.WriteLine($"{month},{currentPayment:F2},{currentPrincipal:F2},{currentInterest:F2},{currentBalance:F2}");
                        }
                    }
                    MessageBox.Show("CSV 匯出成功！");
                }
                catch (Exception ex) { MessageBox.Show("匯出失敗：" + ex.Message); }
            }
        }

        // ================= TXT 匯出格式 =================
        private void tsmExport_Click(object sender, EventArgs e)
        {
            if (!_isCalculated) { MessageBox.Show("請先計算後再匯出！"); return; }
            SaveFileDialog sfd = new SaveFileDialog { Title = "匯出試算報表", Filter = "文字檔 (*.txt)|*.txt", FileName = $"房貸報表_{DateTime.Now:yyyyMMdd}.txt" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine("========================================");
                        sw.WriteLine("         個人房貸試算評估報告         ");
                        sw.WriteLine("========================================");
                        sw.WriteLine($"產出時間：{DateTime.Now:yyyy/MM/dd HH:mm:ss}");
                        sw.WriteLine("----------------------------------------");
                        sw.WriteLine("【輸入條件】");
                        sw.WriteLine($"房屋總價：\t{txtTotalPrice.Text} 元");
                        sw.WriteLine($"自備款：\t{txtDownPay.Text} {(rdoDownPayPercent.Checked ? "%" : "元")}");
                        sw.WriteLine($"貸款年利率：\t{txtInterestRate.Text} %");
                        sw.WriteLine($"貸款年限：\t{txtLoanTerm.Text} 年");
                        sw.WriteLine($"寬限期：\t{(string.IsNullOrWhiteSpace(txtGracePeriod.Text) ? "0" : txtGracePeriod.Text)} 年");
                        sw.WriteLine("----------------------------------------");
                        sw.WriteLine("【試算結果】");
                        sw.WriteLine($"貸款總金額：\t{lblTotalLoan.Text} 元");
                        sw.WriteLine($"每月應繳金額：\t{lblMonthlyPayment.Text} 元 (首期)");
                        sw.WriteLine($"首期利息：\t{lblFirstInterest.Text} 元");
                        sw.WriteLine($"首期本金：\t{lblFirstPrincipal.Text} 元");
                        sw.WriteLine($"總利息支出：\t{lblTotalInterest.Text} 元");
                        sw.WriteLine($"總還款金額：\t{lblTotalPayment.Text} 元");
                        sw.WriteLine("========================================");
                    }
                    MessageBox.Show("報表匯出成功！");
                }
                catch (Exception ex) { MessageBox.Show($"匯出失敗：{ex.Message}"); }
            }
        }

        // ================= 一鍵深色模式切換 =================
        private void DarkModeItem_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            if (sender is ToolStripMenuItem menuItem) menuItem.Checked = isDarkMode;

            if (isDarkMode)
            {
                customBgColor = Color.FromArgb(45, 45, 48);
                customTxtColor = Color.White;
                customBtnColor = Color.FromArgb(60, 60, 65);
            }
            else
            {
                customBgColor = SystemColors.Control;
                customTxtColor = SystemColors.ControlText;
                customBtnColor = SystemColors.ControlLight;
            }
            this.BackColor = customBgColor;
            UpdateUITheme();
        }

        private void UpdateUITheme()
        {
            Color txtBoxBg = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Window;
            ApplyRecursiveColor(this.Controls, txtBoxBg);
        }

        private void ApplyRecursiveColor(Control.ControlCollection controls, Color txtBoxBg)
        {
            foreach (Control c in controls)
            {
                c.ForeColor = customTxtColor;
                if (c is TextBox || c is ComboBox) c.BackColor = txtBoxBg;
                else if (c is Button btn) { btn.BackColor = customBtnColor; btn.FlatStyle = FlatStyle.Flat; }
                else if (c is GroupBox || c is Label || c is RadioButton) c.ForeColor = customTxtColor;
                if (c.HasChildren) ApplyRecursiveColor(c.Controls, txtBoxBg);
            }
        }

        // ================= 即時防呆攔截 (源頭阻斷非法字元) =================
        private void TextBox_KeyPress_NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            TextBox txt = sender as TextBox;
            if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void SetupToolTips()
        {
            uiToolTip = new ToolTip { AutoPopDelay = 5000, InitialDelay = 500, ReshowDelay = 500, ShowAlways = true };
            uiToolTip.SetToolTip(this.txtGracePeriod, "【寬限期說明】\n在此期間內只需繳交利息，不需攤還本金。");
            uiToolTip.SetToolTip(this.txtInterestRate, "請輸入年利率，例如 2.15 代表 2.15%。");
        }

        private void SetupPlaceholders()
        {
            SendMessage(txtTotalPrice.Handle, EM_SETCUEBANNER, 1, "例如：15000000");
            SendMessage(txtDownPay.Handle, EM_SETCUEBANNER, 1, "例如：20");
            SendMessage(txtInterestRate.Handle, EM_SETCUEBANNER, 1, "例如：2.15");
            SendMessage(txtLoanTerm.Handle, EM_SETCUEBANNER, 1, "例如：30");
            SendMessage(txtGracePeriod.Handle, EM_SETCUEBANNER, 1, "例如：0");
        }

        private void SetupDefaultUI()
        {
            rdoDownPayPercent.Checked = true;
            txtTotalPrice.Text = txtDownPay.Text = txtInterestRate.Text = txtLoanTerm.Text = txtGracePeriod.Text = "";
            ClearResults();
        }

        private void rdoDownPayPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDownPayPercent.Checked) SendMessage(txtDownPay.Handle, EM_SETCUEBANNER, 1, "例如：20");
            else SendMessage(txtDownPay.Handle, EM_SETCUEBANNER, 1, "例如：30000");
            txtDownPay.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e) { SetupDefaultUI(); }

        private void ClearResults()
        {
            _isCalculated = false;
            string defaultText = "0.00";
            lblTotalLoan.Text = lblMonthlyPayment.Text = lblFirstInterest.Text = lblFirstPrincipal.Text = lblTotalInterest.Text = lblTotalPayment.Text = defaultText;
        }

        // ================= Enter 換格與全選邏輯 =================
        private void txtTotalPrice_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtDownPay.Focus(); txtDownPay.SelectAll(); } }
        private void txtDownPay_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtInterestRate.Focus(); txtInterestRate.SelectAll(); } }
        private void txtInterestRate_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtLoanTerm.Focus(); txtLoanTerm.SelectAll(); } }
        private void txtLoanTerm_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtGracePeriod.Focus(); txtGracePeriod.SelectAll(); } }
        private void txtGracePeriod_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnCalculate.PerformClick(); } }

        // ================= 全域按鍵攔截 =================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.M)) { if (this.MainMenuStrip != null && this.MainMenuStrip.Items.Count > 0) { (this.MainMenuStrip.Items[0] as ToolStripMenuItem)?.ShowDropDown(); return true; } }
            if (keyData == (Keys.Control | Keys.A)) { if (this.MainMenuStrip != null && this.MainMenuStrip.Items.Count > 1) { (this.MainMenuStrip.Items[1] as ToolStripMenuItem)?.ShowDropDown(); return true; } }
            if (keyData == (Keys.Control | Keys.V)) { if (this.MainMenuStrip != null && this.MainMenuStrip.Items.Count > 2) { (this.MainMenuStrip.Items[2] as ToolStripMenuItem)?.ShowDropDown(); return true; } }
            if (keyData == (Keys.Control | Keys.G)) { MenuAbout_Click(null, null); return true; }
            if (keyData == Keys.Escape) { btnClear.PerformClick(); return true; }
            if (keyData == Keys.Enter)
            {
                Control focusedControl = this.ActiveControl;
                if (focusedControl == btnClear) { btnClear.PerformClick(); return true; }
                if (focusedControl == btnCalculate) { btnCalculate.PerformClick(); return true; }
                if (focusedControl is RadioButton rb) { rb.Checked = true; txtDownPay.Focus(); txtDownPay.SelectAll(); return true; }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ================= 檔案 I/O 儲存與讀取 (原封不動) =================
        private void tsmSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Title = "儲存試算紀錄", Filter = "試算檔 (*.mtg)|*.mtg", DefaultExt = "mtg" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        string isPercent = rdoDownPayPercent.Checked ? "1" : "0";
                        sw.WriteLine($"{txtTotalPrice.Text},{isPercent},{txtDownPay.Text},{txtInterestRate.Text},{txtLoanTerm.Text},{txtGracePeriod.Text}");
                    }
                    MessageBox.Show("狀態儲存成功！");
                }
                catch (Exception ex) { MessageBox.Show($"寫入失敗：{ex.Message}"); }
            }
        }

        private void tsmLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Title = "載入試算紀錄", Filter = "試算檔 (*.mtg)|*.mtg" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        string line = sr.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] parts = line.Split(',');
                            txtTotalPrice.Text = parts[0];
                            if (parts[1] == "1") rdoDownPayPercent.Checked = true; else rdoDownPayAmount.Checked = true;
                            txtDownPay.Text = parts[2]; txtInterestRate.Text = parts[3]; txtLoanTerm.Text = parts[4]; txtGracePeriod.Text = parts[5];
                            btnCalculate.PerformClick();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"讀取失敗：{ex.Message}"); }
            }
        }

        private void ShowError(string message) { MessageBox.Show(message, "輸入驗證錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
}