/**
 * キーボード押下時イベント
 * Windowsにおける、以下ショートカットキーの無効化
 * ・ウィンドウを閉じる
 * ・前の画面に戻る
 * ・画面の更新
 * ※ただし、フォームなどの入力中の場合は除く
 */
//キー押下時
window.document.onkeydown = onKeyDown;

function onKeyDown(e) {

  switch (event.keyCode) {

    case 8: // backspace key
      switch (window.event.srcElement.type) {
        case 'textarea':
        case 'text':
        case 'password':

          if (window.event.srcElement.readOnly == false) {
            return true;
          } else {
            return false;
          }
          break;

        default:
          return false;
      }
      break;

    case 37: // 「←」key
      if (event.altKey) {
        return false;
      }
      break;

    case 87: // Wキー
      // Ctrlキーと一緒に押している場合
      if (event.ctrlKey) {
        event.keyCode = 0;
        return false;
      }
      break;

    case 36: // Home
    case 115: // F4
      // Altキーと一緒に押している場合※「event.keyCode = 0;」は入れない(入れるとアクションがキャンセルされない)
      if (event.altKey) {
        if (event.keyCode == 115 || event.keyCode == 36) {
          event.keyCode = 39;
          event.cancelBubble = true;
          event.returnValue = false;
        }
        return false;
      }

    case 116: // F5 key
      event.keyCode = null;
      return false;
      break;

  }

}
