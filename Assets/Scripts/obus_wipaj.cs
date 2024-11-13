using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obus_wipaj : MonoBehaviour
{
    [SerializeField] private float altitude = -5.0f;


    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < altitude)
        {
            Destroy(gameObject);
        }
    }
}
