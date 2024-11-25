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
    [SerializeField] public Transform explodeParent;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    //probably to remove later, or store as const variable, used for, or deduce in method
    [SerializeField] private float player_speed = 20f;
    [SerializeField] private Vector2 p1_direction;
    [SerializeField] private Vector2 p2_direction;
    [SerializeField] private float obus_speed = 10;
    [SerializeField] private float fire_height = 1f;
    //temporary for debug and should be removed later
    [SerializeField] private float fire_angle = 200;
    [SerializeField] private float explosionRadius = 6;
    [SerializeField] private float explosionStrenght = 2500;


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
        //movement p1 (deprecated)
        if (Input.GetKeyDown(dKey1)) //TODO replace with pressed on mov joystick
        { 
            //todo remove p1_direction and compute a (normalized ? may don't normalized it) direction from joyssick
            Vector3 force = new Vector3(p1_direction.x,0,p1_direction.y);
            rgb_p1.AddForce(force * player_speed, ForceMode.Impulse); //TODO ne pas utiliser impulse
        }

        //movement p2 (deprecated)
        if (Input.GetKeyDown(dKey2)) //TODO replace with pressed on mov joystick
        { 
            //todo remove p2_direction and compute a (normalized ? may don't normalized it) direction from joyssick
            Vector3 force = new Vector3(p2_direction.x, 0, p2_direction.y);
            rgb_p2.AddForce(force * player_speed, ForceMode.Impulse); //TODO ne pas utiliser impulse
        }

        //fire p1
        if (Input.GetKeyDown(dKey3)) //TODO replace with pressed on shot button
        {
            GameObject obus =  Instantiate(obusPrefab, obusParent);

            //herit coordinate
            float rot = player1.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            obus.transform.position = player1.transform.position + new Vector3(0,1,0);
            obus.transform.rotation = player1.transform.rotation;
            obus.transform.Rotate(new Vector3(fire_angle, 0, 0)); //TODO fix rotation value depending on global varibale fire_height

            //forward explode parent to obus prefab
            obus_wipaj obusScript = obus.GetComponent<obus_wipaj>();
            obusScript.gameScript = this;

            //add forces
            Vector3 force = new Vector3(-Mathf.Sin(rot), fire_height, -Mathf.Cos(rot));
            Rigidbody rgb_obous = obus.GetComponent<Rigidbody>();
            rgb_obous.AddForce(force * obus_speed, ForceMode.Impulse);
        }

        //fire p2
        if (Input.GetKeyDown(dKey4)) //TODO replace with pressed on shot button
        {
            GameObject obus = Instantiate(obusPrefab, obusParent);

            //herit coordinate
            float rot = player2.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            obus.transform.position = player2.transform.position+ new Vector3(0,1,0);
            obus.transform.rotation = player2.transform.rotation;
            obus.transform.Rotate(new Vector3(-fire_angle, 0, 0)); //TODO fix rotation value depending on global varibale fire_height

            //forward explode parent to obus prefab
            obus_wipaj obusScript = obus.GetComponent<obus_wipaj>();
            obusScript.gameScript = this;
            
            //add forces
            Vector3 force = new Vector3(-Mathf.Sin(rot), fire_height, -Mathf.Cos(rot));
            Rigidbody rgb_obous = obus.GetComponent<Rigidbody>();
            rgb_obous.AddForce(force * obus_speed, ForceMode.Impulse);
        }


    }

    //handle explosion
    public void handleExplosionAtPosition(Vector3 pos)
    {
        Debug.Log($"ça fait bim bam boom en : {pos}"); //torm
        
        //code logic
        rgb_p1.AddExplosionForce(explosionStrenght,pos,explosionRadius);
        rgb_p2.AddExplosionForce(explosionStrenght,pos,explosionRadius);
    }

    // Update is called once per frame
    void Update()
    {
        handleInputs();
    }
}
