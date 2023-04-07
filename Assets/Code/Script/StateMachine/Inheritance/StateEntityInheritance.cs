using UnityEngine;

// This object will be assigned states, and will call their methods
public class StateEntityInheritance : MonoBehaviour {

    private StateBase _currentState;

    private void Awake() {
        _currentState = new StateIdle(gameObject);
    }
    
    // Calls that state "Update"
    // Then checks if state change conditions are met
    private void Update() {
        _currentState.OnStayState();

        StateBase nextState = _currentState.ConditionNextState();
        if (nextState != null) _currentState = nextState; // Does not destroy previous object
    }
}