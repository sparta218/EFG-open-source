using Godot;

namespace EvilFarmingGame.Player
{
    public class PlayerController
    {
        private KinematicBody2D Body;

        [Export] public float Speed = 75;
        [Export] public float SprintSpeed = 150;
        
        public PlayerController(KinematicBody2D Body)
        {
            this.Body = Body;
        }

        public Vector2 InputMovement(float delta) // The Movement method based on Input 
        {
            Vector2 Velocity = new Vector2();

            if (Input.IsActionPressed("Player_Up"))
            {
                Velocity = Vector2.Up;
            }
            else if (Input.IsActionPressed("Player_Down"))
            {
                Velocity = Vector2.Down;
            }
            else if (Input.IsActionPressed("Player_Left"))
            {
                Velocity = Vector2.Left;
            }
            else if (Input.IsActionPressed("Player_Right"))
            {
                Velocity = Vector2.Right;
            }

            if (Input.IsActionPressed("Player_Sprint"))
                Velocity *= SprintSpeed;
            else
                Velocity *= Speed;

            return this.Body.MoveAndSlide(Velocity);
        }
    }
}