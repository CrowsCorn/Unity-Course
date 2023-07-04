using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(ui == null)
    {
    Debug.Log("UI REFERENCES");
    ui = gameObject.GetComponent<UI>();
    }
    }
    public int score;
    public UI ui;
    // Update is called once per frame
    void Update()
    {
        


    }


    public void addScore (int amount)
        {
            score += amount;
            ui.SetScoreTest(score);
            Debug.Log(score);
        }



}

