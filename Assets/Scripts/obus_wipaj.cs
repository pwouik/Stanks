using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obus_wipaj : MonoBehaviour
{
    [SerializeField] private float altitude = -5.0f;
    [SerializeField] private GameObject explode;
    [HideInInspector] public Transform explodeParent;
    private int layer_ground;


    void Start()
    {
        // Initialize the ground layer once, for example by getting the layer by name
        layer_ground = LayerMask.NameToLayer("ground");
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < altitude)
        {
            Debug.Log("reached the void");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("maybe kaboom");
        if(other.gameObject.layer == layer_ground){
            Debug.Log("kaboom");
            GameObject boom = Instantiate(explode, explodeParent); //warning need to be deleted
            boom.transform.position = transform.position;
            boom.transform.localScale = new Vector3(3,3,3);
            Destroy(gameObject,0.5f);
        }
    }
}
