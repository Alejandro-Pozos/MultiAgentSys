using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcessor : MonoBehaviour
{
    void Start()
    {
        // Acceder a los datos desde el Singleton DataManager
        JSONLoader.MyData data = DataManager.Instance.jsonData;

        // Hacer uso de los datos obtenidos
        if (data != null)
        {
            foreach (var car in data.cars)
            {
                Debug.Log("Car ID: " + car.car_id);
                // Acceder a otros datos de los coches según sea necesario
            }

            foreach (var stoplight in data.stoplights)
            {
                Debug.Log("Stop Type: " + stoplight.stop_type);
                // Acceder a otros datos de los semáforos según sea necesario
            }
        }
    }
}

