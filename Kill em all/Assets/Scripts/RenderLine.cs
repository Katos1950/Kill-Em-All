using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lineRenderer.SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
