using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashSequence : MonoBehaviour
{
    public static int SceneNumber;
    void Start()
    {
        if(SceneNumber == 0)
        {
            StartCoroutine(SplashScreen());
        }
        //if (SceneNumber == 1)
        //{
        //    StartCoroutine(MainScene());
        //}

        IEnumerator SplashScreen()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(1);
        }
    }

}
