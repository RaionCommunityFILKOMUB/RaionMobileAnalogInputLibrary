using System.Reflection;
using System;

using UnityEngine;
using UnityEngine.UI;

namespace raion {
public class MobileInputAnalog : MonoBehaviour {
  private void Start() { this.Setup(); }
  
  private void Update() {
    this.direction = this.mobileInputAnalogUI.GetDirection();
  }
  
  private MobileInputAnalogCanvas mobileInputAnalogCanvas;
  private MobileInputAnalogUI mobileInputAnalogUI;
  private void Setup() {
    this.mobileInputAnalogCanvas = MobileInputAnalogHelper
                                   .Instantiator
                                   .InstantiateAsComponent<MobileInputAnalogCanvas>();
                                   
    this.mobileInputAnalogUI = MobileInputAnalogHelper
                               .Instantiator
                               .InstantiateAsComponent<MobileInputAnalogUI>();
    this.mobileInputAnalogUI.SetMobileInputAnalogCanvas(this.mobileInputAnalogCanvas);
  }
  
  private Vector2 direction;
  public Vector2 GetDirection() { return this.direction; }
  
  private static MobileInputAnalog instance;
  public static MobileInputAnalog GetInstance() {
    if (MobileInputAnalog.instance == null) {
      MobileInputAnalog.instance =
        (new GameObject(typeof(MobileInputAnalog).FullName))
        .AddComponent<MobileInputAnalog>();
    }
    
    return MobileInputAnalog.instance;
  }
}
}