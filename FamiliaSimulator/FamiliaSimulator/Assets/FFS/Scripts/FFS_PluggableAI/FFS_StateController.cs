using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFS_StateController : MonoBehaviour {

    public FFS_CharacterStats enemyStats;
    public FFS_State currentState;
    public FFS_State remainState;

    public List<Transform> waypointList;

    [HideInInspector] public int nextWaypoint;
    [HideInInspector] public Transform transformComponent;

    private bool aiActive = true;


    private void Awake()
    {
        enemyStats = GetComponent<FFS_CharacterStats>();

        transformComponent = transform;
    }

    private void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    public void TransitionToState(FFS_State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
