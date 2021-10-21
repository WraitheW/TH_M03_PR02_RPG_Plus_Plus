using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Photon.Pun;

public class ChatBox : MonoBehaviourPun
{
    public TextMeshProUGUI chatLogText;
    public TMP_InputField chatInput;

    // instance
    public static ChatBox instance;

    private GameObject hidden;

    void Awake()
    {
        instance = this;
        hidden = GameObject.FindGameObjectWithTag("Hidden");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (EventSystem.current.currentSelectedGameObject == chatInput.gameObject)
            {
                OnChatInputSend();
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(chatInput.gameObject);
            }
        }
    }

    // called when the player wants to send a message
    public void OnChatInputSend()
    {
        if (PhotonNetwork.LocalPlayer.NickName == "ProfS" || PhotonNetwork.LocalPlayer.NickName == "Thomas")
        {
            if (chatInput.text == "tp")
            {
                photonView.RPC("TeleportCommand", RpcTarget.All);
            }
        }

        if (chatInput.text.Length > 0)
        {
            photonView.RPC("Log", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, chatInput.text);
            chatInput.text = "";
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    [PunRPC]
    void Log(string playerName, string message)
    {
        chatLogText.text += string.Format("<br>{0}:</b> {1}", playerName, message);

        chatLogText.rectTransform.sizeDelta = new Vector2(chatLogText.rectTransform.sizeDelta.x, chatLogText.mesh.bounds.size.y + 20);
    }

    [PunRPC]
    void TeleportCommand()
    {
        foreach (PlayerController p in GameManager.instance.players)
        {
            p.transform.position = hidden.transform.position;
        }
    }
}
