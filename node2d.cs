
using Godot;
using System;
using vblibrary;
using fsharplibrary;

public partial class node2d : Node2D
{
    GodotFSharp fsclass;
    GodotVisualBasic vbclass;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("hello world from csharp");

        fsclass = new GodotFSharp(this);
        fsclass.Ready();

        vbclass = new GodotVisualBasic(this);
        vbclass._Ready();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    //public override void _Process(double delta)
    //{
    //    vbclass._Process();
    //}

    public override void _Draw()
    {
        fsclass.Draw();
        vbclass._Draw();
    }

}