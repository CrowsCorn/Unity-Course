using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionManager : MonoBehaviour
{

  
    Movement Controls;
    AudioSource Audio;
    [SerializeField] float LoadDelay = 5f;
    [SerializeField] AudioClip DeathNoise;
    [SerializeField] AudioClip Victory;
    [SerializeField] ParticleSystem Success;
    [SerializeField] ParticleSystem Failure;
    bool isTransitioning = false;

    void Start()
    {
      Controls = GetComponent<Movement>();
      Audio = GetComponent<AudioSource>();
    

    }

    void Update()
    {
        CheckDebugKeys();
    }
    void CheckDebugKeys()
    {
      if (Input.GetKeyDown(KeyCode.L))
      {
        NextLevel();
      }
    }
    void OnCollisionEnter(Collision other)
    {
      if(isTransitioning)
      {
        return;
      }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                PassSequence();
                break;
            case "Coin":
                Debug.Log("MONEE");
                break;
            default:
                FailSequence();
                break;
        }
    }
    void FailSequence()
    {
      isTransitioning = true;
      Audio.Stop();
      Controls.enabled = false;
      Audio.PlayOneShot(DeathNoise);
      Failure.Play();
      Invoke ("RestartLevel", LoadDelay);

    }

    void PassSequence()
    {
      isTransitioning = true;
      Audio.Stop();
      Controls.enabled = false;
      Audio.PlayOneShot(Victory);
      Success.Play();
      Invoke("NextLevel", LoadDelay);
    }
    
    void RestartLevel()
    {
      int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(CurrentSceneIndex);
    }
    void NextLevel()
    {
      int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      int nextSceneIndex = CurrentSceneIndex + 1;
      if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
      {
        nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
      }
      else 
      {
         SceneManager.LoadScene(nextSceneIndex);
      }
    }
}

