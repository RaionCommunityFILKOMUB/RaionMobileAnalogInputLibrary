using System;

using UnityEngine;
using UnityEngine.UI;

namespace raion.MobileInputAnalog.Internal {
  public class Canvas : MonoBehaviour {
    private void Start() {
      this.Setup();
    }

    private void Setup() {
      this.gameObject.layer = LayerMask.NameToLayer("UI");

      Helper.AddComponentsGameObject(
        new Type[] {typeof(UnityEngine.RectTransform),
                    typeof(UnityEngine.Canvas),
                    typeof(UnityEngine.UI.CanvasScaler),
                    typeof(UnityEngine.UI.GraphicRaycaster)
                   },
        this.gameObject);

      canvas = this.gameObject.GetComponent<UnityEngine.Canvas>();
      canvas.renderMode = RenderMode.ScreenSpaceOverlay;

      transform.SetAsFirstSibling();
    }

    private UnityEngine.Canvas canvas;
    public UnityEngine.Canvas GetCanvas() {
      return this.canvas;
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
  }
}
