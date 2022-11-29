using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotateAngle;
    private void Update()
    {
        transform.Rotate(rotateAngle * Time.deltaTime);
    }
}
