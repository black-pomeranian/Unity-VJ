using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int index)
    {
        // 現在のシーンと遷移先が同じなら何もしない
        if (SceneManager.GetActiveScene().buildIndex == index)
        {
            Debug.Log("現在のシーンと遷移先が同じため、遷移をスキップ");
            return;
        }

        StartCoroutine(LoadSceneAsync("LoadingScene", index));
    }

    IEnumerator LoadSceneAsync(string loadScene, int index)
    {
        Debug.Log($"緑に遷移。遷移先は: {index}");

        // 遷移先のシーン名をPlayerPrefsに保存（またはGameManagerなどで管理）
        PlayerPrefs.SetInt("TargetScene", index);
        PlayerPrefs.Save();


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
