# 🖥️ 顯示器控制與YOLO偵測應用程式

這是一個Windows Forms應用程式專案，展示了如何使用C#控制顯示器亮度和對比度、搭配Python後端實現YOLO物件偵測功能，同時透過Flask提供即時視訊串流。

---

<p align="center">
  <img src="https://img.shields.io/badge/C%23-.NET%20Framework-purple.svg?logo=csharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/Python-3.6+-blue.svg?logo=python&logoColor=white" alt="Python">
  <img src="https://img.shields.io/badge/YOLOv5-%23FF0000.svg?logo=pytorch&logoColor=white" alt="YOLOv5">
  <img src="https://img.shields.io/badge/Flask-%23000000.svg?logo=flask&logoColor=white" alt="Flask">
</p>

---

## ✨ 專案特色

- ✅ 使用Windows Forms建立友善的使用者介面
- ✅ 透過DDC/CI協議控制顯示器亮度與對比度
- ✅ 整合YOLOv5即時物件偵測功能
- ✅ 支援多種預設模式快速切換顯示設定
- ✅ 使用Flask提供視訊串流與物件偵測結果
- ✅ C#與Python跨語言整合應用

---

## 📋 功能說明

### 🔆 顯示器控制 (Form1)
- 透過滑桿調整亮度和對比度
- 使用專用按鈕套用變更
- 快速預設模式 (A, B, C) 適應不同光線環境
- 即時顯示當前和目標亮度/對比度數值

### 🔍 YOLO物件偵測 (Form2)
- 在獨立視窗中啟動物件偵測
- 使用YOLOv5進行即時物件偵測
- 從螢幕擷取影像並標示偵測到的物件

---

## 🛠️ 系統需求

### 軟體相依性
- Windows作業系統與.NET Framework
- Python 3.6+，需安裝以下套件：
  - monitorcontrol
  - flask
  - opencv-python
  - mss
  - torch
  - pillow

### 硬體需求
- 支援DDC/CI協議的顯示器以控制亮度/對比度

---

## 📥 安裝步驟

1. 下載或複製專案
   ```
   git clone https://github.com/你的使用者名稱/WinForms_DDC.git
   cd WinForms_DDC
   ```

2. 設定Python環境
   ```
   cd python
   python -m venv .venv
   .venv\Scripts\activate
   pip install -r requirements.txt
   ```

3. 在Visual Studio中開啟專案並建置

---

## 📚 使用說明

### 顯示器控制
1. 啟動應用程式
2. 使用上方滑桿設定所需亮度
3. 點擊「變更亮度」套用設定
4. 使用下方滑桿設定所需對比度
5. 點擊「變更對比度」套用設定
6. 或使用預設模式：
   - Mode A：最低亮度和對比度 (0, 0)
   - Mode B：最低亮度，中等對比度 (0, 50)
   - Mode C：最高亮度和對比度 (100, 100)

### YOLO物件偵測
1. 點擊「開啟yolo偵測」啟動偵測視窗
2. 應用程式將啟動Python Flask伺服器並顯示偵測結果
3. 物件將自動被偵測並標示出邊界框
4. 關閉視窗停止偵測

---

## 🧩 技術細節

### 架構說明
- C# Windows Forms負責使用者介面
- Python後端處理顯示器控制和YOLO偵測
- 透過Process.Start()和HTTP請求進行程序間通訊

### 檔案結構
- **WinForms_DDC/**: C#專案檔案
  - Form1.cs: 顯示器控制介面
  - Form2.cs: YOLO偵測介面
- **python/**: Python腳本
  - get_brightness.py: 讀取當前亮度
  - get_contrastValue.py: 讀取當前對比度
  - set_brightness.py: 設定亮度
  - set_contrastValue.py: 設定對比度
  - yoloDetect.py: YOLO偵測伺服器

### 通訊流程
1. 使用者與Windows Forms介面互動
2. C#程式碼執行Python腳本作為處理程序
3. Python腳本透過monitorcontrol與顯示器通訊
4. 對於YOLO偵測，Flask伺服器提供帶有偵測結果的影格
5. Form2定期從伺服器獲取影格並顯示

---

## ❓ 常見問題排解

### 顯示器控制問題
- 確保您的顯示器支援DDC/CI協議
- 檢查Windows是否允許應用程式控制您的顯示器
- 嘗試以管理員身份運行應用程式

### YOLO偵測問題
- 確保正確設置Python環境
- 驗證所有必需的套件都已安裝
- 檢查端口5000是否可用於Flask伺服器
- 確保YOLO模型檔案存在於預期路徑


---

## 💎 技術應用

| 技術 | 說明 |
|------|------|
| **Windows Forms** | 建立使用者介面與控制項 |
| **monitorcontrol** | 實現DDC/CI協議控制顯示器 |
| **YOLOv5** | 提供即時物件偵測功能 |
| **Flask** | 作為Python與C#之間的通訊橋樑 |
| **OpenCV** | 處理影像與標示偵測結果 |
| **MSS** | 實現螢幕截圖功能 |

---

## 展示



https://github.com/user-attachments/assets/b4986844-dc2a-484b-920e-92ebbde6231e



![1746733149141](https://github.com/user-attachments/assets/0eaa9770-7a1b-4da9-ac01-74ba13a4be2d)
