# 基本設計  
  CSVファイルを読み込み、「"」で囲まれた改行のみを、置換する  
  入力：CSVファイル  
    CSVのフォーマット    
    ・「,」区切り  
    ・値は「"」で囲まれる  
    ・値の中の「"」は「""」にエスケープされる  
  出力：値の中の改行コードを、任意の文字で置換したCSV  

# 詳細設計  
  1. ループ (最終行を読込むまで、以下を繰り返す)  
    2. 1行読込 (ReadLine)  
    3. モード判定
       現在のモードと、読み込んだ「"」の数の偶奇によりモードを切り替える  
       初回 = 偶数モード  
        |  | 奇数読込 | 偶数読込 |     
        | 奇数モード | 偶数モード | 奇数モード |          
        | 偶数モード | 奇数モード | 偶数モード |   
  　4. 書込処理  
      偶数モード時：改行込で出力 (WriteLine)  
      奇数モード時：そのまま出力 (Write) + 置換文字を出力 (改行しない)  
