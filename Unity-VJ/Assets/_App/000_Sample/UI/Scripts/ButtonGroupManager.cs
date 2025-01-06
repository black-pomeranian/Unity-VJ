using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupManager : MonoBehaviour
{
    [SerializeField] private List<Button> buttons; // �Ǘ�����{�^�����X�g
    [SerializeField] private Color activeColor = Color.green; // �A�N�e�B�u�ȃ{�^���̐F
    [SerializeField] private Color inactiveColor = Color.gray; // ��A�N�e�B�u�ȃ{�^���̐F

    void Start()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClicked(button));
        }

        // ������Ԃ̐ݒ�
        UpdateButtonColors(buttons[0]);
    }

    private void OnButtonClicked(Button clickedButton)
    {
        UpdateButtonColors(clickedButton);
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
