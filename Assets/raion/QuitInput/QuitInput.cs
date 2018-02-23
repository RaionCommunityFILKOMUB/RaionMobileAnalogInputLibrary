using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace raion {
public class QuitInput : MonoBehaviour {
  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
    }
  }

  private static QuitInput instance;
  public static QuitInput GetInstance() {
    if (QuitInput.instance == null) {
      QuitInput.instance =
        (new GameObject(typeof(QuitInput).FullName))
        .AddComponent<QuitInput>();
    }

    return QuitInput.instance;
  }
}
}