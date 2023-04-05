using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// For this project, we will be pooling bullets, shot by the player
public class ObjectPooling : MonoBehaviour {

    [SerializeField] private GameObject _objectToPool;
    private List<GameObject> _objectPool = new List<GameObject>();
    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private Vector3 _shootOffset;
    [SerializeField] private Vector3 _shootDirection;
    [SerializeField] private float _delayDeactivate;
    private WaitForSeconds _deactivateWait;

    private void Awake() {
        GameObject go = Instantiate(_objectToPool, Vector3.zero, Quaternion.identity);
        go.SetActive(false);
        _objectPool.Add(go);

        _deactivateWait = new WaitForSeconds(_delayDeactivate);
    }

    private void Update() {
        if (Input.GetKeyDown(_shootKey)) Shoot();
    }

    // Check if an object is available to activate, and do so
    // Else, instantiate one and add it to the pool
    private void Shoot() {
        foreach (GameObject obj in _objectPool) if (!obj.activeSelf) {
                ActivateObject(obj);
                return;
            }
        GameObject go = Instantiate(_objectToPool, transform.position + _shootOffset, Quaternion.identity);
        _objectPool.Add(go);
        ActivateObject(go);

    }

    private void ActivateObject(GameObject obj) {
        obj.SetActive(true);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.position = transform.position + _shootOffset;
        rb.velocity = _shootDirection;
        rb.angularVelocity = _shootDirection;
        StartCoroutine(DeactivateObject(obj));
    }

    private IEnumerator DeactivateObject(GameObject obj) {
        yield return _deactivateWait;

        obj.SetActive(false);
    }
}
