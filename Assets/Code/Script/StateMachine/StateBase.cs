using UnityEngine;

public abstract class StateBase {

    public StateBase(GameObject affectedObj) {
        _gameObject = affectedObj;
        OnEnterState();
    }

    protected GameObject _gameObject;
    [SerializeField] protected Material _stateMat;

    protected abstract void OnEnterState();
    public abstract void OnStayState();
    protected abstract void OnExitState();
    public abstract StateBase ConditionNextState();
}