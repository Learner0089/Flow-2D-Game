using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
   [SerializeField] private Transform player;
    private void Update()
    {
        //player.position.x or y to follow player
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
        //z can be put -10 directly but this way is more flexible
    }
}
