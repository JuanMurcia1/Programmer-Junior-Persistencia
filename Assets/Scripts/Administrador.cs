using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Administrador : MonoBehaviour
{

    public static Administrador Instance;

    public string textIngresado;
    public int score1;

    
    

    private void  Awake() {
        if (Instance != null)
        {
            
            Destroy(gameObject);
            
            
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
