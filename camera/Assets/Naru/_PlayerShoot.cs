using UnityEngine;

// ★追加: AudioSourceが無い場合に自動で追加させる(付け忘れ防止)
[RequireComponent(typeof(AudioSource))]
public class _PlayerShoot : MonoBehaviour
{
    //作ったプレハブ
    // 発射する球
    public GameObject bullet_Prefab;

    // 球が出てくる場所
    public Transform shot_Point;

    // 球を飛ばすスピード
    public float bullet_Speed = 20f;

    // ★追加: 銃声のAudioClip(インスペクターで音声ファイルを割り当てる)
    [SerializeField] private AudioClip _gunshotClip;

    // ★追加: 銃声の音量(0.0~1.0)
    [SerializeField, Range(0f, 1f)] private float _gunshotVolume = 1.0f;

    // ★追加: SE再生に使うAudioSource
    private AudioSource _audioSource;

    // プレイヤーのカメラ
    // public Camera player_Camera;

    // ★追加: ゲーム開始時にAudioSourceを取得しておく
    // (毎回GetComponentするより効率が良い)
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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

        // ★追加: 銃声SEを再生する
        // PlayOneShotは連射しても前の音を途切れさせずに重ねて再生できる
        // _gunshotClipが未設定の場合にエラーにならないようnullチェックをしている
        if (_gunshotClip != null)
        {
            _audioSource.PlayOneShot(_gunshotClip, _gunshotVolume);
        }

        //player_Camera.transform.forward->これはカメラが向いている方向
        //カメラが向いている方向に球を飛ばす
        // rb.linearVelocity = player_Camera.transform.forward * bulletSpeed;
    }
}