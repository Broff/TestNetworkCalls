using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float yDlt;
    [SerializeField]
    private float speed;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = new Vector3(playerTransform.position.x, playerTransform.position.y + yDlt, -10);
        transform.position = Vector3.Lerp(transform.position, dir, Time.deltaTime * speed);
	}
}
