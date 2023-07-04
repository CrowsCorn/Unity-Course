using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    void start()
    {
    if(ui == null)
    {
    Debug.Log("UI REFERENCES");
    ui = gameObject.GetComponent<UI>();
    }
    }
    public float moveSpeed;
    public Rigidbody rig;
    public float JumpForce;
    private bool isGrounded;
    public int score;
    public UI ui;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        } //allows the character to jump using space key and sets status as on the floor as false preventing the character from jumping again
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
    
        {   isGrounded = false;
            rig.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

        }
        if(transform.position.y < -10)
        {
            GameOver();
        }
    }   //checks if chracter is touching the floor
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.contacts[0].normal == Vector3.up)
            {
                isGrounded = true;
            }
        }
        //this restarts the scene if the player dies
        public void GameOver()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }     

        public void addScore (int amount)
        {
            score += amount;
            ui.SetScoreTest(score);
        }
      
   
}