extends Node2D


var colors = PackedColorArray()


# Called when the node enters the scene tree for the first time.
func _ready():
	colors.append(Color(0.0,0.0,0.0))
	colors.append(Color(1.0,0.0,1.0))
	colors.append(Color(0.0,0.0,1.0))
	colors.append(Color(0.0,1.0,0.0))
	colors.append(Color(0.0,0.5,1.0))
	colors.append(Color(1.0,0.0,0.0))
	colors.append(Color(1.0,0.5,0.0))
	colors.append(Color(1.0,1.0,0.0))
	colors.append(Color(1.0,1.0,1.0))
	
	
func _draw():
	# var msecsstart=OS.get_system_time_msecs()
	var msecsstart=Time.get_ticks_msec()
	var c=Color(0.0,0.0,0.0)
	# from http://www.quitebasic.com/prj/math/mandelbrot/
	var l=100
	var u = 0
	var v = 0
	var x = 0
	var y = 0
	var n = 0
	var r = 0
	var q = 0
	for i in range(0,500):
		for j in range(0,500):
			u=i/250.0-1.5
			v=j/250.0-1.0
			x=u
			y=v
			n=0.0
			r=x*x
			q=y*y
			while (r+q)<4 && n<l:
				y=2*x*y+v
				x=r-q+u
				r=x*x
				q=y*y
				n=n+1
			if n<10: 
				c=colors[0]
			else:
				c = colors[int(round(8 * (n-10) / (l-10)))]
				c.r = 255
			draw_rect(Rect2(Vector2(i,j),Vector2(1,1)), c, true, -1.0, false)
	var msecsstop=Time.get_ticks_msec()
	print("gdscript result millisecs: ", msecsstop-msecsstart)
			
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	#update()
	pass
