using UnityEngine;

// Object A jumps when called
// This version uses an interface
// Interfaced objects can have any other parameters and values
// They may also inherit more than one interface
public class InterfacedA : MonoBehaviour, IInterface {

    private MeshRenderer _meshRenderer;
    public Material Material { get { return _meshRenderer.material; } set { _meshRenderer.material = value; } }
    private Rigidbody _rb;
    [SerializeField] private float _jumpStrenght;

    private void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }

    public void DoStuff() {
        _rb.velocity = Vector3.up * _jumpStrenght;
    }
}
