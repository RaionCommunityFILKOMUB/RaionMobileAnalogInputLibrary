using System;

using UnityEngine;
using UnityEngine.UI;

namespace raion.MobileInputAnalog.Internal {
  public class UIBackground : MonoBehaviour {
    private void OnEnable() {
      this.Setup();
    }

    private void EditorUpdate() {
      if (Input.GetMouseButtonDown(0)) {
        Vector2 position = Input.mousePosition;
        position -= canvasSize * 0.5f;

        this.GetRectTransform().anchoredPosition = position;
      }

      this.SetImageAlpha(
        this.GetMobileInputAnalogUI()
        .GetForeground()
        .GetImageAlpha() == 0.0f ? 0.0f : 0.3f);
    }

    private void NonEditorUpdate() {
      if (Input.touchCount > 0) {
        if (Input.GetTouch(0).phase == TouchPhase.Began) {
          Vector2 position = Input.GetTouch(0).position;
          position -= canvasSize * 0.5f;

          this.GetRectTransform().anchoredPosition = position;
        }
      }

      this.SetImageAlpha(
        this.GetMobileInputAnalogUI()
        .GetForeground()
        .GetImageAlpha() == 0.0f ? 0.0f : 0.3f);
    }

    private Vector2 canvasSize;
    private void Update() {
      this.canvasSize = this.GetMobileInputAnalogUI()
                        .GetCanvasSize();

      #if UNITY_EDITOR
      EditorUpdate();
      #else
      NonEditorUpdate();
      #endif

      Vector2 sizeDelta = canvasSize;
      sizeDelta.x = sizeDelta.x >= sizeDelta.y
                    ? sizeDelta.y
                    : sizeDelta.x;
      sizeDelta.x *= UI.scale;

      sizeDelta.y = sizeDelta.x;
      this.GetRectTransform().sizeDelta = sizeDelta;
    }

    private UnityEngine.UI.Image image;
    private void Setup() {
      this.gameObject.layer = LayerMask.NameToLayer("UI");

      Helper.AddComponentsGameObject(
        new Type[] {typeof(UnityEngine.RectTransform),
                    typeof(UnityEngine.UI.Image)
                   },
        this.gameObject);

      rectTransform = this.GetRectTransform();
      this.rectTransform.anchoredPosition = Vector2.zero;

      this.image = this.gameObject.GetComponent<UnityEngine.UI.Image>();
      this.image.sprite = Resources.Load<Sprite>
                          (UI.pathSpriteCircle);
      this.image.color = new Color(0.0f, 0.0f, 0.0f, 0.3f);
    }

    private UI mobileInputAnalogUI;
    public void SetMobileInputAnalogUI(UI mobileInputAnalogUI) {
      this.mobileInputAnalogUI = mobileInputAnalogUI;
      this.transform.SetParent(this.mobileInputAnalogUI.transform);
    }

    public UI GetMobileInputAnalogUI() {
      return mobileInputAnalogUI;
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

    private void SetImageAlpha(float alpha) {
      Color color = this.image.color;
      color.a = alpha;
      this.image.color = color;
    }
  }
}