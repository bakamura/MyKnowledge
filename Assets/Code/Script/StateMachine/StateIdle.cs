using UnityEngine;

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

    protected override void OnExitState() {}

    public override StateBase ConditionNextState() {
        if (_duration > _maxDuration) {
            OnExitState();
            return new StateWalk(_gameObject);
        }
        return null;
    }
}