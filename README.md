# MobileInputAnalog
  
## Description
Virtual Game Analog Library for Unity
  
## Screenshots
<img src="https://cdn.rawgit.com/jmsrsd/MobileInputAnalog/c25ccd89/Screenshots/Screenshot.00.jpg" height="320"/>
  
## Build Link
[Link](https://github.com/jmsrsd/MobileInputAnalog/raw/master/Build/Raion.MobileInputAnalog.unitypackage)
  
## Dir structure
```
Assets/
├── raion/  
│   ├── GeneralInput/  
|   |   └── GeneralInput.cs  
│   └── MobileInputAnalog/  
|       └── Scripts/  
|           ├── MobileInputAnalog.cs  
|           ├── MobileInputAnalogCanvas.cs  
|           ├── MobileInputAnalogHelper.cs  
|           ├── MobileInputAnalogUI.cs  
|           ├── MobileInputAnalogUIBackground.cs  
|           ├── MobileInputAnalogUIForeground.cs  
|           └── TestMobileInputAnalog.cs  
└── Resources/  
    └── raion/  
        └── MobileInputAnalog/  
            └── Sprites/  
                └── MobileInputAnalog.Sprite.Circle.png 
```
  
## Usage
To initialize the library:
```
raion.MobileInputAnalog.GetInstance();
```

To use the library:
```
float speed = 10.0f;
Vector2 direction = raion.MobileInputAnalog.GetInstance().GetDirection();

// Moving a GameObject
transform.position += direction * speed * Time.deltaTime;
```
