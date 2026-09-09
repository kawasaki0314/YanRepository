using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーパラメーター
    public float moveSpeed = 5.0f; // 移動速度
    public float gravity = -9.81f; // 重力加速度
    public CharacterController controller;　// 移動に使うコントローラ

    // 演算用の変数
    private Vector3 velocity; // 加速度を保持する変数
    private bool isGrounded; // 地面に着地しているかどうかのフラグ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 着地状態のチェック
        isGrounded = controller.isGrounded;

        // 着地している場合、落下速度をリセットする
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 地面についた場合、速度をリセットする
        }

        // 入力の取得
        float h = Input.GetAxis("Horizontal"); // 水平方向
        float v = Input.GetAxis("Vertical"); // 垂直方向

        // ローカル座標をワールド座標に変換して移動方向を計算
        Vector3 moveDirection = transform.TransformDirection(new Vector3(h, 0, v)) * moveSpeed;

        // 重力の加算
        velocity.y += gravity * Time.deltaTime;

        // 移動と重力を一度のcontroller.Moveで処理
        controller.Move((moveDirection + velocity) * Time.deltaTime);
    }
}
