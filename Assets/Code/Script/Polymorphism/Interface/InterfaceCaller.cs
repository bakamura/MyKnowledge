using System.Collections.Generic;
using UnityEngine;

// This script will, on key press, detect near interfaced objects,
// then call their actions
public class InterfaceCaller : MonoBehaviour {

    [SerializeField] private KeyCode _doKey;
    [SerializeField] private float _detectRadius;
    [SerializeField] private Material[] _materialSwap = new Material[2];

    private void Update() {
        if (Input.GetKeyDown(_doKey)) CallIInterface();
    }

    private void CallIInterface() {
        Collider[] hits = Physics.OverlapSphere(transform.position, _detectRadius);
        for (int i = 0; i < hits.Length; i++) {
            IInterface iInterface = hits[i].GetComponent<IInterface>();
            if (iInterface != null) {
                iInterface.DoStuff();
                iInterface.Material = iInterface.Material == _materialSwap[0] ? _materialSwap[1] : _materialSwap[0];
            }
        }
    }
}