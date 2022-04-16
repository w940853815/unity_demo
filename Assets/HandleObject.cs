using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandleObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initCubeVect;
    private Vector3 initSphereVect;
    private Vector3 initCubeScale;
    private Vector3 initSpereScale;
    private GameObject curGameobj;
    private GameObject Cube;
    private GameObject Sphere;

    void Start()
    {
        Cube = GameObject.Find("Cube");
        if (Cube != null)
        {
            initCubeVect = Cube.transform.position;
            initCubeScale = Cube.transform.localScale;
        }
        else
        {
            initCubeVect = new Vector3(0, 0, 0);
        }
        Sphere = GameObject.Find("Sphere");
        if (Sphere != null)
        {
            initSphereVect = Sphere.transform.position;
            initSpereScale = Sphere.transform.localScale;
        }
        else
        {
            initSphereVect = new Vector3(0, 0, 0);
        }
        // 默认选中sphere
        curGameobj = Sphere;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                curGameobj = hit.collider.gameObject;    //获得选中物体
                string goName = curGameobj.name;    //获得选中物体的名字，使用hit.transform.name也可以
                Debug.Log(goName);
            }
        }
    }
    private Vector3 Scale(Vector3 localScale, float scaleFactor)
    {
        Vector3 scale = new Vector3(localScale.x + scaleFactor,
                                   localScale.y + scaleFactor,
                                   localScale.z + scaleFactor);
        return scale;
    }
    private void OnGUI()
    {
        bool anyKeyDown = Input.anyKeyDown;

        if (anyKeyDown)
        {
            KeyCode currentkey = Event.current.keyCode;
            switch (currentkey)
            {
                case (KeyCode.W): curGameobj.transform.Translate(0, 1, 0, Space.World) ; break;
                case (KeyCode.S): curGameobj.transform.Translate(0, -1, 0, Space.World); break;
                case (KeyCode.A): curGameobj.transform.Translate(-1, 0, 0, Space.World); break;
                case (KeyCode.D): curGameobj.transform.Translate(1, 0, 0, Space.World); break;
                case (KeyCode.Q): curGameobj.transform.Translate(0, 0, 1, Space.World); break;
                case (KeyCode.E): curGameobj.transform.Translate(0, 0, -1, Space.World); break;
                case (KeyCode.N): curGameobj.transform.localScale=Scale(transform.localScale, -1f); break;
                case (KeyCode.M): curGameobj.transform.localScale=Scale(transform.localScale,1f); break;

            }
        }
    }
    public void ResetPoint()
    {
        Cube.transform.position = initCubeVect;
        Sphere.transform.position = initSphereVect;
        Cube.transform.localScale = initCubeScale;
        Sphere.transform.localScale = initSpereScale;
    }
}
