using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSceneSwitcher : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadTargetSceneAsync());
    }

    IEnumerator LoadTargetSceneAsync()
    {
        // PlayerPrefsから遷移先を取得
        int targetScene = PlayerPrefs.GetInt("TargetScene");
        Debug.Log($"緑から次へ: {targetScene}");

        // LoadSceneをアンロード
        SceneManager.UnloadSceneAsync("LoadingScene");

        // 目的のシーンを非同期でロード
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}