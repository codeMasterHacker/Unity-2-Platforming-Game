using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour
{
    public GameObject FadePanel;

    private void Start()
    {
        if (FadePanel != null)
        {
            FadePanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex));
        GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().ResetValues();
    }

    public void NextLevel()
    {
        //SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1)%SceneManager.sceneCountInBuildSettings);
        int scene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

        if (scene == (SceneManager.sceneCountInBuildSettings-1))
        {
            GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().ResetValues();
        }

        StartCoroutine(FadeEffect(scene));
    }

    IEnumerator FadeEffect(int SceneToLoad)
    {
        if (FadePanel != null)
        {
            FadePanel.SetActive(true);

            for (int i = 0; i < 100; i++)
            {
                FadePanel.GetComponent<CanvasGroup>().alpha = (float)i * 0.01f;
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }

        SceneManager.LoadScene(SceneToLoad);
    }
}
