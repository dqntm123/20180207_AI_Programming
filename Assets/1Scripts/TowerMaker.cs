using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaker : MonoBehaviour {

    public GameObject TowerPrefab;

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
               switch(hitInfo.transform.tag)
                {
                    case "Wall":
                        Instantiate(TowerPrefab, hitInfo.transform.position + new Vector3(0, 2f, 0), TowerPrefab.transform.rotation);
                        break;
                    case "Plane":
                        Debug.Log("그곳에 타워를 설치할 수 없습니다. ");
                        break;
                    case "Enemy":
                        Debug.Log("선택한 적의 이름은 :::" + hitInfo.transform.name);
                        break;
                    case "Tower":
                        Debug.Log("선택한 적의 이름은 :::" + hitInfo.transform.name);
                        break;
                }
            }
        }
	}
}
