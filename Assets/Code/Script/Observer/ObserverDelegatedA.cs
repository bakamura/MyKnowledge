using UnityEngine;

public class ObserverDelegatedA : MonoBehaviour {

    [SerializeField] private ObserverCaller objToObserve;
    private Rigidbody _rb;
    [SerializeField] private float _jumpStrenght;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        objToObserve.onChangeMaterialList.Add(DoStuff);
    }

    public void DoStuff() {
        _rb.velocity = Vector3.up * _jumpStrenght;
    }
}