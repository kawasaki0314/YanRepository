using UnityEngine;

public class Enemy_1_Collider : MonoBehaviour
{
    // 爆発エフェクトのPrefab
    [SerializeField] private GameObject _explosionEffectPrefab;
    // エフェクトを自動削除するまでの時間(秒)
    [SerializeField] private float _effectLifetime = 2.0f;

    // 弾が当たったときに鳴らすSE(AudioClip)
    [SerializeField] private AudioClip _hitSE;

    private void OnCollisionEnter(Collision collision)
    {
        // デバッグ表示: 何が当たったかを通知
        Debug.Log($"[Enemy_1_Collider] 接触しました: {collision.gameObject.name} (Tag: {collision.gameObject.tag})", gameObject);

        // Bulletに当たったときの処理
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("[Enemy_1_Collider] 弾(Bullet)との接触を検知しました！", gameObject);

            // 1. 爆発エフェクトの生成
            if (_explosionEffectPrefab != null)
            {
                GameObject effect = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, _effectLifetime);
                Debug.Log("[Enemy_1_Collider] 爆発エフェクトを生成しました。");
            }
            else
            {
                Debug.LogWarning("[Enemy_1_Collider] _explosionEffectPrefab が設定されていません！", gameObject);
            }

            // 2. SE（効果音）の再生
            if (_hitSE != null)
            {
                AudioSource.PlayClipAtPoint(_hitSE, transform.position);
                Debug.Log($"[Enemy_1_Collider] SE再生: {_hitSE.name}");
            }
            else
            {
                Debug.LogWarning("[Enemy_1_Collider] _hitSE が設定されていません！", gameObject);
            }

            // 3. 敵の削除
            Debug.Log("[Enemy_1_Collider] 敵オブジェクトを削除します。");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("[Enemy_1_Collider] プレイヤー(Player)と接触したため、敵オブジェクトを削除します。");
            Destroy(gameObject);
        }
    }
}