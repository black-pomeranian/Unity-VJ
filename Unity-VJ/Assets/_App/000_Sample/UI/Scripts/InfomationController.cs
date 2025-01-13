using System.Collections;
using System.Collections.Generic;
using TMPro; // TextMeshPro���g�p���邽�߂ɒǉ�
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class InfomationController : MonoBehaviour
{
    [SerializeField] private OSCServer oscServer;

    [SerializeField] private TextMeshProUGUI b1Text;
    [SerializeField] private TextMeshProUGUI b2Text;
    [SerializeField] private TextMeshProUGUI b3Text;
    [SerializeField] private TextMeshProUGUI s1Text;
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private TextMeshProUGUI bpmText;

    [SerializeField] private Scrollbar b1Scrollbar;
    [SerializeField] private Scrollbar b2Scrollbar;
    [SerializeField] private Scrollbar b3Scrollbar;
    [SerializeField] private Scrollbar s1Scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        if (oscServer == null)
        {
            Debug.LogError("OSCServer is not assigned in the Inspector.");
            return;
        }

        // �e�v���p�e�B���Ď����ATextMeshPro��Scrollbar�ɒl��ݒ�
        oscServer.B1
            .Subscribe(value =>
            {
                b1Text.text = value.ToString();
                b1Scrollbar.value = Mathf.Clamp01(value); // Scrollbar�̒l��0�`1�ɐ���
            })
            .AddTo(this);

        oscServer.B2
            .Subscribe(value =>
            {
                b2Text.text = value.ToString();
                b2Scrollbar.value = Mathf.Clamp01(value);
            })
            .AddTo(this);

        oscServer.B3
            .Subscribe(value =>
            {
                b3Text.text = value.ToString();
                b3Scrollbar.value = Mathf.Clamp01(value);
            })
            .AddTo(this);

        oscServer.S1
            .Subscribe(value =>
            {
                s1Text.text = value.ToString();
                s1Scrollbar.value = Mathf.Clamp01(value);
            })
            .AddTo(this);

        oscServer.Bpm
            .Subscribe(value =>
            {
                bpmText.text = value.ToString();
                Debug.Log(value);
            })
            .AddTo(this);
    }
}
