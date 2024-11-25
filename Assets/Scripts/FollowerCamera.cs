using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    [SerializeField] private GameObject leftPlayerTank, rightPlayerTank;
    [SerializeField] private float minHeight = 6f, maxHeight = 64f;
    [SerializeField] private float zoomFactor = .7f;
    [SerializeField] private float offsetY = 6f;

    void Update()
    {
        if (leftPlayerTank == null || rightPlayerTank == null)
            return;

        Vector3 midpoint = (leftPlayerTank.transform.position + rightPlayerTank.transform.position) / 2f;
        float distanceBetweenTanks = Vector3.Distance(leftPlayerTank.transform.position, rightPlayerTank.transform.position);
        float adjustedY = Mathf.Clamp(distanceBetweenTanks * zoomFactor + offsetY, minHeight, maxHeight);
        transform.position = new Vector3(midpoint.x, adjustedY, midpoint.z);
    }
}
