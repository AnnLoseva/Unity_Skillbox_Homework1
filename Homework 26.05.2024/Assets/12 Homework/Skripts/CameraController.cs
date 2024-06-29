using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - ballTransform.position;
    }

    void Update()
    {
        transform.position = ballTransform.position + offset;
    }
}
