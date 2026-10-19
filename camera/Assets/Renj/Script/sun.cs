using UnityEngine;
using UnityEngine.UIElements;

public class sun : MonoBehaviour
{
    public ClearCount clearCount;
    [SerializeField] private Enemy_1_Generator enemyGenerator;
    [SerializeField] private Enemy_1_MoveCtrl enemyMove;
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
    if(totalRX >=180f)
        {
            ChangeInterval(2f);
            speed = 2f;
        }
    else if(totalRX>=360f)
        {
            ChangeInterval(5f);
            speed = 4;
        
        }

    if(totalRX >=540f)
        {
            ChangeInterval(0.1f);
            speed = 1;
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
