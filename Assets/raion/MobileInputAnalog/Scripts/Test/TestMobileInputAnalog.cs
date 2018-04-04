using UnityEngine;

public class TestMobileInputAnalog : MonoBehaviour {
  private void Update() {
    float speed = 10.0f;
    Vector3 direction =
      raion.MobileInputAnalog.Library.GetInstance().GetDirection();

    float buffer = direction.z;
    direction.z = direction.y;
    direction.y = buffer;

    // Moving the GameObject
    GameObject.Find("Cube").transform.position +=
      direction * speed * Time.deltaTime;
  }
}
