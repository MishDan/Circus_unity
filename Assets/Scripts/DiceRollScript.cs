using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceRollScript : MonoBehaviour
{
    Rigidbody rBody;
    Vector3 position;
    [SerializeField] private float maxRandForceVal, startRollForce;
    float forceX, forceY, forceZ;
    public string diceFaceNum;
    public bool isLanded = false;
    public bool firstThrow = false;

    // Flag to mark if the current dice result has been consumed for movement.
    public bool hasBeenUsed = false;

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.isKinematic = true;
        position = transform.position;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }

    void Update()
    {
        // You can add your own landing-detection logic here.
        // (e.g., check if rBody.velocity.magnitude < threshold and then set isLanded = true)
        if (rBody != null)
        {
            // On mouse click: if the dice is landed or if this is the first throw, roll it.
            if (Input.GetMouseButtonDown(0) && (isLanded || !firstThrow))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                    {
                        if (!firstThrow)
                            firstThrow = true;

                        RollDice();
                    }
                }
            }
        }
    }

    public void RollDice()
    {
        // Prepare for a new roll.
        hasBeenUsed = false;
        isLanded = false;
        diceFaceNum = "?";

        rBody.isKinematic = false;
        forceX = Random.Range(0, maxRandForceVal);
        forceY = Random.Range(0, maxRandForceVal);
        forceZ = Random.Range(0, maxRandForceVal);
        rBody.AddForce(Vector3.up * Random.Range(800, startRollForce));
        rBody.AddTorque(forceX, forceY, forceZ);
    }

    public void ResetDice()
    {
        // This method is intended to reset the game at the start,
        // not after each player's move.
        rBody.isKinematic = true;
        firstThrow = false;
        isLanded = false;
        transform.position = position;
    }
}