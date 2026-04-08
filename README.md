# 個人房貸試算器 (Personal Mortgage Calculator)

這是一個基於 C# Windows Forms 開發的專業級房貸評估工具。本系統不僅提供精準的本息平均攤還計算，更導入了業界標準的「狀態管理 (State Management)」架構，徹底分離 UI 與計算邏輯。專案主打極致的使用者體驗 (UX)，包含全鍵盤快捷操作、原生浮水印提示、深色模式切換，以及無死角的防呆驗證機制。

## 核心特色 (Key Features)

* **精準金融計算**：支援寬限期設定、自備款比例/金額雙模式，並完美校正最後一期攤還的浮點數誤差，符合銀行結清實務。
* **100% 全鍵盤操作**：完美支援 `Tab` 與 `Enter` 焦點切換，內建大量 `Ctrl + 快捷鍵` 組合，無需滑鼠即可完成所有操作。
* **動態深色模式 (Dark Mode)**：一鍵切換深色/淺色主題，並支援自訂背景、按鈕與文字顏色。
* **徹底的防呆機制**：
  * 攔截非數字鍵盤輸入（支援小數點判斷）。
  * 邏輯防禦：防止自備款大於總價、寬限期大於貸款年限等不合理輸入。
  * UI 狀態鎖定：未完成正確計算前，封鎖匯出與檢視明細表功能，避免程式崩潰。
* **完整明細與匯出**：
  * 內建 360 期動態 DataGridView 攤還明細視窗。
  * 支援匯出高精度 CSV 表格（完美相容 Excel，無千分位格式跑版問題）。
  * 支援匯出 TXT 文字評估報告。
* **狀態紀錄管理**：支援將當前試算條件儲存為 `.mtg` 專屬格式檔，方便日後隨時載入。
* **Windows 底層 API 整合**：呼叫 `user32.dll` 實作 TextBox 原生浮水印 (Cue Banner)，介面更簡潔專業。

## 系統需求與執行說明 (Getting Started)

### 環境需求
* **開發環境**：Visual Studio 2022 或更新版本
* **執行環境**：.NET Framework 4.7.2 (或以上) / Windows 作業系統

### 編譯與執行步驟
1. 複製此儲存庫到本地端：
   ```bash
   git clone [https://github.com/Thomas-debuger/Personal-mortgage-calculator.git]


2.  使用 Visual Studio 打開 `房貸計算器.sln` 方案檔。
3.  按下 `F5` 或點擊「開始」進行編譯與執行。
4.  若只需執行程式，可直接進入 `bin/Release/` 資料夾中執行 `.exe` 執行檔。

*(註：本儲存庫已設定完整的 `.gitignore`，確保不包含任何編譯產生的暫存檔如 `bin/`, `obj/` 等。)*

## 快捷鍵指南 (Shortcuts)

| 快捷鍵組合 | 功能描述 |
| :--- | :--- |
| `Tab` | 自動跳轉下一個輸入框 |
| `Enter` | 自動跳轉下一個輸入框 / 觸發計算 / 單選框選取 |
| `Ctrl + M` | 展開「紀錄管理」選單 |
| `Ctrl + S` | 儲存當前資料 |
| `Ctrl + L` | 載入先前資料 |
| `Ctrl + F` | 快速匯出 TXT 文字記錄檔 |
| `Ctrl + E` | 快速匯出 CSV 攤還明細表 |
| `Ctrl + A` | 展開「個性化顏色」選單 |
| `Ctrl + B` | 改變背景顏色 |
| `Ctrl + C` | 改變按鈕顏色 |
| `Ctrl + Shift + T` | 改變文字顏色 |
| `Ctrl + D` | 一鍵切換 深色/淺色 模式 |
| `Ctrl + V` | 展開「進階功能」選單 |
| `Ctrl + T` | 開啟「檢視本息攤還表」UI 視窗 |
| `Ctrl + G` | 開啟「關於本系統」資訊視窗 |
| `ESC` | 清除所有輸入與試算結果 (Reset) |

## 系統介面截圖 (Screenshots)

### 1\. 淺色模式與浮水印提示

<img width="680" height="587" alt="螢幕擷取畫面 2026-04-08 131920" src="https://github.com/user-attachments/assets/2815e29c-e395-4baf-a1c0-cffd4b5cafc3" />

### 2\. 紀錄管理功能

<img width="677" height="591" alt="螢幕擷取畫面 2026-04-08 132445" src="https://github.com/user-attachments/assets/07c2188b-c1b5-402d-8f51-70ce60d11be8" />

<img width="728" height="415" alt="螢幕擷取畫面 2026-04-08 132616" src="https://github.com/user-attachments/assets/b9529c5d-f2c1-474b-a045-3955642274e9" />

### 3\. 個性化顏色

<img width="676" height="587" alt="螢幕擷取畫面 2026-04-08 132514" src="https://github.com/user-attachments/assets/14e15ab5-71ce-465f-8190-e5f8a2a3f77c" />

### 4\. 動態本息攤還明細表

<img width="678" height="587" alt="螢幕擷取畫面 2026-04-08 133101" src="https://github.com/user-attachments/assets/74a5a3fb-25cd-444f-91d7-b61a7e357b25" />

<img width="850" height="608" alt="螢幕擷取畫面 2026-04-08 132209" src="https://github.com/user-attachments/assets/abd76f6f-5250-4685-9f62-b5a5413a929f" />

### 5\. 錯誤防呆提示

<img width="892" height="590" alt="螢幕擷取畫面 2026-04-08 132327" src="https://github.com/user-attachments/assets/16adc7b5-6b02-408d-bd8a-c30ef28cc005" />

## 開發者資訊

  * **開發單位**：元智大學資訊工程學系
  * **專案定位**：C\# 視窗程式設計進階實務作品

<!-- end list -->

