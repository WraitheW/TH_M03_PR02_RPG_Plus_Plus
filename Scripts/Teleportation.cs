using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Teleportation : MonoBehaviourPun
{
    [Header("Components")]
    public GameObject destination;
    public bool needsKey;

    void Start()
    {
        if (destination == null)
        {
            destination = GameObject.FindGameObjectWithTag("TownCenter");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        #region Zombie Code
        //if (!PhotonNetwork.IsMasterClient)
        //{
        //    return;
        //}

        //if (collision.CompareTag("Player"))
        //{
        //    //if (needsKey)
        //    //{
        //    //    Debug.Log("Key Required");
        //    //    if (collision.GetComponent<PlayerController>().keys > 0)
        //    //    {
        //    //        needsKey = false;
        //    //        Teleport(collision);
        //    //        collision.GetComponent<PlayerController>().TakeKey(1);
        //    //        Debug.Log("House Unlocked");
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    Debug.Log("Entering Building");
        //    //    Teleport(collision);
        //    //}
        //    //if (needsKey)
        //    //{
        //    //    if (collision.GetComponent<PlayerController>().keys > 0)
        //    //    {
        //    //        UnlockDoor();
        //    //        Teleport(collision);
        //    //        Debug.Log("Unlocked");
        //    //    }
        //    //    Debug.Log(needsKey);
        //    //}
        //    //else
        //    //{
        //    //    Teleport(collision);
        //    //}
        //}
        #endregion
        TryTeleport(collision);
    }

    void Teleport(Collider2D collision)
    {
        collision.transform.position = destination.transform.position;
    }

    void TryTeleport(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (needsKey)
            //{
            //    Debug.Log("Key Required");
            //    if (collision.GetComponent<PlayerController>().keys > 0)
            //    {
            //        needsKey = false;
            //        Teleport(collision);
            //        collision.GetComponent<PlayerController>().TakeKey(1);
            //        Debug.Log("House Unlocked");
            //    }
            //}
            //else
            //{
            //    Debug.Log("Entering Building");
            //    Teleport(collision);
            //}
            if (needsKey)
            {
                if (collision.GetComponent<PlayerController>().keys > 0)
                {
                    UnlockDoor();
                    Teleport(collision);
                }
            }
            else
            {
                Teleport(collision);
            }
        }
    }

    [PunRPC]
    void UnlockDoor()
    {
        needsKey = false;
    }
}
