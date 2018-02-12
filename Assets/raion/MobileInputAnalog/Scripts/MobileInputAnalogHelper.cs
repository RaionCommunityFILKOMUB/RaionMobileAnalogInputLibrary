using System.Reflection;
using System;

using UnityEngine;
using UnityEngine.UI;

namespace raion {
public static class MobileInputAnalogHelper {
  public static class Instantiator {
    public static T InstantiateAsComponent<T>()
    where T : UnityEngine.Component {
      string n = typeof(T).FullName;
      n = n.Replace('+', '.');
      
      GameObject go = new GameObject(n);
      T c = go.AddComponent<T>();
      
      return c;
    }
  }
  
  public static GameObject
  AddComponentsGameObject(Type[] components, GameObject go) {
    for (int i = 0, len = components.Length; i < len; i++) {
      if (go.GetComponent(components[i]) == null) {
        go.AddComponent(components[i]);
      }
    }
    
    return go;
  }
}
}