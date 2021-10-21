using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI keyText;
    public GameObject keyTextGO;

    // instance
    public static GameUI instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void UpdateGoldText(int gold)
    {
        goldText.text = "<b>Gold:</b> " + gold;
    }

    public void EnableKeys()
    {
        keyText.enabled = true;
        keyTextGO.SetActive(true);
    }

    public void UpdateKeyText(int key)
    {
        keyText.text = "<b>Keys:</b> " + key;
    }
}
