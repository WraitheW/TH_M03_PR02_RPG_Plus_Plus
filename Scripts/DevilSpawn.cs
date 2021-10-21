using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DevilSpawn : MonoBehaviourPun
{
    [SerializeField]
    private List<Rune> runes;

    public string demonPrefabLocation;
    public Transform spawnLocation;

    private int numOfDemons = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allTrue = false;
        foreach (Rune r in runes)
        {
            if (r.isTriggered)
            {
                allTrue = true;
            }
            else
            {
                allTrue = false;
                break;
            }
        }

        if (allTrue)
        {
            Invoke("TrySpawnDemon", 5f);
        }
    }

    void TrySpawnDemon()
    {
        if (numOfDemons < 1)
        {
            GameObject enemy = PhotonNetwork.Instantiate(demonPrefabLocation, spawnLocation.transform.position, Quaternion.identity);
            numOfDemons++;
        }
    }

}
