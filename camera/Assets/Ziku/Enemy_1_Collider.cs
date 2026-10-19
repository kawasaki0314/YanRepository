using UnityEngine;

public class Enemy_1_ : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // プレイヤー、通常弾(Bullet)、または爆弾(Bomb)に直接当たったら倒れる
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Bullet") ||
            collision.gameObject.CompareTag("Bomb"))
        {
            Die();
        }
    }

    // 敵が倒れる処理（直撃時・爆風で巻き込まれた時の両方から呼べる）
    public void Die()
    {
        // （任意）敵が倒れた時のエフェクトや音があればここに追加できます
        Destroy(gameObject);
    }
}