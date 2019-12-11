using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public void QuitCurrentGame () {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
