// Unity�ŃV���A���ʐM�AArduino�ƘA�g���鐗�`

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour
{
    // ����Ώۂ̃I�u�W�F�N�g�p�ɐ錾���Ă����āAStart�֐����Ŗ��O�Ō���
    GameObject targetObject;
    Player targetScript; // Unity�v���W�F�N�g��Player�I�u�W�F�N�g������O��

    // �V���A���ʐM�̃N���X�A�N���X���͐�������������
    public SerialHandler serialHandler;

    void Start()
    {
        // ����Ώۂ̃I�u�W�F�N�g���擾
        targetObject = GameObject.Find("Player"); // Unity�̃q�G�����L�[��Player�I�u�W�F�N�g�����邱�ƁB
        // ����ΏۂɊ֘A�t����ꂽ�X�N���v�g���擾�B
        // �啶���A����������ʂ���̂ŁAplayer.cs��������̂Ȃ�up�vlayer�B
        targetScript = targetObject.GetComponent<Player>(); // ������̓X�N���v�g�̖��O

        // �M����M���ɌĂ΂��֐��Ƃ���OnDataReceived�֐���o�^
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
        //������𑗐M����Ȃ�Ⴆ�΃R�R
        //serialHandler.Write("hogehoge");
    }

    //��M�����M��(message)�ɑ΂��鏈��
    void OnDataReceived(string message)
    {
        // �����Ńf�R�[�h���������L�q
        if (message == null)
            return;

        string recievedData;
        int t;

        // �{�����[��0
        recievedData = message.Substring(1, 4); // 1�����ڂ���4������ϊ�
        int.TryParse(recievedData, out t);
        targetScript.vol[0] = t;

        // �{�����[��1
        recievedData = message.Substring(5, 4); // 5�����ڂ���4������ϊ�
        int.TryParse(recievedData, out t);
        targetScript.vol[1] = t;

        // �X�C�b�`0
        recievedData = message.Substring(9, 1); // 9�����ڂ���1������ϊ�
        int.TryParse(recievedData, out t);
        targetScript.sw[0] = t;

        // �X�C�b�`1
        recievedData = message.Substring(10, 1); // 10�����ڂ���1������ϊ�
        int.TryParse(recievedData, out t);
        targetScript.sw[1] = t;

        // �X�C�b�`2
        recievedData = message.Substring(11, 1); // 11�����ڂ���1������ϊ�
        int.TryParse(recievedData, out t);
        targetScript.sw[2] = t;
    }
}