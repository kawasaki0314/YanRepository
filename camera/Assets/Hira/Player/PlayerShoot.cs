using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //作ったプレハブ
    // 発射する球
    public GameObject bullet_Prefab;

    public GameObject Gun;
    // 球が出てくる場所
    public Transform shot_Point;

    // 球を飛ばすスピード
    public float bullet_Speed = 20f;

    // プレイヤーのカメラ
    // public Camera player_Camera;

    //★追加:リロードアニメーション
    public reloadanim reloadAnimScript;

    // ★追加: リロードUIなど
    public bool IsReloadingNow => isReloading;

    // ★追加:発射音(SE)
    public AudioClip shot_SE;

    // ★追加:リロード開始時に鳴らす音(InspectorでAudioClipを設定する)
    [SerializeField] private AudioClip _reloadSeClip;

    // ★追加:音を鳴らすスピーカー役
    public AudioSource audio_Source;

    //銃口から出す火花
    public ParticleSystem muzzleFlash;

    // 銃の反動を制御する
    public Recoil gunRecoil;

    // マガジンの最大弾数
    public int magazineSize = 30;

    // 現在の残弾数
    public int currentAmmo;

    // リロードにかかる時間（秒）
    public float reloadTime = 2f;

    // リロード中かどうか
    private bool isReloading = false;

    // リロード開始時刻
    private float reloadStartTime;

    // ゲーム開始時の処理
    void Start()
    {
        // マガジンを満タンにする
        currentAmmo = magazineSize;
    }

    void Update()
    {
        // リロード中の処理
        if (isReloading)
        {
            // 指定時間が経過したらリロード完了
            if (Time.time >= reloadStartTime + reloadTime)
            {
                ReloadComplete();
            }

            return;
        }

        // Rキーでリロード開始
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartReload();
        }

        // 左クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


        void Shoot()
        {
            // 弾が0発なら撃てない
            if (currentAmmo <= 0)
            {
                return;
            }

            // 弾のプレハブと発射位置が設定されているか確認
            if (bullet_Prefab == null || shot_Point == null)
            {
                return;
            }

            // 残弾数を1発減らす
            currentAmmo--;

            // ★銃口から火花を出す
            if (muzzleFlash != null)
            {
                muzzleFlash.Play();
            }

            // 玉を作る
            //GameObject = Unityのゲーム世界に存在する「物」
            //Instantiate()は「ゲームの中にオブジェクトを新しく作る」ためのもの
            //GameObject bullet = Instantiate=「新しくGameObjectを作って、それをbulletという変数に入れる」ということ
            GameObject bullet = Instantiate(
                bullet_Prefab,          //発射する玉
                shot_Point.position,    //玉が出てくる場所がどこにあるか
                shot_Point.rotation     //玉が出てくる場所がどちらを向いているか
            );

            //銃の反動を発生させる
            if (gunRecoil != null)
            {
                gunRecoil.Fire();
            }

            //bullet->今作った玉
            //.GetComponent<Rigidbody>()->玉についてるRigidbodyを探している
            //Rigidbody rb->それを【rb】という名前で覚えておく
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // ShotPointの前方向に玉を撃つ
            //linearVelocity=【物体がどの方向に、どのくらいの速さで動くか】
            if (rb != null)
            {
                rb.linearVelocity = shot_Point.forward * bullet_Speed;
            }

            // ★追加:SEを1回鳴らす
            // PlayOneShot = 音が重なっても途切れず鳴らせる再生方法
            audio_Source.PlayOneShot(shot_SE);
        }

        // リロード開始
        void StartReload()
        {
            // 現在の弾数がマガジンの最大弾数以上か確認する
            if (currentAmmo >= magazineSize)
            {
                // リロードせずに、このメソッドの処理を終了する
                return;
            }

            // リロード中であることを記録する
            // trueにすることで、Update()でリロード中の処理が行われる
            isReloading = true;
            // リロードを開始した時刻を記録する
            // Time.timeは、ゲーム開始から経過した時間（秒）
            reloadStartTime = Time.time;

            // ★追加: リロード回転アニメーションを開始！
            if (reloadAnimScript != null)
            {
                reloadAnimScript.StartReload();
            }

            // ★追加:リロード音を1回鳴らす
            // 弾が満タンのときは上のreturnで抜けるので、実際にリロードが始まる時だけ鳴る
            // 既存のaudio_Sourceを使い回す(新しいAudioSourceは不要)
            if (_reloadSeClip != null && audio_Source != null)
            {
                audio_Source.PlayOneShot(_reloadSeClip);
            }
        }

        // リロード完了
        void ReloadComplete()
        {
            // 現在の弾数をマガジンの最大弾数にする
            // 例：残弾数が5発、最大弾数が30発なら、30発に戻る
            currentAmmo = magazineSize;
            // リロード中ではない状態に戻す
            // falseにすることで、Update()のリロード中の処理を終了し、
            // 再び射撃できるようにする
            isReloading = false;
        }
    }
}