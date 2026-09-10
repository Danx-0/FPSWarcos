using System.Threading;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    public static GameManager instance;

    public bool isPlaying;

    [SerializeField]
    public float GameTime;
    [SerializeField]
    public TMP_Text timerText;
    
    


    private void Awake()
    {
     
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


    } 
    void Start()
    {
        isPlaying = true;
    }
    void Update()
    {
       // if (currentTime > MaxTime)
       //{
         //   currentTime = 0;
            //isDamage = false;
        ///    GetComponent<CircleCollider2D>().enabled = true;
       // }
        if (GameTime > 0)
        {
            GameTime -= Time.deltaTime;
            int min = (int) GameTime / 60;
            int seg = (int) GameTime % 60;
            timerText.text=min.ToString("00") + ":" + seg.ToString("00");
        } 
       if (GameTime <= 0)
        {
            isPlaying = false;
        }


    }

    public void ReloadLevel()// pa que cuando muera reinicie el juego 
    {
        SceneManager.LoadScene(1);
    }

    public void AddTime(float time)
    {
        GameTime += time;   
    }

}
