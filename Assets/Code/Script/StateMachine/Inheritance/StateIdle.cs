using UnityEngine;

// In this state, the object will stay still
// After _maxDuration seconds, it changes do StateWalk
public class StateIdle : StateBase {

    public StateIdle(GameObject affectedObj) : base(affectedObj) {}

    private float _duration = 0f;
    private float _maxDuration = 3f;

    protected override void OnEnterState() {
        _gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public override void OnStayState() {
        _duration += Time.deltaTime;
    }

    // Must be implemented because it's inheriting from base class
    protected override void OnExitState() {}

    // Contains every condition and wich state to go
    public override StateBase ConditionNextState() {
        if (_duration >= _maxDuration) {
            OnExitState();
            return new StateWalk(_gameObject);
        }
        return null;
    }
}