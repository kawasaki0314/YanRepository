using UnityEngine;

public class PlayerPOV : MonoBehaviour
{
    // カメラパラメータ
    private Transform neck; // プレイヤーの首の座標を指定
    private float sensitivity = 2.0f; // マウス感度
    private float minVertical = -90.0f; // 視点の最小角度
    private float maxVertical = 90.0f; // 視点の最大角度

    // 演算用の変数
    private float rotationX = 0.0f; // 縦方向の回転角度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // カーソルを非表示＆ロック
        Cursor.lockState = CursorLockMode.Locked;   // カーソルを画面中央に固定
        Cursor.visible = false;                     // カーソルを非表示にする
    }

    // Update is called once per frame
    void Update()
    {
        // マウス入力の取得
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // 横のマウス移動量を取得し、感度で調整
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // 縦のマウス移動量を取得し、感度で調整

        // playerの回転(左右)
        transform.Rotate(0, mouseX, 0); // プレイヤーのY軸回転を更新

        // 首の回転(上下)
        // マウスY方向の入力によって、縦方向の回転を更新
        rotationX -= mouseY;
        // 回転角度を指定された範囲に制限
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);
        // 首の回転の設定、縦方向のみ回転させる
        neck.localRotation = Quaternion.Euler(rotationX, 0, 0); 
    }
}

// カプセル化して入力された値をif文にかけて、
// 設定した最小値から最大値の間に値を収めることができる
