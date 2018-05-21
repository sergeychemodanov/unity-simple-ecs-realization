namespace SurvivalExample
{
    public class MovementComponent : BaseComponent
    {
        public float Speed { get; private set; }

        public MovementComponent(float speed)
        {
            Speed = speed;
        }
    }
}