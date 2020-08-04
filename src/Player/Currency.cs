using Godot;
using System;

public class Currency : RichTextLabel
{
	public Player PlayerBody;
	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(float delta)
	{
		PlayerBody = GetOwner<Player>();
		this.Text = PlayerBody.Money + " M";
	}

}
