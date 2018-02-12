using System;

using UnityEngine;
using UnityEngine.UI;

namespace raion {
public class MobileInputAnalogUIForeground : MonoBehaviour {
  private void Start() { this.Setup(); }
  
  private void EditorUpdate() {
    this.SetImageAlpha(0.0f);
    
    if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0)) {
      Vector2 position = Input.mousePosition;
      position -= canvasSize * 0.5f;
      
      this.GetRectTransform().anchoredPosition = position;
      
      this.SetImageAlpha(0.6f);
    }
  }
  
  private void NonEditorUpdate() {
    this.SetImageAlpha(0.0f);
    
    if (Input.touchCount > 0) {
      if (Input.GetTouch(0).phase != TouchPhase.Began) {
        Vector2 position = Input.GetTouch(0).position;
        position -= canvasSize * 0.5f;
        
        this.GetRectTransform().anchoredPosition = position;
        
        this.SetImageAlpha(0.6f);
      }
    }
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
    
    float scaleRelativeToBackground = 0.75f;
    Vector2 sizeDelta = this.mobileInputAnalogUI
                        .GetBackground()
                        .GetRectTransform()
                        .sizeDelta;
    float maxMagnitude = sizeDelta.x * 0.5f;
    sizeDelta.x *= scaleRelativeToBackground;
    sizeDelta.y = sizeDelta.x;
    
    Vector2 offset =
      this.GetRectTransform().anchoredPosition
      - this.mobileInputAnalogUI.GetBackground().GetRectTransform().anchoredPosition;
      
    this.GetRectTransform().anchoredPosition =
      this.mobileInputAnalogUI.GetBackground().GetRectTransform().anchoredPosition;
      
    offset = Vector2.ClampMagnitude(offset, maxMagnitude);
    
    sizeDelta *= scaleRelativeToBackground
                 - ((offset.magnitude / sizeDelta.x) * 0.5f);
                 
    this.GetRectTransform().anchoredPosition += offset;
    this.GetRectTransform().sizeDelta = sizeDelta;
  }
  
  private void Setup() {
    MobileInputAnalogHelper.AddComponentsGameObject(
      new Type[] {typeof(UnityEngine.RectTransform),
                  typeof(UnityEngine.UI.Image)
                 },
      this.gameObject);
      
    rectTransform = this.gameObject.GetComponent<RectTransform>();
    this.rectTransform.anchoredPosition = Vector2.zero;
    
    this.image = this.gameObject.GetComponent<UnityEngine.UI.Image>();
    this.image.sprite = Resources.Load<Sprite>(MobileInputAnalogUI.pathSpriteCircle);
    this.image.color = new Color(1.0f, 1.0f, 1.0f, 0.6f);
  }
  
  private MobileInputAnalogUI mobileInputAnalogUI;
  public void SetMobileInputAnalogUI(MobileInputAnalogUI mobileInputAnalogUI) {
    this.mobileInputAnalogUI = mobileInputAnalogUI;
    this.transform.SetParent(this.mobileInputAnalogUI.transform);
  }
  
  private MobileInputAnalogUIBackground background;
  public void SetBackground(MobileInputAnalogUIBackground background) {
    this.background = background;
    this.transform.SetAsLastSibling();
  }
  
  public MobileInputAnalogUI GetMobileInputAnalogUI() {
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
  
  private UnityEngine.UI.Image image;
  public UnityEngine.UI.Image GetImage() {
    if (this.image == null) {
      if (this.gameObject.GetComponent<UnityEngine.UI.Image>() == null) {
        this.gameObject.AddComponent<UnityEngine.UI.Image>();
      }
      
      this.image = this.gameObject.GetComponent<UnityEngine.UI.Image>();
    }
    
    return this.image;
  }
  
  private void SetImageAlpha(float alpha) {
    Color color = this.GetImage().color;
    color.a = alpha;
    this.GetImage().color = color;
  }
  
  public float GetImageAlpha() {
    return this.GetImage().color.a;
  }
}
}