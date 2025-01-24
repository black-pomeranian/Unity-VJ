using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectButtonManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // �Ǘ�����{�^�����X�g
    [SerializeField] private ParameterManager _parameterManager;

    [SerializeField] private Color activeColor = Color.green; // ON �̐F
    [SerializeField] private Color inactiveColor = Color.gray; // OFF �̐F

    private int effectMax;
    private Dictionary<Button, bool> isColorFlipped = new Dictionary<Button, bool>(); // �e�{�^���̔��]��Ԃ��Ǘ�

    void Start()
    {
        effectMax = _parameterManager.effectMax;

        // �{�^�����ƂɃ��X�i�[��ݒ�
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < effectMax)
            {
                int index = i; // �L���v�`������������邽�߂Ƀ��[�J���ϐ����g�p
                isColorFlipped[buttons[index]] = false; // ������Ԃ�ݒ�
                buttons[index].onClick.AddListener(() =>
                {
                    Debug.Log(index);
                    // ParameterManager��_currentCameraIndex��ݒ�
                    _parameterManager.ToggleEffectState(index);

                    // �{�^���̐F���X�V
                    UpdateButtonColor(buttons[index]);
                });
            }
        }
    }

    private void UpdateButtonColor(Button button)
    {
        var buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            // ���݂̔��]��Ԃɉ����ĐF��ݒ�
            buttonImage.color = isColorFlipped[button] ? inactiveColor : activeColor;
            // ����Ăяo�����ɔ��]������
            isColorFlipped[button] = !isColorFlipped[button];
        }
    }

    private void OnDestroy()
    {
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
