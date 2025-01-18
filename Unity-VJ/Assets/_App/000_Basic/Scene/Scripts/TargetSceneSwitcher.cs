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
        // PlayerPrefs����J�ڐ���擾
        int targetScene = PlayerPrefs.GetInt("TargetScene");
        Debug.Log($"�΂��玟��: {targetScene}");

        // LoadScene���A�����[�h
        SceneManager.UnloadSceneAsync("LoadingScene");

        // �ړI�̃V�[����񓯊��Ń��[�h
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}