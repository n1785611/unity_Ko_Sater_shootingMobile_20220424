using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;      //�ޥ� photon Pun API
using Photon.Realtime; //�ޥ� Photion �ή� API
/// <summary>
/// �j�U���޲z�t�ΡC
/// ���a���U��ԫ��s��}�l�ǰt�ж�
/// </summary>
/// MonoBehaviourPunCallbacks �s�u�\��^�I���O
/// �Ҧp�G�n�J�j�U��^�G�A���w���{��
public class loppymanager : MonoBehaviourPunCallbacks
{
    //GameObject �C������G�s��Unity �������Ҧ�����
    //SerializeField �N�p�H�����ܦb�ݩʭ��O�W
    //Heder ���D�A�b�ݩʭ��O�W��ܲ���r���D
    [SerializeField, Header("�s�u�e��")]
    private GameObject goConnectView;
    [SerializeField, Header("��ԫ��s")]
    private Button btnBattle;
    [SerializeField, Header("�s�u�H��")]
    private Text textCountPlayer;
    //����ƥ󼽩�C���ɰ���@���A��l�Ƴ]�w


    private void Awake()
    {
        //Photon �s�u �� �s�u�ϥγ]�w
        PhotonNetwork.ConnectUsingSettings();

    }
    //override ���\�Ƽg�~�Ӫ������O����
    //�s�u�ܱ���x�A�bConnectUsingSettings �����|�۰ʳs�u
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("<color=yellow>1.�}�l�s�u</color>");
        // Photon �s�u�[�J�j�U
        PhotonNetwork.JoinLobby();

    }
    //�s�u�ܤj�U���\��|���榹��k
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("<color=yellow>2. �w�g�i�J�j�U</color>");

        //��ԫ��s�B���� = �Ұ�
        btnBattle.interactable = true;


    }
    //���ѡG����

    //�p�����{������s�����q���y�{�C
    //1.���Ѥ��}���}���}�k public Method
    //2.���s�A�I��On Click��]�w�I�s����k�C
    public void StartConnect()

    {
        print("<color=yellow>3.�w�g�i�J����x</color>");
        //�C������A�Ұʳ]�w(���z��)- true��ܡAfalse ����
        goConnectView.SetActive(true);

        //Photon �s�u �� �[�J�H���ж�
        PhotonNetwork.JoinRandomRoom();
    }
    //�[�J�H���ж�����
    //1.�s�u�~��t�ɭP����
    //2.�٨S���ж�
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("<Color=red>4.�[�J�H���ж�����</color>");

        RoomOptions ro = new RoomOptions();      //�s�W�ж��]�w����
        ro.MaxPlayers = 5;                       //���w�ж��̤j�H��
        PhotonNetwork.CreateRoom("", ro);        //�إߩж��õ����ж�����   
    }

    //�[�J�ж�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("<color=yellow>5. �}�Ъ̥[�J�ж�</color>");
        int currentCount = PhotonNetwork.CurrentRoom.PlayerCount;    //��e�ж��H��
        int maxCount = PhotonNetwork.CurrentRoom.MaxPlayers;         //��e�ж��̤j�H��

        textCountPlayer.text = "�s�u�H��" + currentCount + "/" + maxCount;
    }
}
