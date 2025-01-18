using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int index)
    {
        // ���݂̃V�[���ƑJ�ڐ悪�����Ȃ牽�����Ȃ�
        if (SceneManager.GetActiveScene().buildIndex == index)
        {
            Debug.Log("���݂̃V�[���ƑJ�ڐ悪�������߁A�J�ڂ��X�L�b�v");
            return;
        }

        StartCoroutine(LoadSceneAsync("LoadingScene", index));
    }

    IEnumerator LoadSceneAsync(string loadScene, int index)
    {
        Debug.Log($"�΂ɑJ�ځB�J�ڐ��: {index}");

        // �J�ڐ�̃V�[������PlayerPrefs�ɕۑ��i�܂���GameManager�ȂǂŊǗ��j
        PlayerPrefs.SetInt("TargetScene", index);
        PlayerPrefs.Save();


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
