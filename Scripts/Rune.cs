using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rune : MonoBehaviourPun
{
    public bool isTriggered = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
}
