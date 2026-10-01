using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //作ったプレハブ
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
        //GameObject = Unityのゲーム世界に存在する「物」
        //Instantiate()は「ゲームの中にオブジェクトを新しく作る」ためのもの
        //GameObject bullet = Instantiate=「新しくGameObjectを作って、それをbulletという変数に入れる」ということ
        GameObject bullet = Instantiate(
            bullet_Prefab,          //発射する玉
            shot_Point.position,    //玉が出てくる場所がどこにあるか
            shot_Point.rotation     //玉が出てくる場所がどちらを向いているか
        );

        //bullet->今作った玉
        //.GetComponent<Rigidbody>()->玉についてるRigidbodyを探している
        //Rigidbody rb->それを【rb】という名前で覚えておく
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // ShotPointの前方向に玉を撃つ
        //linearVelocity=【物体がどの方向に、どのくらいの速さで動くか】
        rb.linearVelocity = shot_Point.forward * bullet_Speed;

        //player_Camera.transform.forward->これはカメラが向いている方向
        //カメラが向いている方向に球を飛ばす
        // rb.linearVelocity = player_Camera.transform.forward * bulletSpeed;
    }


}


