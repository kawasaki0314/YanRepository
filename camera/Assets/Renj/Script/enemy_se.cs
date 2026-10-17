using UnityEngine;

public class enemy_se : MonoBehaviour
{
    // 爆発エフェクトのPrefab（ここにAudioSourceを設定しておく）
    [SerializeField] private GameObject _explosionEffectPrefab;
    // エフェクトを自動削除するまでの時間(秒)
    [SerializeField] private float _effectLifetime = 2.0f;
    // 再生したいSE（Inspectorで設定）
    [SerializeField] private AudioClip _hitSeClip;

    private void OnCollisionEnter(Collision collision)
    {
        bool isBullet = collision.gameObject.CompareTag("Bullet");
        bool isPlayer = collision.gameObject.CompareTag("Player");

        // Bulletに当たったときの処理
        if (isBullet)
        {
            if (_explosionEffectPrefab != null)
            {
                // エフェクトを生成
                GameObject effect = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);

                // エフェクトPrefabに付けたAudioSourceを取得して鳴らす
                AudioSource effectAudio = effect.GetComponent<AudioSource>();
                if (effectAudio != null && _hitSeClip != null)
                {
                    // AudioSourceの設定（Volumeや3D Sound設定など）を活かして再生
                    effectAudio.PlayOneShot(_hitSeClip);
                }

                // エフェクト（音源ごと）を指定時間後に削除
                Destroy(effect, _effectLifetime);
            }
        }

        // 敵本体の削除
        if (isPlayer || isBullet)
        {
            Destroy(gameObject);
        }
    }
}