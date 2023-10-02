using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
    public Canvas loadingCanvas;
    public Slider slider;
    public static GameManagerScript instance;
    public float sliderValue;
    public Canvas inGameUICanvas;
    


    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
       
        
    }
    
    // Update is called once per frame
    void Update()
    {
       

        if (SceneManager.GetActiveScene().name != "Menu")
        {
           
            inGameUICanvas.enabled = true;
        }
        else
        {
            inGameUICanvas.enabled = false;
        }
    }
    private IEnumerator LoadSceneCoroutine(int sceneName)
    {
        loadingCanvas.enabled = true;

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

        while (op.progress <0.98 && !op.isDone)
        {
            slider.value = op.progress;
            yield return null;
        }
        op.allowSceneActivation = true;
        loadingCanvas.enabled = false;
    }
    public void LoadScene(int sceneName)
    {
        
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    public void LoadFarmScene()
    {
        LoadScene(1);
    }
    public void LoadLoungeScene()
    {
        LoadScene(2);
    }
    public void LoadCampsideScene()
    {
        LoadScene(3);
    }
    public void LoadMenu()
    {
        LoadScene(0);
    }
}
