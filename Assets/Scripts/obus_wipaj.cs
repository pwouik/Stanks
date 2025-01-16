using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obus_wipaj : MonoBehaviour
{
    [SerializeField] private float altitude = -5.0f;
    [SerializeField] private GameObject explode;
    [HideInInspector] public FireButtonPress gameScript; //todo nom de la classe
    private int layer_ground;
    private float explodeDuration = 2f;


    void Start()
    {
        // Initialize the ground layer once, for example by getting the layer by name
        layer_ground = LayerMask.NameToLayer("ground");
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(transform.position+GetComponent<Rigidbody>().velocity);
        if (transform.position.y < altitude)
        {
            Debug.Log("reached the void");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("maybe kaboom"); //torm
        if(other.gameObject.layer == layer_ground){
            Debug.Log("kaboom"); //torm
            
            //instantiate and delete explosion after it's delay
            GameObject boom = Instantiate(explode, gameScript.explodeParent);
            Destroy(boom, explodeDuration);

            //herit coordinate
            boom.transform.position = transform.position;
            boom.transform.localScale = new Vector3(3,3,3);

            //forcard explosion coordinate to game
            gameScript.handleExplosionAtPosition(transform.position);

            //delete obus
            Destroy(gameObject,0.5f); 
        }
    }
}
