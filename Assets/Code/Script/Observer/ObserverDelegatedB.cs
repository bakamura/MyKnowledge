using UnityEngine;

public class ObserverDelegatedB : MonoBehaviour {

    [SerializeField] private ObserverCaller objToObserve;
    private Rigidbody _rb;
    [SerializeField] private float _spinStrength;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        objToObserve.onChangeMaterialList.Add(DoStuff);
    }

    public void DoStuff() {
        _rb.angularVelocity = Vector3.up * _spinStrength;
    }
}