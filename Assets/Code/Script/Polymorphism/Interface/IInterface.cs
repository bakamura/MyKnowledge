using UnityEngine;

// Interfaces let us declare the existence of parameters and methods
// The inheriting classes must implement all these parameters and methods
public interface IInterface {

    Material Material { get; set; }

    void DoStuff();
}
