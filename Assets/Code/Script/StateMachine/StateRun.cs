using UnityEngine;

public class StateRun : StateBase {

    public StateRun(GameObject affectedObj) : base(affectedObj) {}

    private Vector3 _direction;

    protected override void OnEnterState() {
        _gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    public override void OnStayState() {
        _gameObject.transform.position += _direction * Time.deltaTime * 2;
    }

    protected override void OnExitState() {}

    public override StateBase ConditionNextState() {
        if (!Physics.Raycast(_gameObject.transform.position + _direction * 0.55f, Vector3.down, 1.1f)) return new StateIdle(_gameObject);
        return null;
    }
}