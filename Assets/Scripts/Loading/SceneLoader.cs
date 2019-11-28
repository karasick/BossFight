using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader<SceneHandler> : MonoBehaviour where SceneHandler: ILoading
{
    [SerializeField]
    SceneHandler Session;

    [SerializeField]
    Text LoadingProgressText;

    [SerializeField]
    Image LoadingBar;

    // Name of the Scene to load
    protected string SceneToLoad;

    public void LoadSceneAsynch()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

        Session.SetActivePanel("LoadingPanel");

        while(!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
            LoadingBar.fillAmount = progress;

            LoadingProgressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
