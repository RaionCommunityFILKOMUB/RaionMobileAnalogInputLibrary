using System;

using UnityEngine;
using UnityEngine.UI;

namespace raion {
public class MobileInputAnalogUI : MonoBehaviour {
  public static float scale = 0.375f;

  private void Start() {
    this.Setup();
  }

  private void Update() {
    this.canvasSize =
      this.GetMobileInputAnalogCanvas().GetRectTransform().sizeDelta;

    if (Input.touchCount > 0 ||
        (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0))) {
      this.direction = ((foreground.GetRectTransform().anchoredPosition
                         - background.GetRectTransform().anchoredPosition)
                        / background.GetRectTransform().sizeDelta.x)
                       * 2.0f;
      this.direction = Vector2.ClampMagnitude(this.direction, 1.0f);
    } else {
      this.direction.x = 0.0f;
      this.direction.y = this.direction.x;
    }
  }

  public static string pathSpriteCircle =
    "raion/MobileInputAnalog/Sprites/Raion.MobileInputAnalog.Sprite.Circle";

  private MobileInputAnalogUIBackground background;
  public MobileInputAnalogUIBackground GetBackground() {
    if (this.background == null) {
      this.background = MobileInputAnalogHelper
                        .Instantiator
                        .InstantiateAsComponent<MobileInputAnalogUIBackground>();
      this.background.SetMobileInputAnalogUI(this);
    }

    return this.background;
  }

  private MobileInputAnalogUIForeground foreground;
  public MobileInputAnalogUIForeground GetForeground() {
    if (this.foreground == null) {
      this.foreground = MobileInputAnalogHelper
                        .Instantiator
                        .InstantiateAsComponent<MobileInputAnalogUIForeground>();
      this.foreground.SetMobileInputAnalogUI(this);
      this.foreground.SetBackground(this.GetBackground());
    }

    return this.foreground;
  }

  private void Setup() {
    MobileInputAnalogHelper.AddComponentsGameObject(
      new Type[] {typeof(UnityEngine.RectTransform)
                 },
      this.gameObject);

    this.rectTransform = this.GetRectTransform();
    this.background = this.GetBackground();
    this.foreground = this.GetForeground();
  }

  private MobileInputAnalogCanvas mobileInputAnalogCanvas;
  public void SetMobileInputAnalogCanvas(MobileInputAnalogCanvas
                                         mobileInputAnalogCanvas) {
    this.mobileInputAnalogCanvas = mobileInputAnalogCanvas;
    this.transform.SetParent(this.mobileInputAnalogCanvas.transform);
  }

  public MobileInputAnalogCanvas GetMobileInputAnalogCanvas() {
    return this.mobileInputAnalogCanvas;
  }

  private RectTransform rectTransform;
  public RectTransform GetRectTransform() {
    if (this.rectTransform == null) {
      this.rectTransform =
        this.gameObject.GetComponent<RectTransform>() == null
        ? this.gameObject.AddComponent<RectTransform>()
        : this.gameObject.GetComponent<RectTransform>();
    }

    return this.rectTransform;
  }

  private Vector2 direction;
  public Vector2 GetDirection() {
    return this.direction;
  }

  private Vector2 canvasSize;
  public Vector2 GetCanvasSize() {
    return this.canvasSize;
  }
}
}