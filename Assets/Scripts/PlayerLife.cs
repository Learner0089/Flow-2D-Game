using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource DeathSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.CompareTag("Trap")){
        Die();//will trigger death animation
    }
   }

   private void Die(){
    DeathSoundEffect.Play();
    rb.bodyType = RigidbodyType2D.Static;//This will make player static from dynamic ie will pause its movement
    anim.SetTrigger("Death");//Disapperaing animation trigger but player was still there
   }

   private void RestartLevel(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);//It is used to reload the game or current scene
   }
}
