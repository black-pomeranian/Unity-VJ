using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RenderButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // �Ǘ�����{�^�����X�g
    [SerializeField] private ParameterManager _parameterManager;

    private int renderMax;

    [SerializeField] private Color activeColor = Color.green; // �A�N�e�B�u�ȃ{�^���̐F
    [SerializeField] private Color inactiveColor = Color.gray; // ��A�N�e�B�u�ȃ{�^���̐F

    void Start()
    {
        renderMax = _parameterManager.renderMax;


        // �{�^�����ƂɃ��X�i�[��ݒ�
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < renderMax)
            {
                int index = i; // �L���v�`������������邽�߂Ƀ��[�J���ϐ����g�p
                buttons[index].onClick.AddListener(() =>
                {
                    // ParameterManager��_currentCameraIndex��ݒ�
                    _parameterManager.SetRenderIndex(index);

                    // �{�^���̐F���X�V
                    UpdateButtonColors(buttons[index]);
                });
            }

        }

        // ������Ԃ̐ݒ�i�C���f�b�N�X0���A�N�e�B�u�ɂ���j
        UpdateButtonColors(buttons[0]);
    }

    private void UpdateButtonColors(Button activeButton)
    {
        foreach (var button in buttons)
        {
            var buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
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
