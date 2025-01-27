using System.Collections;
using UnityEngine;
using UniRx;

public class BPMActivator : MonoBehaviour
{
    [SerializeField] private OSCServer oscServer; // BPM���擾����OSCServer
    private float frequency;
    private Transform[] childObjects;
    private int currentIndex = 0;
    private Coroutine activationCoroutine;

    void Start()
    {
        // �q�I�u�W�F�N�g���擾
        int childCount = transform.childCount;
        childObjects = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i);
            childObjects[i].gameObject.SetActive(false); // ������ԂőS�Ĕ�A�N�e�B�u
        }

        // BPM�ω����Ď����Afrequency���X�V
        oscServer.Bpm.Subscribe(newBpm =>
        {
            UpdateFrequency(newBpm);
        }).AddTo(this);
    }

    void UpdateFrequency(float bpm)
    {
        frequency = bpm / 60f;

        // �R���[�`�����ăX�^�[�g�iBPM�ύX���ɓK�p�j
        if (activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }
        activationCoroutine = StartCoroutine(ActivationLoop());
    }

    IEnumerator ActivationLoop()
    {
        while (true)
        {
            if (childObjects.Length == 0) yield break;

            // ���ׂĂ̎q�I�u�W�F�N�g���A�N�e�B�u��
            foreach (var obj in childObjects)
            {
                obj.gameObject.SetActive(false);
            }

            // ���݂̃C���f�b�N�X�̃I�u�W�F�N�g���A�N�e�B�u��
            childObjects[currentIndex].gameObject.SetActive(true);

            // ���̃C���f�b�N�X�ցi���[�v����悤�Ɂj
            currentIndex = (currentIndex + 1) % childObjects.Length;

            // BPM�Ɋ�Â����ԑҋ@
            yield return new WaitForSeconds(1f / frequency);
        }
    }
}
