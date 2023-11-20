using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{[SerializeField]private float speed =2f;
//only to rotate the saw 360
    private void Update()
    {
        transform.Rotate(0,0,360*speed*Time.deltaTime);
    }
}
