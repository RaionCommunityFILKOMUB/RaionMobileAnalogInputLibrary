using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMobileInputAnalog : MonoBehaviour {
  private void Start() {
    raion.GeneralInput.GetInstance();
    raion.MobileInputAnalog.GetInstance();
  }
}
