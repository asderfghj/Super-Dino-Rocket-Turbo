using UnityEngine;
public class SectionScroller : MonoBehaviour
{
	//scrolls the environment on a publicly defined speed in the editor
    public int scrollSpeed = 0;
    private void Update()
    {
        transform.Translate(new Vector2(scrollSpeed, 0) * Time.deltaTime);
        if (transform.position.x < -20)
        {
            transform.Translate(new Vector3(40, 0, 0));
        }
		if (transform.position.y < -40)
		{
			Destroy (gameObject);
		}
    }
}
