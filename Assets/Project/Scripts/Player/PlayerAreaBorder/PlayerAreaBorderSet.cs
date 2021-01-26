using UnityEngine;

namespace Project
{
    public class PlayerAreaBorderSet : MonoBehaviour
    {
        public enum Position
        {
            Top,
            Bottom,
            Left,
            Right
        }

        public Position position;
        public float Offset = 0.25f;

        private void Start()
        {
            Transform transform = GetComponent<Transform>();
            Vector3 newPosition = Vector3.zero;

            switch (position)
            {
                case Position.Top:
                    newPosition.y = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, 0f)).y + Offset;
                    break;
                case Position.Bottom:
                    newPosition.y = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y + Offset;
                    break;
                case Position.Left:
                    newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0, 0f)).x + Offset;
                    break;
                case Position.Right:
                    newPosition.x = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x + Offset;
                    break;
            }

            transform.position = newPosition;

            Destroy(this);
        }
    }
}
