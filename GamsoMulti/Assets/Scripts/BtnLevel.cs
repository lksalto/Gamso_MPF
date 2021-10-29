using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnLevel : MonoBehaviour
{
    public void ClickWorms()
    { 
        SceneManager.LoadScene(sceneName: "Worms");
    }
}
