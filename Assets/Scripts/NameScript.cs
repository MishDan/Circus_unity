using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameScript : MonoBehaviour
{
    TextMeshPro tmp;

    void Awake()
    {
        tmp = transform.Find("NameField").gameObject.GetComponent<TextMeshPro>();
    }

    public void SetPlayerName(string name)
    {
        tmp.text = name;
        tmp.color = new Color32((byte)Random.Range(0, 255),
            (byte)Random.Range(0, 255),
            (byte)Random.Range(0, 255), 255);
    }

    
}
