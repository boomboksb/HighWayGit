using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public void FixedUpdate()
    {
        transform.Rotate(0, 0.5f, 0);
    }
}
