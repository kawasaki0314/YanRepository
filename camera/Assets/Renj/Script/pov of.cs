using UnityEngine;

public class povof : MonoBehaviour
{
    [SerializeField] private PlayerPOV playerPOV; // PlayerPOVスクリプトへの参照

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerHP.isDead)
        {
            if (playerPOV != null)
            {
                playerPOV.enabled = false; // PlayerPOVスクリプトを無効化
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    
    {

        if(playerPOV != null)
        {
            playerPOV.enabled = false; // PlayerPOVスクリプトを無効化
        }

    }
}
