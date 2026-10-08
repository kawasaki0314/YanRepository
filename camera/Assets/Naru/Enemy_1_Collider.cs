using UnityEngine;

public class Enemy_1_Collider : MonoBehaviour
{
    // 爆発エフェクトのPrefab(InspectorでFX_Fire系のPrefabを設定する)
    [SerializeField] private GameObject _explosionEffectPrefab;
    // エフェクトを自動削除するまでの時間(秒)。炎はループするので必ず消す
    [SerializeField] private float _effectLifetime = 2.0f;
    // 追加: 弾に当たったときに鳴らすSE(InspectorでAudioClipを設定する)
    [SerializeField] private AudioClip _hitSeClip;
    // 追加: SEの音量(0〜1)
    [SerializeField, Range(0f, 1f)] private float _hitSeVolume = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        // CompareTagは文字列比較より安全で、タグの打ち間違いも警告してくれる
        bool isBullet = collision.gameObject.CompareTag("Bullet");
        bool isPlayer = collision.gameObject.CompareTag("Player");

        // Bulletに当たったときだけ、エフェクトとSEを出す
        if (isBullet)
        {
            // 爆発エフェクトを敵の位置に生成し、一定時間後に削除する
            if (_explosionEffectPrefab != null)
            {
                GameObject effect = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, _effectLifetime);
            }

            // 追加: 敵が破壊されても音が途切れないよう、その場に一時的な音源を作って再生する
            if (_hitSeClip != null)
            {
                AudioSource.PlayClipAtPoint(_hitSeClip, transform.position, _hitSeVolume);
            }
        }

        // PlayerまたはBulletに当たったら敵を破壊する
        if (isPlayer || isBullet)
        {
            Destroy(gameObject);
        }
    }
}