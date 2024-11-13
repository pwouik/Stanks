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

    //dynamically created object
    [SerializeField] private GameObject obusPrefab;
    [SerializeField] private Transform obusParent;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    //probably to remove later, or store as const variable, or deduce in method
    [SerializeField] private float player_speed = 20f;
    [SerializeField] private Vector2 p1_direction;
    [SerializeField] private Vector2 p2_direction;
    [SerializeField] private float obus_speed = 10;
    [SerializeField] private float fire_height = 1f;

    //private component that are initialized in start
    private Rigidbody rgb_p1;
    private Rigidbody rgb_p2;

    private void Start()
    {
        rgb_p1 = player1.GetComponent<Rigidbody>();
        rgb_p2 = player2.GetComponent<Rigidbody>();
    }

    void handleInputs()
    {
        if (Input.GetKeyDown(dKey1)) //TODO replace with pressed on mov joystick
        { 
            Debug.Log("c");
            //todo remove p1_direction and compute a (normalized ? may don't normalized it) direction from joyssick
            Vector3 force = new Vector3(p1_direction.x,0,p1_direction.y);
            rgb_p1.AddForce(force * player_speed, ForceMode.Impulse); //TODO ne pas utiliser impulse
        }

        if (Input.GetKeyDown(dKey2)) //TODO replace with pressed on mov joystick
        { 
            //todo remove p2_direction and compute a (normalized ? may don't normalized it) direction from joyssick
            Vector3 force = new Vector3(p2_direction.x, 0, p2_direction.y);
            rgb_p2.AddForce(force * player_speed, ForceMode.Impulse); //TODO ne pas utiliser impulse
        }

        if (Input.GetKeyDown(dKey3)) //TODO replace with pressed on shot button
        {
            float rot = player1.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            GameObject obus =  Instantiate(obusPrefab, obusParent);
            obus.transform.rotation = player1.transform.rotation;
            obus.transform.position = player1.transform.position;

            Vector3 force = new Vector3(-Mathf.Sin(rot), fire_height, -Mathf.Cos(rot));
            Rigidbody rgb_obous = obus.GetComponent<Rigidbody>();
            rgb_obous.AddForce(force * obus_speed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(dKey4)) //TODO replace with pressed on shot button
        {
            float rot = player2.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            GameObject obus = Instantiate(obusPrefab, obusParent);
            obus.transform.rotation = player2.transform.rotation;
            obus.transform.position = player2.transform.position;

            Vector3 force = new Vector3(-Mathf.Sin(rot), fire_height, -Mathf.Cos(rot));
            Rigidbody rgb_obous = obus.GetComponent<Rigidbody>();
            rgb_obous.AddForce(force * obus_speed, ForceMode.Impulse);
        }


    }

    // Update is called once per frame
    void Update()
    {
        handleInputs();
    }
}
