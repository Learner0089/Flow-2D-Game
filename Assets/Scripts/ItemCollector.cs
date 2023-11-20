using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries =0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource CollectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Cherry")){
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);//to destroy the object
            cherries++;//count it
            cherriesText.text = "Cherries:" +cherries;
        }
    }
}
