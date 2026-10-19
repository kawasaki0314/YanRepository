using UnityEngine;
using UnityEngine.UIElements;

public class sun : MonoBehaviour
{
    public ClearCount clearCount;
    [SerializeField] private Enemy_1_Generator enemyGenerator;
    [SerializeField] private Enemy_1_MoveCtrl enemyMove;
    [SerializeField] public PlayerShoot magazineSize; 
    private float totalRX = 0f;


    float drota = 90f; // Set the desired frame rate
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float speed = 360f / drota;
        float frameR = speed * Time.deltaTime;
        transform.Rotate(Vector3.right, speed * Time.deltaTime,Space.World);

        totalRX += frameR;

        //一日目　夜
    if(totalRX >=180f)
        {
            ChangeInterval(1.7f);
            speed = 1.2f;        }
    //二日目　朝
    else if(totalRX>=360f)
        {
            ChangeInterval(3f);
            speed = 2;
       //     magazineSize = 5;
        }

    //二日目　夜
    if(totalRX >=540f)
        {
            ChangeInterval(1.3f);
            speed = 0.8f;
        }
    //三日目　朝
    else if(totalRX >=720f)
        {
            ChangeInterval(2f);
            speed = 1f;
        }
    //三日目　夜
    if(totalRX >=900f)
        {
            ChangeInterval(0.8f);
            speed = 0.5f;

        }
   
    
    
    }
    public void ChangeInterval(float newInterval)
    {
        if(enemyGenerator != null)
        {
            enemyGenerator.spawnInterval = newInterval;
        }
    }


}
