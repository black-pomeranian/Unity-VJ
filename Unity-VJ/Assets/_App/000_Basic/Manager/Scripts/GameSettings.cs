using UnityEngine;

public class GameSettings : MonoBehaviour
{
    void Start()
    {
        // FPSを60に設定
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // エスケープキーが押されたらゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
