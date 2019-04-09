using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent startTrigger;
    public UnityEngine.Events.UnityEvent spawnTrigger;
    public int score;

    ScoreManager sm;


    // Start is called before the first frame update
    void Start()
    {
        score = sm.getScore();
    }

    // Update is called once per frame
    void Update()
    {
        score = sm.getScore();

        if (Input.GetKeyDown(KeyCode.Return))
            startTrigger.Invoke(); ;

        if (score == 1 || score == 3 || score == (score + 5))
            spawnTrigger.Invoke();
    }
}
