using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyAgents
{
    [System.Serializable]
public class Position
{
    public int x;
    public int z;
}

[System.Serializable]
public class Car
{
    public int car_id;
    public Position position;
    public Position current_direction;
}

[System.Serializable]
public class Stoplight
{
    public string stop_type;
    public string color;
}

[System.Serializable]
public class ReceivedData
{
    public List<Car> cars;
    public List<Stoplight> stoplights;
}

    
}
