using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{//to make camera move when we are on moving platform with the player otherwise have to move it with keys
    private void OnTriggerEnter2D(Collider2D collision){
       if(collision.gameObject.name == "Player"){
        collision.gameObject.transform.SetParent(transform);
    }
    }
//to make player not stick to platform form sidelines
    private void OnCollisionExit2D(Collision2D collision)
    {
      if(collision.gameObject.name == "Player"){
        collision.gameObject.transform.SetParent(null);
    }
    }
}
