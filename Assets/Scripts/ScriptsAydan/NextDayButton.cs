using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDayButton : MonoBehaviour
{
    public void ReloadScene()
    {
        Debug.Log("PLEASE");
        SceneManager.LoadScene(2);
    }
}
