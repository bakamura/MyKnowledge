using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObserverCaller : MonoBehaviour {

    [SerializeField] private KeyCode _actionKey;
    private MeshRenderer _meshRenderer;
    [SerializeField] private Material[] _materials;
    public delegate void OnChangeMaterial();
    public List<OnChangeMaterial> onChangeMaterialList = new List<OnChangeMaterial>();
    public UnityEvent onChangeMaterialUnityEvent;

    private void Start() {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() {
        if (Input.GetKeyDown(_actionKey)) {
            _meshRenderer.material = _meshRenderer.material == _materials[0] ? _materials[1] : _materials[0];
            foreach(OnChangeMaterial invoked in onChangeMaterialList) invoked.Invoke();
            onChangeMaterialUnityEvent.Invoke();
        }
    }
}