using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int _hp = 3;
    public int _damage = 1;

    void Start()
    {
        Debug.Log("うおおおおおおおおおおおおお");
    }


    public void TakeDamage(int damage)
    {
        _hp -= damage;

        Debug.Log("現在のHP：" + _hp);

        if (_hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("死市氏市市");
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("当たりました：" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("敵に当たってるよん");
            TakeDamage(_damage);
        }
    }
}