using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingButton : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void settings()
    {
        if(settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
       
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
