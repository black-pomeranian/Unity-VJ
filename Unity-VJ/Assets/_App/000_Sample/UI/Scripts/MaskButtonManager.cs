using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // �Ǘ�����{�^�����X�g
    [SerializeField] private ParameterManager _parameterManager;

    private int maskMax;

    [SerializeField] private Color activeColor = Color.green; // �A�N�e�B�u�ȃ{�^���̐F
    [SerializeField] private Color inactiveColor = Color.gray; // ��A�N�e�B�u�ȃ{�^���̐F

    void Start()
    {
        maskMax = _parameterManager.maskMax;


        // �{�^�����ƂɃ��X�i�[��ݒ�
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < maskMax)
            {
                int index = i; // �L���v�`������������邽�߂Ƀ��[�J���ϐ����g�p
                buttons[index].onClick.AddListener(() =>
                {
                    Debug.Log(index);
                    // ParameterManager��_currentCameraIndex��ݒ�
                    _parameterManager.SetMaskIndex(index);

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
