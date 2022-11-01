using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGameOver : MonoBehaviour
{ 
    public void OnClickGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
