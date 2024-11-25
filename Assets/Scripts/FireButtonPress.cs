using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class FireButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject player1, player2;
    [SerializeField] private GameObject joyStickLeft, joyStickRight;
    [SerializeField] private GameObject leftCannonSound, rightCannonSound;
    
    //Dynamically created objects
    [SerializeField] private GameObject obusPrefab;
    [SerializeField] private Transform obusParent;
    [SerializeField] public Transform explodeParent;

    //private component that are initialized in start
    private Rigidbody rgb_p1;
    private Rigidbody rgb_p2;

    //temporary for debug and should be removed later and inlined in code
    [SerializeField] private float obus_speed = 10;
    [SerializeField] private float fire_height = 1f;
    [SerializeField] private float fire_angle = 200;
    [SerializeField] private float explosionRadius = 6;
    [SerializeField] private float explosionStrenght = 2500;


    private float feedbackTimer = 0, flashDuration = .1f, soundDuration = 1f;
    private bool isLeftPlayerShooting = false, isRightPlayerShooting = false;


    //handle explosion
    public void handleExplosionAtPosition(Vector3 pos)
    {
        Debug.Log($"ça fait bim bam boom en : {pos}"); //torm
        
        //code logic
        rgb_p1.AddExplosionForce(explosionStrenght,pos,explosionRadius);
        rgb_p2.AddExplosionForce(explosionStrenght,pos,explosionRadius);
    }

    void Start()
    {
        leftCannonSound.SetActive(false);
        rightCannonSound.SetActive(false);

        //query things
        rgb_p1 = player1.GetComponent<Rigidbody>();
        rgb_p2 = player2.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (feedbackTimer <= soundDuration)
        {
            feedbackTimer += Time.deltaTime;
            if (feedbackTimer >= flashDuration && (isLeftPlayerShooting || isRightPlayerShooting))
            {
                isLeftPlayerShooting = false;
                isRightPlayerShooting = false;
            }
            else if (feedbackTimer >= soundDuration)
            {
                leftCannonSound.SetActive(false);
                rightCannonSound.SetActive(false);
            }
        }
    }

    private void leJoueurNumeroUnTireUnObusExplosif(){
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
    private void leJoueurNumeroDeuxTireUnObusExplosif(){
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



    public void LeftClick()
    {
        Debug.Log("left shoot");
        isLeftPlayerShooting = true;
        leJoueurNumeroUnTireUnObusExplosif();

        Feedback();
    }

    private void Feedback()
    {
        feedbackTimer = 0;
        if(isLeftPlayerShooting)
        {
            leftCannonSound.SetActive(true);
        }
        else if(isRightPlayerShooting)
        {
            rightCannonSound.SetActive(true);
        }

        #if UNITY_ANDROID
        Handheld.Vibrate();
        #endif
    }
}
