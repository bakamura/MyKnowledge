using UnityEngine;

// This version uses a switch() to decide wich behaviour to reproduce
// The effects will be exactly equal to the Inheritance based version
// Condition to change State could be multiple, but for simplicity sake its only one
public class StateEntitySwitch : MonoBehaviour {

    private enum State {
        Idle,
        Walk,
        Run
    }
    private State _currentState = State.Idle;
    private delegate void BehaviourMethod();

    private MeshRenderer _meshRenderer;
    [SerializeField, Tooltip("Idle, Walk, Run")] private Material[] _stateMaterial;

    [Header("Idle")]

    [SerializeField] private float _maxDuration;
    private float _duration = 0f;

    [Header("Walk / Run")]
    private Vector3 _direction;
    private int _edgeCount = 0;

    private void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // One caller for GetStateBehaviour, other for the method it returned
    private void Update() {
        GetStateBehaviour()();
    }

    // Added for code readability
    private void ChangeState(State stateToGo) {
        _currentState = stateToGo;
        GetStateStart()();
    }

    #region BehaviourStart
    private BehaviourMethod GetStateStart() {
        switch (_currentState) {
            case State.Idle: return OnIdleStart;
            case State.Walk: return OnWalkStart;
            case State.Run: return OnRunStart;
            default:
                Debug.Log("Error: " + gameObject.name + " Behaviour is set to null!");
                return null;
        }
    }

    private void OnIdleStart() {
        _meshRenderer.material = _stateMaterial[0];
        _duration = 0;
    }

    private void OnWalkStart() {
        _meshRenderer.material = _stateMaterial[1];
        _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        _edgeCount = 0;
    }

    private void OnRunStart() {
        _meshRenderer.material = _stateMaterial[2];
        _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }
    #endregion

    #region BehaviourStay
    private BehaviourMethod GetStateBehaviour() {
        switch (_currentState) {
            case State.Idle: return OnIdleStay;
            case State.Walk: return OnWalkStay;
            case State.Run: return OnRunStay;
            default:
                Debug.Log("Error: " + gameObject.name + " Behaviour is set to null!");
                return null;
        }
    }

    private void OnIdleStay() {
        // Behaviour
        _duration += Time.deltaTime;

        // Condition to change State
        if (_duration >= _maxDuration) ChangeState(State.Walk);
    }

    private void OnWalkStay() {
        // Behaviour
        transform.position += _direction * Time.deltaTime;

        if (!Physics.Raycast(transform.position + _direction * 0.55f, Vector3.down, 1.1f)) {
            _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            _edgeCount++;
        }

        // Condition to change State
        if (_edgeCount > 2) ChangeState(State.Run);
    }

    private void OnRunStay() {
        // Behaviour
        transform.position += _direction * Time.deltaTime * 2;

        // Condition to change State
        if (!Physics.Raycast(transform.position + _direction * 0.55f, Vector3.down, 1.1f)) ChangeState(State.Idle);
    }
    #endregion
}