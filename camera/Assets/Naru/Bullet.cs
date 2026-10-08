using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //衝突したら消える
        //何に当たってもGameObjectが消える
        if (!collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }

}