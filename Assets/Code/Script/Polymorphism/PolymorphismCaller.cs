using UnityEngine;

// This script will, on key press, detect near interfaced objects,
// then call their actions
public class PolymorphismCaller : MonoBehaviour {

    [SerializeField] private KeyCode _doKey;
    [SerializeField] private float _detectRadius;
    [SerializeField] private Material[] _materialSwap = new Material[2];

    private void Update() {
        if (Input.GetKeyDown(_doKey)) CallIInterface();
    }

    private void CallIInterface() {
        Collider[] hits = Physics.OverlapSphere(transform.position, _detectRadius);
        IInterface iInterface;
        BaseClass baseClass;
        for (int i = 0; i < hits.Length; i++) {
            iInterface = hits[i].GetComponent<IInterface>();
            if (iInterface != null) { // Could be done with TryGetComponent() but is (probably) less performative
                iInterface.DoStuff();
                iInterface.Material = iInterface.Material.color == _materialSwap[0].color ? _materialSwap[1] : _materialSwap[0];
            }
            baseClass = hits[i].GetComponent<BaseClass>();
            if (baseClass != null) { // Could be done with TryGetComponent() but is (probably) less performative
                baseClass.DoStuff(); // Different method from iInterface, with the same name
                baseClass.Material = baseClass.Material.color == _materialSwap[0].color ? _materialSwap[1] : _materialSwap[0];
            }
        }
    }
}