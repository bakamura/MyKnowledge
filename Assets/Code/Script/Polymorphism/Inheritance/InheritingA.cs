using UnityEngine;

// Object A jumps when called
// This version uses an inheritance
// Inheriting objects can have any other parameters and values
// They may inherit from only one class
public class InheritingA : BaseClass {

    private Rigidbody _rb;
    [SerializeField] private float _jumpStrenght;

    private void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }

    // Not only must be defined, but also must override base's declaration
    public override void DoStuff() {
        _rb.velocity = Vector3.up * _jumpStrenght;
    }
}
