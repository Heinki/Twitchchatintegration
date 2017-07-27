using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour {

    private NavMeshAgent _navmeshAgent;
    private string _user;
    private Transform _waypoint;
    
    void Start()
    {
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    public void setUser(string user)
    {
        this._user = user;
    }
}
