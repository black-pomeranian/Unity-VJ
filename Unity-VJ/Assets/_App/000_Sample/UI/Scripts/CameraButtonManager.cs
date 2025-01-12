using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CameraButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // �Ǘ�����{�^�����X�g
    [SerializeField] private ParameterManager _parameterManager; // ParameterManager�Q��

    private int cameraMax;

    [SerializeField] private Color activeColor = Color.green; // �A�N�e�B�u�ȃ{�^���̐F
    [SerializeField] private Color inactiveColor = Color.gray; // ��A�N�e�B�u�ȃ{�^���̐F

    void Start()
    {
        cameraMax = _parameterManager.cameraMax;

        // �{�^���̐����J�������ɍ��킹��
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i <= cameraMax)
            {
                // �{�^����L�������ăC�x���g��ݒ�
                buttons[i].gameObject.SetActive(true);
                int index = i; // �L���v�`������������邽�߂Ƀ��[�J���ϐ����g�p
                buttons[index].onClick.AddListener(() =>
                {
                    // ParameterManager��_currentCameraIndex��ݒ�
                    _parameterManager.SetCameraIndex(index);

                    // �{�^���̐F���X�V
                    UpdateButtonColors(buttons[index]);
                });
            }
        }

        // ������Ԃ̐ݒ�i�C���f�b�N�X0���A�N�e�B�u�ɂ���j
        if (cameraMax > 0)
        {
            UpdateButtonColors(buttons[0]);
        }
    }

    private void UpdateButtonColors(Button activeButton)
    {
        foreach (var button in buttons)
        {
            var buttonImage = button.GetComponent<Image>();
            if (buttonImage != null && button.gameObject.activeSelf)
            {
                buttonImage.color = button == activeButton ? activeColor : inactiveColor;
            }
        }
    }

    private void OnDestroy()
    {
        // ���X�i�[�̉���
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
