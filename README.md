# MobileInputAnalog
  
## Description
Virtual Game Analog Library for Unity
  
## Screenshots
<img src="https://cdn.rawgit.com/jmsrsd/MobileInputAnalog/c25ccd89/Screenshots/Screenshot.00.jpg" width="480"/>
  
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
By only writing this statement
```
raion.MobileInputAnalog.GetInstance();
```
all the library codes will run.
