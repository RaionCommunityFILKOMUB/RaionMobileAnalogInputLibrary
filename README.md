# RaionMobileInputAnalog
  
## Description
Virtual Game Analog Library for Unity
  
## Screenshots
<img src="https://cdn.rawgit.com/jmsrsd/MobileInputAnalog/c25ccd89/Screenshots/Screenshot.00.jpg" height="320"/>

## Installation
1. Download the \*.unitypackage file(s) in Build dir or in "Build Link" section of this page
2. Open the \*.unitypackage file(s)
3. Click all button and then import button in Unity import package dialogue
4. Read "Usage" section of this page to know how to use the library

## Build Link
[Link](https://github.com/jmsrsd/MobileInputAnalog/raw/master/Build/Raion.MobileInputAnalog.unitypackage)
  
## Dir structure
```
Assets
├───raion
│   ├───GeneralInput
│   │       GeneralInput.cs
│   │
│   └───MobileInputAnalog
│       ├───Materials
│       │       Raion.MobileInputAnalog.Material.Standard.Gray.mat
│       │       Raion.MobileInputAnalog.Material.Standard.White.mat
│       │
│       ├───Scenes
│       │       Raion.MobileInputAnalog.Scene.Test.unity
│       │
│       └───Scripts
│               MobileInputAnalog.cs
│               MobileInputAnalogCanvas.cs
│               MobileInputAnalogHelper.cs
│               MobileInputAnalogUI.cs
│               MobileInputAnalogUIBackground.cs
│               MobileInputAnalogUIForeground.cs
│               TestMobileInputAnalog.cs
│
└───Resources
    └───raion
        └───MobileInputAnalog
            └───Sprites
                    Raion.MobileInputAnalog.Sprite.Circle.png 
```
  
## Usage
To initialize the library:
```
raion.MobileInputAnalog.GetInstance();
```

To use the library:
```
using UnityEngine;

public class TestMobileInputAnalog : MonoBehaviour {
  private void Update() {
    float speed = 10.0f;
    Vector2 direction = raion.MobileInputAnalog.GetInstance().GetDirection();

    // Moving the GameObject
    transform.position += (Vector3) direction * speed * Time.deltaTime;
  }
}
```
