using UnityEngine;

public class StateEntity : MonoBehaviour {

    private StateBase _currentState;

    private void Awake() {
        _currentState = new StateIdle(gameObject);
    }

    private void Update() {
        _currentState.OnStayState();

        StateBase nextState = _currentState.ConditionNextState();
        if (nextState != null) _currentState = nextState; // Does not destroy previous object
    }
}