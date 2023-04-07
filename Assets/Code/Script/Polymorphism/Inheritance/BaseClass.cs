using UnityEngine;

// Abastract classes cannot exist without being inherited
// They are similar to interfaces, but can declare private / protected members
public abstract class BaseClass : MonoBehaviour {

    protected MeshRenderer _meshRenderer;
    public Material Material { get { return _meshRenderer.material; } set { _meshRenderer.material = value; } }

    public abstract void DoStuff();
}
// A non-abstract base class can be used when a more complex and more simple version of a script can coexist
// It can also have non-abstract methods, wich can have a definition, and doesn't have to be overriden