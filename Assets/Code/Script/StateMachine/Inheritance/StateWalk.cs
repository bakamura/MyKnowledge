using UnityEngine;

// In this state, the object will walk in a random horizontal direction
// After going to edges 3 times, it changes state to StateRun
public class StateWalk : StateBase {

    public StateWalk(GameObject affectedObj) : base(affectedObj) {}

    private Vector3 _direction;
    private int _edgeCount = 0;

    protected override void OnEnterState() {
        _gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    public override void OnStayState() {
        _gameObject.transform.position += _direction * Time.deltaTime;

        if (!Physics.Raycast(_gameObject.transform.position + _direction * 0.55f, Vector3.down, 1.1f)) {
            _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            _edgeCount++;
        }
    }

    // Must be implemented because it's inheriting from base class
    protected override void OnExitState() {}

    // Contains every condition and wich state to go
    public override StateBase ConditionNextState() {
        if (_edgeCount > 2) {
            OnExitState();
            return new StateRun(_gameObject);
        }
        return null;
    }
}