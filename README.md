# ![image](https://github.com/user-attachments/assets/17d1a284-ddd0-4efd-aef4-10ec26a4ad5f)再見! 沙發Potato!

再見! 沙發Potato!是一個團隊專案，也是一個將健康管理遊戲化的網頁應用平台，透過遊戲化元素提升使用者參與度和持續性。後台使用Asp.NET Core MVC完成。

歡迎使用測試帳號登入使用，帳密如下：
```
帳號：leo555555@gmail.com
密碼：@aA1234567890
```

## 負責的功能

### 1. 身份驗證系統
- 會員登入功能
- 忘記密碼流程
- 郵件驗證服務
- 安全性Token管理

### 2. 數據分析-玩家區
- 玩家行為分析
- 健康數據統計
- 商品銷售報表
- 透過時間選取器查看歷史資料

### 3. 會員管理系統
- 進階搜尋功能
- 排序、換頁、多筆結果

## 影片展示Demo

[![影片標題](https://github.com/user-attachments/assets/83f77191-7796-4a84-8dec-d4c0960d6ad3)](https://youtu.be/6vSm1pfr2bA)

## 環境要求
- 建議Windows 10 或以上版本
- SQL Server (建議 2019 或以上版本，Express 版本即可)

## 安裝步驟
### 需與 [前台](https://github.com/oez660oez/GoodByeCouchPotato_Front-End.git) 一同運行
1. 至 [Github](https://github.com/oez660oez/GoodByeCouchPotato_Back-End) 點擊 Code 後 Download ZIP 下載完畢解壓縮
2. 執行 SQL Server Management Studio時確保伺服器名稱為(localhost或是.或裝置名稱)連線
3. 執行 SQL 資料夾中的「241114 遊戲資料」指令碼
4. 安裝[Visual Studio 2022](https://visualstudio.microsoft.com/zh-hant/vs/)
5. 啟動專案

## 使用說明
### 系統登入
1. 使用測試帳號登入
2. 測試忘記密碼功能
3. 輸入註冊郵箱
4. 收取重置郵件
5. 按照指示重設密碼
6. 使用新密碼登入
### 數據分析功能
1. 選擇日期範圍
2. 可點擊下載按鈕下載圖表
### 會員搜尋
1. 使用進階搜尋
2. 設定篩選條件
3. 執行搜尋

## 注意事項
- 所有檔案需放在同一個資料夾中
- 如果缺少 .NET Framework 4.7.2，可以從微軟官網下載安裝
  
## Screen Photo

![登入介面](https://github.com/oez660oez/GoodByeCouchPotato_Back-End/blob/main/ScreenShot/Index.png)
![忘記密碼信件](https://github.com/oez660oez/GoodByeCouchPotato_Back-End/blob/main/ScreenShot/Email.png)
![數據分析玩家區](https://github.com/oez660oez/GoodByeCouchPotato_Back-End/blob/main/ScreenShot/DataAnalysis01.png)
![數據分析玩家區](https://github.com/oez660oez/GoodByeCouchPotato_Back-End/blob/main/ScreenShot/DataAnalysis02.png)
![會員搜尋](https://github.com/oez660oez/GoodByeCouchPotato_Back-End/blob/main/ScreenShot/MemberManagement.png)

## 使用工具
- ASP.NET Core MVC
- ASP.NET Core WebAPI
- Bootstrap
- jQuery
- ECharts
- Anime.js
- DataTables
- [SQL Server 2022](https://www.microsoft.com/zh-tw/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/zh-hant/vs/)
