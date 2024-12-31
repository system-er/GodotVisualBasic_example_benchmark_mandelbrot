namespace fsharplibrary

open System.Diagnostics
open Godot

type GodotFSharp(n: Node2D) as self =

    let n2d = n
    let mutable timer = 0
    let colors = [|
        Color.Color8(0uy, 0uy, 0uy); 
        Color.Color8(255uy, 0uy, 255uy); 
        Color.Color8(0uy, 0uy, 255uy);
        Color.Color8(0uy, 255uy, 0uy);
        Color.Color8(0uy, 128uy, 255uy);
        Color.Color8(255uy, 0uy, 0uy);
        Color.Color8(255uy, 128uy, 0uy);
        Color.Color8(255uy, 255uy, 0uy);
        Color.Color8(255uy, 255uy, 255uy)
        |]

    do
        GD.Print("hello world from f#class-constructor")

    member this.Ready() =
        GD.Print("hello world from f#, node3d: ", n2d.ToString())

    //member this.Process(delta: double) =
    //    timer <- timer + 1
    //    if timer > 120 then
    //        GD.Print("hello world from Process")
    //        timer <- 0

    member this.Draw() =
        let timer = new Stopwatch()
        timer.Start()

        let mutable c : Color = Color.Color8(0uy, 0uy, 0uy)
        let mutable l : float = 100.0
        let mutable u : float = 0.0
        let mutable v : float = 0.0
        let mutable x : float = 0.0
        let mutable y : float = 0.0
        let mutable n : float = 0.0
        let mutable r : float = 0.0
        let mutable q : float = 0.0

        GD.Print("F# Draw start")
        
        for i in 0 .. 500 do
            for j in 0 .. 500 do
                u <- float(i) / 250.0 - 1.5
                v <- float(j) / 250.0 - 1.0
                x <- u
                y <- v
                n <- 0.0
                r <- x * x
                q <- y * y
                
                while (r + q) < 4.0 && n < l do
                    y <- 2.0 * x * y + v
                    x <- r - q + u
                    r <- x * x
                    q <- y * y
                    n <- n + 1.0
                
                if n < 10.0 then
                    c <- colors[0]
                else
                    c <- colors[int(Mathf.Round(8.0 * (n - 10.0) / (l - 10.0)))]
                    //c.B = float32(255)
       
                n2d.DrawRect(Rect2(Vector2(float32(i) + float32(500.0), float32(j)+ float32(500.0)), Vector2(float32(1.0), float32(1.0))), c, true, float32(-1.0), false)
                
        timer.Stop()
        GD.Print("F# result milliseconds:", timer.ElapsedMilliseconds.ToString())

    override self.Finalize() =
        GD.Print("hello world from f#class-destructor")