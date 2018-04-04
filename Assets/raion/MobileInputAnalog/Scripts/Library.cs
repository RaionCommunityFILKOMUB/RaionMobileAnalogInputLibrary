using System.Reflection;
using System;

using UnityEngine;
using UnityEngine.UI;

using raion.MobileInputAnalog.Internal;

namespace raion.MobileInputAnalog {
  public class Library : MonoBehaviour {
    private
    void OnEnable() {
      this.Setup();
    }

    private
    void Update() {
      this.direction = this.mobileInputAnalogUI.GetDirection();
    }

    private
    MobileInputAnalog.Internal.Canvas mobileInputAnalogCanvas;

    private
    UI mobileInputAnalogUI;

    private
    void Setup() {
      this.mobileInputAnalogCanvas =
        Helper
        .Instantiator
        .InstantiateAsComponent<MobileInputAnalog.Internal.Canvas>();

      this.mobileInputAnalogUI =
        Helper
        .Instantiator
        .InstantiateAsComponent<UI>();

      this.mobileInputAnalogUI.SetMobileInputAnalogCanvas(
        this.mobileInputAnalogCanvas);

      transform.SetAsFirstSibling();
    }

    private
    Vector2 direction;

    public Vector2 GetDirection() {
      return this.direction;
    }

    private
    static
    Library instance_;

    public
    static
    Library GetInstance() {
      if (Library.instance_ == null) {
        Library.instance_ =
          (new GameObject(typeof(Library).FullName))
          .AddComponent<Library>();
      }

      return Library.instance_;
    }
  }
}
