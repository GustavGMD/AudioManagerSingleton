# AudioManagerSingleton
A tool for managing audio in Unity3D projects. It targets small to medium sized projects. The goal is to be able to include audio to a project quickly.

It uses a singleton design pattern to centralize audio management on the project. The singleton controls pools of GameObjects containing AudioClips which are used as needed.

The main property of this asset is the use of an enum to refer to the audioFile one wants to play. The only setting up needed is to add your Audio files to "Resources/Audio" folder, and ensure they are in the same order as their references in the enum in the AudioManagerSingleton class. With that done, you just have to call the Initialize() method on the singleton and then call the PlaySound() method to have your audio file playing.

This is a work in progress.

# How To Use
- Add your audio files to "Assets/Resources/Audio" folder;
- Edit the Audio enum so that you have all your audio references there, matching the order of your audio files in the "Resources/Audio" folder;
- Call AudioManagerSingleton.instance.Initialize() method;
- Call AudioManagerSingleton.instance.PlaySound() method with the desired parameters;

# Features

- Play 2D Sound: specify wether it loops or not, the volume of the sound; Returns and ID for the just created Sound;
- Stop 2D Sound: stops a specific(according to the given ID) sound;
- Change Volume: Changes the volume of an Active given sound;

#To Do List

- Add the other features I forgot about to the To Do List;
- Make Mute mechanics cleaner and more intuitive;
- Add 3D sound management;
