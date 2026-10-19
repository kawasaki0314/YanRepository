using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // 通常の弾プレハブ
    public GameObject bullet_Prefab;

    // ★追加: 最後の1発用の爆弾プレハブ（Inspectorで割り当てる）
    public GameObject bomb_Prefab;

    public GameObject Gun;
    // 球が出てくる場所
    public Transform shot_Point;

    // 球を飛ばすスピード
    public float bullet_Speed = 20f;

    // ★追加: 爆弾を撃った時の専用SE（通常のshot_SEと分けたい場合用・空でもOK）
    public AudioClip bomb_SE;

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

        // 左クリックされたら発射
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 弾が0発なら撃てない
        if (currentAmmo <= 0)
        {
            return;
        }

        if (shot_Point == null)
        {
            return;
        }

        // ★最後の1発（currentAmmoが1）かどうかを判定
        bool isLastBullet = (currentAmmo == 1);

        // ★生成するプレハブを切り替える
        // 最後の1発かつ爆弾プレハブが設定されていれば爆弾、それ以外は通常弾
        GameObject prefabToSpawn = (isLastBullet && bomb_Prefab != null) ? bomb_Prefab : bullet_Prefab;

        if (prefabToSpawn == null)
        {
            return;
        }

        // 残弾数を1発減らす
        currentAmmo--;

        // 銃口から火花を出す
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // 弾（または爆弾）を生成する
        GameObject bullet = Instantiate(
            prefabToSpawn,
            shot_Point.position,
            shot_Point.rotation
        );

        // 銃の反動
        if (gunRecoil != null)
        {
            gunRecoil.Fire();
        }

        // 前方に飛ばす
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = shot_Point.forward * bullet_Speed;
        }

        // ★効果音を鳴らす（爆弾SEが設定されていればそれを優先、なければ通常SE）
        if (audio_Source != null)
        {
            if (isLastBullet && bomb_SE != null)
            {
                audio_Source.PlayOneShot(bomb_SE);
            }
            else if (shot_SE != null)
            {
                audio_Source.PlayOneShot(shot_SE);
            }
        }
    }

    // リロード開始
    void StartReload()
    {
        if (currentAmmo >= magazineSize)
        {
            return;
        }

        isReloading = true;
        reloadStartTime = Time.time;

        if (reloadAnimScript != null)
        {
            reloadAnimScript.StartReload();
        }

        if (_reloadSeClip != null && audio_Source != null)
        {
            audio_Source.PlayOneShot(_reloadSeClip);
        }
    }

    // リロード完了
    void ReloadComplete()
    {
        currentAmmo = magazineSize;
        isReloading = false;
    }
}