using UnityEngine;

// Object A jumps when called
// This version uses the UnityEvent
public class ObserverUEventedA : MonoBehaviour {

    [SerializeField] private ObserverCaller objToObserve;
    private Rigidbody _rb;
    [SerializeField] private float _jumpStrenght;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        objToObserve.onChangeMaterialUnityEvent.AddListener(DoStuff);
    }

    public void DoStuff() {
        _rb.velocity = Vector3.up * _jumpStrenght;
    }
}
