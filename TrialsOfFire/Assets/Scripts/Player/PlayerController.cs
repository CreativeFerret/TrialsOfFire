using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private CharacterController mageCharacter;

    [SerializeField]
    private Camera eyes;

    [SerializeField]
    private float speed;

    private bool canDash;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouse_x = Input.GetAxis("Mouse X");
		float mouse_y = Input.GetAxis("Mouse Y");

		Vector3 move = transform.forward * vertical + transform.right * horizontal;

        mageCharacter.Move(move * speed * Time.deltaTime);
        transform.Rotate(0f, mouse_x, 0f);
        eyes.transform.Rotate(-mouse_y, 0f, 0f);
        Debug.Log("Can Dash: " + canDash);

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
			mageCharacter.Move(move * 900f * Time.deltaTime);
            StartCoroutine(ReloadDash());
        }
    }

    IEnumerator ReloadDash(){
        canDash = false;
        yield return new WaitForSeconds(4f);
        canDash = true;

    }
}
