using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_wipaj : MonoBehaviour
{
    //to remove later
    [SerializeField] private KeyCode dKey1 = KeyCode.Q;
    [SerializeField] private KeyCode dKey2 = KeyCode.W;
    [SerializeField] private KeyCode dKey3 = KeyCode.E;
    [SerializeField] private KeyCode dKey4 = KeyCode.R;

    [SerializeField] private GameObject obus;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private float player_speed = 1f;
    [SerializeField] private Vector2 p1_direction;
    [SerializeField] private Vector2 p2_direction;

    void handleInputs()
    {
        if (Input.GetKeyDown(dKey1))
        { //TODO replace with pressed on mov joystick
            Debug.Log("c");
            //todo remove p1_direction and compute a (normalized ? may don't normalized it) direction from joyssick
            Vector3 force = new Vector3(p1_direction.x,0,p1_direction.y);
            Debug.Log(force);//torm

            Rigidbody brb = player1.GetComponent<Rigidbody>();
            brb.AddForce(force * player_speed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(dKey2))
        { //TODO replace with pressed on mov joystick
            //todo remove p2_direction and compute a (normalized ? may don't normalized it) direction from joyssick
            Vector3 force = new Vector3(p2_direction.x, 0, p2_direction.y);
            Rigidbody brb = player2.GetComponent<Rigidbody>();
            brb.AddForce(force * player_speed, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleInputs();
    }
}
