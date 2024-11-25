using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    [SerializeField] private GameObject leftPlayerTank, rightPlayerTank;
    [SerializeField] private float minHeight = 4f, maxHeight = 35f;
    [SerializeField] private float zoomFactor = 1f;
    [SerializeField] private float offsetY = 2f;

    void Update()
    {
        if (leftPlayerTank != null && rightPlayerTank != null)
        {
            Vector3 midpoint = (leftPlayerTank.transform.position + rightPlayerTank.transform.position) / 2f;
            float distanceBetweenTanks = Vector3.Distance(leftPlayerTank.transform.position, rightPlayerTank.transform.position);
            float adjustedY = Mathf.Clamp(distanceBetweenTanks * zoomFactor + offsetY, minHeight, maxHeight);
            transform.position = new Vector3(midpoint.x, adjustedY, midpoint.z);
        }
    }
}
