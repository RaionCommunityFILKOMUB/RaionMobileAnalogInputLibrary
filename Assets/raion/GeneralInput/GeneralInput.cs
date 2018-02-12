using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace raion {
public class GeneralInput : MonoBehaviour {
  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
    }
  }
  
  private static GeneralInput instance;
  public static GeneralInput GetInstance() {
    if (GeneralInput.instance == null) {
      GeneralInput.instance =
        (new GameObject(typeof(GeneralInput).FullName))
        .AddComponent<GeneralInput>();
    }
    
    return GeneralInput.instance;
  }
}
}