# 🏦 個人房貸試算器 Pro (Personal Mortgage Calculator Pro)

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%23Forms-5C2D91.svg?style=for-the-badge&logo=.net&logoColor=white)

本專案為一個具備高度精確性與優良使用者體驗（UX）的「個人房貸試算系統」。除了提供標準的本息平均攤還計算外，更導入了狀態管理（State Management）、精確的金融小數點校正、全鍵盤操作支援、原生 API 浮水印以及一鍵深色模式等進階軟體工程實作。

## ✨ 核心特色與進階功能

* **📈 精準的金融計算**：實作精確至小數點後兩位的本息平均攤還演算法，並具備「最後一期零頭完美結清」的銀行實務校正邏輯。
* **🛡️ 嚴密防呆機制**：
    * 透過 `KeyPress` 事件攔截非法字元輸入。
    * 具備嚴格的邏輯檢查（阻斷自備款大於總價、寬限期大於貸款年限等不合理輸入）。
    * 狀態鎖定機制，未完成試算前禁止檢視或匯出報表。
* **⌨️ 極致 UX (全鍵盤支援)**：支援 100% 鍵盤操作，利用 `Enter` 與 `Tab` 鍵實現無縫欄位跳轉與全選，並內建全局快捷鍵（如 `Ctrl+D` 切換深色模式、`Ctrl+E` 匯出 CSV 等）。
* **🌙 深色模式與 UI 客製化**：支援一鍵切換深色模式，並可透過選單自訂背景、按鈕與文字色彩。
* **📄 完整的報表匯出**：
    * **UI 視窗**：動態生成 360 期完整的 DataGridView 本息攤還明細表。
    * **CSV 匯出**：支援 UTF-8 BOM 編碼，解決 Excel 中文亂碼問題，並精準格式化數字（去除千分位逗號避免欄位錯亂）。
    * **TXT 報表**：提供排版整齊的純文字總結報告。
* **💾 狀態儲存與載入**：可將當前試算條件存為自訂的 `.mtg` 專案檔，方便日後隨時載入。
* **⚙️ Windows 底層 API 呼叫**：利用 `DllImport` 呼叫 `user32.dll` 實作原生的 TextBox 浮水印 (Cue Banner)。

## 📸 系統截圖

> 💡 **開發者/助教請注意**：以下為系統實際運行畫面。

### 1. 主介面與核心試算
![主畫面](images/main-screen.png)

### 2. 深色模式展示
![深色模式](images/dark-mode.png)

### 3. 動態本息攤還明細表 (DataGridView)
![攤還明細表](images/schedule-grid.png)

### 4. 匯出 CSV 與 TXT 報表
![報表匯出](images/export-report.png)

## 🚀 開發與執行說明

### 環境需求
* IDE: Visual Studio 2019 / 2022
* Framework: .NET Framework (4.7.2 或以上) / .NET Core WinForms
* 作業系統: Windows 10 / 11

### 執行步驟
1.  **取得專案**：使用 Git Clone 將本倉庫下載至本地端。
    ```bash
    git clone [https://github.com/你的帳號/你的專案名稱.git](https://github.com/你的帳號/你的專案名稱.git)
    ```
2.  **開啟方案**：進入專案資料夾，點擊 `.sln` (方案檔) 開啟 Visual Studio。
3.  **編譯與執行**：
    * 確認啟動專案設為 `房貸計算器`。
    * 按下 `F5` 或點擊「開始」進行編譯並執行。
    * *(註：為保持倉庫乾淨，本專案已配置 `.gitignore`，不包含編譯後產生的 `bin/` 與 `obj/` 暫存檔，需由本地端自行編譯)*

## ⌨️ 快捷鍵指南 (Shortcuts)

| 快捷鍵組合 | 功能說明 |
| :--- | :--- |
| `Enter` | 快速跳轉至下一輸入格 (自動全選文字) / 觸發計算 |
| `Ctrl + T` | 檢視完整本息攤還明細表 (UI視窗) |
| `Ctrl + E` | 匯出本息攤還明細表 (CSV格式) |
| `Ctrl + D` | 一鍵切換深/淺色模式 |
| `Ctrl + A` / `B` / `C` | 開啟顏色自訂選單 (文字/背景/按鈕) |
| `Ctrl + S` | 儲存當前試算條件 (.mtg) |
| `Ctrl + O` | 載入試算條件 (.mtg) |
| `Ctrl + G` | 關於本系統 |
| `Esc` | 清除所有輸入與計算結果 |

## 📂 專案架構與重要程式碼說明
* `Form1.cs`: 核心 UI 邏輯、事件綁定與按鍵攔截 (`ProcessCmdKey`)。包含所有狀態變數 (`_currentTotalLoan` 等) 以確保計算與 UI 解耦。
* **底層 API 宣告區**: 透過 `EM_SETCUEBANNER` 實現 TextBox 提示文字。
* **核心演算法區**: 包含寬限期判斷邏輯、月利率轉換，以及 $P \times \frac{r(1+r)^n}{(1+r)^n - 1}$ 的標準本息攤還公式實作。

---
**開發單位**：元智大學資訊工程學系