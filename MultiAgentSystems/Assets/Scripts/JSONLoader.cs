using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class JSONLoader : MonoBehaviour
{
    private string url = "http://127.0.0.1:8000/getPositions";
    private MyData jsonData;
    public float tiempoEspera = 5f; // Tiempo de espera entre solicitudes en segundos

    public Light[] Alight; // Arreglo para almacenar las referencias a las luces verdes
    public Light[] Blight; // Arreglo para almacenar las referencias a las luces rojas

    // Método para cambiar el color de un grupo de luces
    public void CambiarColorGrupo(Light[] grupoLuces, Color nuevoColor)
    {
        foreach (Light luz in grupoLuces)
        {
            luz.color = nuevoColor; // Asignar el nuevo color a cada luz en el arreglo
        }
    }

    IEnumerator Start()
    {
        while (true)
        {
            // Crear la solicitud POST
            WWWForm form = new WWWForm();
            UnityWebRequest request = UnityWebRequest.Post(url, form);

            // Enviar la solicitud y esperar la respuesta
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al obtener los datos: " + request.error);
            }
            else
            {
                // Procesar y mostrar los datos del JSON recibido
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Datos recibidos: " + jsonResponse);

                // Aquí puedes parsear el JSON y trabajar con los datos
                // Por ejemplo, puedes usar JsonUtility para convertir el JSON en objetos C#
                // Deserializar el JSON a una clase adecuada
                MyData data = JsonUtility.FromJson<MyData>(jsonResponse);

                // Ahora puedes acceder a los datos como objetos C#
                foreach (var car in data.cars)
                {
                    Debug.Log("Car ID: " + car.car_id);
                    Debug.Log("Position: x=" + car.position.x + ", z=" + car.position.z);
                    Debug.Log("Current Direction: x=" + car.current_direction.x + ", z=" + car.current_direction.z);
                }

                foreach (var stoplight in data.stoplights)
                {
                    Debug.Log("Stop Type: " + stoplight.stop_type);
                    Debug.Log("Color: " + stoplight.color);

                    // Cambiar el color de las luces según los datos del JSON
                    if (stoplight.stop_type == "A")
                    {
                        if (stoplight.color == "green")
                        {
                            CambiarColorGrupo(Alight, Color.green);
                        }
                        else if (stoplight.color == "red")
                        {
                            CambiarColorGrupo(Alight, Color.red);
                        }
                    }
                    else if (stoplight.stop_type == "B")
                    {
                        if (stoplight.color == "green")
                        {
                            CambiarColorGrupo(Blight, Color.green);
                        }
                        else if (stoplight.color == "red")
                        {
                            CambiarColorGrupo(Blight, Color.red);
                        }
                    }
                }

                // Guardar los datos del JSON
                jsonData = data;
            }

            yield return new WaitForSeconds(tiempoEspera); // Esperar antes de la siguiente solicitud
        }
    }

    // Clase para almacenar los datos del JSON
    [System.Serializable]
    public class MyData
    {
        public CarData[] cars;
        public StoplightData[] stoplights;
    }

    [System.Serializable]
    public class CarData
    {
        public int car_id;
        public PositionData position;
        public DirectionData current_direction;
    }

    [System.Serializable]
    public class PositionData
    {
        public float x;
        public float z;
    }

    [System.Serializable]
    public class DirectionData
    {
        public float x;
        public float z;
    }

    [System.Serializable]
    public class StoplightData
    {
        public string stop_type;
        public string color;
    }
}
