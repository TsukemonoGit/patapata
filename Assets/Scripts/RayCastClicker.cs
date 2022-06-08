using UnityEngine;
using UnityEngine.InputSystem;


//クリックした座標からレイを飛ばす
public class RayCastClicker : MonoBehaviour
{
    private Vector2 mousePos = Vector2.zero;

    PataPataController controller;
    private void Start()
    {
        controller = GetComponent<PataPataController>();
    }

    public void ReadMousPos(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        //Raycast  を　UI貫通させない
//#if UNITY_EDITOR
//        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
//#else
//   if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) return;
//#endif
       

        if (context.phase == InputActionPhase.Performed)
        {
           Debug.Log("Click");
       
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(mousePos);
                if (Physics.Raycast(ray, out hit))

                {
                PataMaterial pata = hit.collider.GetComponent<PataMaterial>();
                  if (pata != null){
                    //クリックしたときのアクションを書く
                    Vector2Int clickPosition = pata.GetPosition();
                    Debug.Log(clickPosition);
                    controller.ClickPanel(clickPosition);
                 
                }
            }
            
        }
    }
}
