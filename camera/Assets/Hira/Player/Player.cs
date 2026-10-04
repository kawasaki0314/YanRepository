using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Deth Scene");
    }

    //Collision型はぶつかった相手の情報を格納するための型であり中にはgameobject
    //やtransformなどの情報が格納されており、.（ドット）でつなぐことでアクセスできる
    //void OnCollisionEnter関数はCollision型のcolliisionの中に
    //ぶつかった相手の情報を格納してくれる関数
    //collision.gameObject.nameで当たった相手の(name)の情報を取得して
    //Debug.Logで(当たりました)と表示している
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