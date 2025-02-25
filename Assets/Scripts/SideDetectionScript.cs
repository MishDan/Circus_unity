using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidedETECTIONsCRIPT : MonoBehaviour
{
    DiceRollScript diceRollScript;
    // Start is called before the first frame update
    void Awake()
    {
        diceRollScript = FindObjectOfType<DiceRollScript>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider sideCollider)
    {
        if (diceRollScript != null)
            if (diceRollScript.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                diceRollScript.isLanded = true;
                diceRollScript.diceFaceNum = sideCollider.name;
            }
            else
                diceRollScript.isLanded = false;
        else
            Debug.LogError("DiceRoll Script is not found");
    }
}
