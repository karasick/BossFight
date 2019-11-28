using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    // Current Latitude
    public float Latitude;
    // Current Longitude
    public float Longitude;
    // Current Altitude
    public float Altitude;
    // Current HorizontalAccuracy
    public float HorizontalAccuracy;
    // Current Timestamp
    public double Timestamp;

    void Start()
    {
        Instance = this;
        StartCoroutine(StartLocationService());
    }

    IEnumerator StartLocationService()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            Latitude = Input.location.lastData.latitude;
            Longitude = Input.location.lastData.longitude;
            Altitude = Input.location.lastData.altitude;
            HorizontalAccuracy = Input.location.lastData.horizontalAccuracy;
            Timestamp = Input.location.lastData.timestamp;

            // Access granted and location value could be retrieved
            Debug.Log("Location:\nLatitude:" + Latitude + " Longitude:" + Longitude + " Altitude:" + Altitude + " HorizontalAccuracy:" + HorizontalAccuracy + " Timestamp:" + Timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();

        yield break;
    }
}