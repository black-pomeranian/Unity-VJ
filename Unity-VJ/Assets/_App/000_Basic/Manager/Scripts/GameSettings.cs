using UnityEngine;

public class GameSettings : MonoBehaviour
{
    void Start()
    {
        // FPS��60�ɐݒ�
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // �G�X�P�[�v�L�[�������ꂽ��Q�[���I��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
