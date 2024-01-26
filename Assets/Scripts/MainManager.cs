using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{


    public Brick BrickPrefab;
    private string otherPlayer;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;

    public Text player;
    public GameObject GameOverText;
    
    private bool m_Started = false;

    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }   

        player.text= Administrador.Instance.bestPlayer;
        
    }

    private void Update()
    {
        
         
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
                
                


                
            }

        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(m_Points>Administrador.Instance.score1){
                    Administrador.Instance.score1 = m_Points;
                }

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

               
                
            }
        }
        
    }


    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

      
               
        if(m_Points < Administrador.Instance.score1 && Administrador.Instance.score1 > 0 ){
            
            Administrador.Instance.bestPlayer= "Best Score: " + Administrador.Instance.score1 + " By " + Administrador.Instance.textIngresado;
            player.text= Administrador.Instance.bestPlayer;
        }else{
            
            Administrador.Instance.bestPlayer= "Best Score: " + m_Points + " By " + Administrador.Instance.textIngresado;
            player.text= Administrador.Instance.bestPlayer;

        }
                
                Debug.Log(m_Points);
                Debug.Log(Administrador.Instance.score1);
                
    }

    public void ExitGame()
    {
        
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Administrador.Instance.SaveBestPlayer(); 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SaveStringPlayer()
{
    Administrador.Instance.SaveBestPlayer();
}

public void LoadStringPlayer()
{
    Administrador.Instance.LoadBestPlayer();
    
}

    

    
}



