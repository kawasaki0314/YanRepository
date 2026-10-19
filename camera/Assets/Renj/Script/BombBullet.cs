using UnityEngine;

public class BombBullet : MonoBehaviour
{
    // インスペクターで設定する爆発エフェクトのプレハブ
    public GameObject explosionEffectPrefab;

    // ★追加: 爆発エフェクトが消えるまでの時間（秒）
    public float effectDuration = 2f;

    // 爆発の届く範囲（半径）
    public float explosionRadius = 5f;

    // 爆発で吹き飛ばす力
    public float explosionForce = 700f;

    // （任意）爆発音
    public AudioClip explosionSE;

    private void OnCollisionEnter(Collision collision)
    {
        // プレイヤー以外に当たったら爆発
        if (!collision.gameObject.CompareTag("Player"))
        {
            Explode();
            Destroy(gameObject); // 弾本体を消す
        }
    }

    // 爆発の処理
    private void Explode()
    {
        // 1. 爆発エフェクトを生成し、指定時間後に消去する
        if (explosionEffectPrefab != null)
        {
            GameObject effect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            // ★第2引数に秒数を渡すことで、指定時間後に自動削除されます
            Destroy(effect, effectDuration);
        }

        // 2. 爆発音をその場で鳴らす
        if (explosionSE != null)
        {
            AudioSource.PlayClipAtPoint(explosionSE, transform.position);
        }

        // 3. 爆発の範囲内（半径 explosionRadius）にあるすべてのオブジェクトを検知
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // プレイヤー自身は巻き込まないように除外
            if (hit.CompareTag("Player"))
            {
                continue;
            }

            // --- 敵にダメージを与える処理（敵のスクリプトがある場合） ---
            /*
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(100);
            }
            */
            Enemy_1_ enemy = hit.GetComponent<Enemy_1_>();
            if (enemy != null)
            {
                enemy.Die();
            }

            // --- 物理（Rigidbody）がついているものを吹き飛ばす ---
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}