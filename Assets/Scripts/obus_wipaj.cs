using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obus_wipaj : MonoBehaviour
{
    [SerializeField] private float altitude = -5.0f;
    private int layer_ground;


    void Start()
    {
        // Initialize the ground layer once, for example by getting the layer by name
        layer_ground = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < altitude)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == layer_ground){
            Destroy(gameObject);
        }
    }
}
