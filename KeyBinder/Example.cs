using Godot;
using System;
using System.Diagnostics;
using test1.InputController;

public class Example : Sprite
{
    private PlayerInput player;

    public override void _Ready()
    {      
        InputManager.Initialize();
        player = InputManager.GetPlayer(0);

        this.AddChild(player);
        
    }

    
    public override void _Process(float delta)
    {

          Position += player.GetAxis2D(ConstActions.HorizontalMovement, ConstActions.VerticalMovement);

        if (player.GetAction(ConstActions.Attack))
        {
            GD.Print("Attack");
        }

    }

}
