GodotKeybinder is a personal project for custom keybinding targeting the video game engine Godot. Using JSON to save and bind actions to customized inputs from keyboard, mouse and controllers.

How to use:

The static class InputManager can return an instance of a PlayerInput object. 
PlayerInput for instance can check if any particular action or return the value of an action.

For example:

playerInput.GetAxis2D(ConstActions.HorizontalMovement, ConstActions.VerticalMovement);

The method above will return a Vector2 of the two values of the actions.  For instance, the value of an analog stick on an Xbox controller.


Stay noted, this project is still being developed but is however functional and performs well.


C#, .NET, Godot Engine, Mono
