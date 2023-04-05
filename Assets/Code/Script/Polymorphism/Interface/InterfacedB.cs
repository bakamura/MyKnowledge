using UnityEngine;

// Object B spins when called
// This version uses an interface
// Interfaced objects can have any other parameters and values
// They may also inherit more than one interface
public class InterfacedB : MonoBehaviour, IInterface {

    private MeshRenderer _meshRenderer;
    public Material Material { get { return _meshRenderer.material; } set { _meshRenderer.material = value; } }
    private Rigidbody _rb;
    [SerializeField] private float _spinStrength;

    private void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }

    public void DoStuff() {
        _rb.angularVelocity = Vector3.up * _spinStrength;
    }
}
