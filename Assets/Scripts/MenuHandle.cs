using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandle : MonoBehaviour
{
    public InputField PlayerName;
   
   

    // Start is called before the first frame update

    

    public void GetInputField()
    {
        Administrador.Instance.textIngresado = PlayerName.text;
        Debug.Log(Administrador.Instance.textIngresado);
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
