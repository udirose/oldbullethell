using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform laserPosition;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        lineRenderer.SetPosition(0,laserPosition.position);
        lineRenderer.SetPosition(1, hit.point);
    }
}
