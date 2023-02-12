using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class genPeople : MonoBehaviour
{
    public int peopleAtStation;
    public int timeUntilNextPerson;
    public int maxTimeUntilNextPerson = 100;
    System.Random rnd;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        peopleAtStation = rnd.Next(0, 50);
        timeUntilNextPerson = rnd.Next(0, 500);  
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextPerson -= 1;
        if(timeUntilNextPerson <= 0)
        {
            peopleAtStation ++; 
            timeUntilNextPerson = rnd.Next(0, maxTimeUntilNextPerson); 
        }
    }
}
