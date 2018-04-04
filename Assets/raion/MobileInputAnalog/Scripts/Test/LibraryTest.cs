using UnityEngine;

public class LibraryTest : MonoBehaviour {
  private void Update() {
    float speed = 10.0f;

    Vector2 direction =
      raion.MobileInputAnalog.Library.GetInstance().GetDirection();

    Vector3 velocity = Vector3.zero;
    velocity.x = direction.x;
    velocity.z = direction.y;

    // Moving the GameObject
    transform.position += velocity * speed * Time.deltaTime;
  }
}
