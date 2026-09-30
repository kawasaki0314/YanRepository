using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // 発射する球
    public GameObject bullet_Prefab;

    // 球が出てくる場所
    public Transform shot_Point;

    // 球を飛ばすスピード
    public float bullet_Speed = 20f;

    // プレイヤーのカメラ
    // public Camera player_Camera;

    void Update()
    {
        // 左クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 玉を作る
        GameObject bullet = Instantiate(
            bullet_Prefab,
            shot_Point.position,
            shot_Point.rotation
        );

        // 球にRigidbodyが付いているかどうか
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // ShotPointの前方向に玉を撃つ
        rb.linearVelocity = shot_Point.forward * bullet_Speed;

        //カメラが向いている方向に球を飛ばす
        // rb.linearVelocity = player_Camera.transform.forward * bulletSpeed;
    }
}


