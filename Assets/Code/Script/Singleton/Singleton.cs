using UnityEngine;

// Some people consider singletons "Evil" and "Anti-OOP"
// They're dumb (imo lol)

// This singleton doesn't have a condition to instantiate itself, as monobehaviours can be attached to any "GameObject"
// Singletons prevent the existance of copies of an object of a specific type
// [where] specifies that "T" must derive from "MonoBehaviour"
// The remaining Singleton will always be the most bellow in the hierarchy
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T _instance;
    public static T Instance { get { return _instance; } }

    protected void Awake() { 
        if (_instance == null) _instance = this as T;
        else if (_instance != this) Destroy(gameObject);
    }

}
