using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Dictionary<string, AgentAI> _spawnedCubes= new Dictionary<string, AgentAI>();
    
    public void AddAgent(string user, AgentAI agent)
    {
        _spawnedCubes.Add(user, agent);
    }

    public void CheckCube(string user)
    {
        if (_spawnedCubes.ContainsKey(user))
        {
        }
           
    }
}
