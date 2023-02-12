using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StationEvents : MonoBehaviour
{
    public delegate void Arrival(int percentage);
    public static event Arrival OnArrival;

    public float contactTimer;
    public float contactTime;
    public int passengerPercentage;
    public bool atTheStation;

    public int maxPassengers;
    public int Passengers;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        contactTimer = 0f;
        
        passengerPercentage = 55;
        atTheStation = false;
    }

    void TrainIsHere(int percentage)
    {
        if (atTheStation == false)
        {
            atTheStation=true;
            Debug.Log("Train is at the station");
            int movement = (int) Math.Round(Passengers * percentage / 100f);
            Passengers -= movement;
        }
    }

    void OnEnable()
    {
        StationEvents.OnArrival += TrainIsHere;
    }

    void OnDisable()
    {
        StationEvents.OnArrival -= TrainIsHere;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    void OnTriggerStay(Collider other)
    {
        if (other){
            contactTimer += Time.deltaTime;
            if (contactTimer >= contactTime) {
                OnArrival(passengerPercentage);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other){
            contactTimer = 0;
            atTheStation=false;
        }
    }
}
