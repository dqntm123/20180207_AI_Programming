using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspect : MonoBehaviour {

	public enum aspect//플레이어인지 에너미인지 구분하기위한 함수일뿐
    {
        Player,
        Enemy
    }
    public aspect aspectName;
}
