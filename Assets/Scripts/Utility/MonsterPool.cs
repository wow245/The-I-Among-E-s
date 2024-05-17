using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : ObjectPool
{
    [SerializeField] GameObject testMap;
    BoxCollider2D mapCollider;

    private void Start()
    {
        mapCollider = testMap.GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnMonster(9));
        Vector2 pos = testMap.transform.position;
        Debug.Log(pos);
    }
    
    // TODO :: 실제 스폰처리는 다른 곳에서 함
    // TODO :: 스폰 시 코루틴 사용       
    IEnumerator SpawnMonster(int count)
    {
        // TODO :: 반복 횟수 정하기
        //         정해진 정수 or 몬스터 n마리 처치 시 종료?
        for(int i=0;i<count;i++)
        {           
            GameObject monster = GameManager.Instance.ObjectPool.SpawnFromPool("Test");
            monster.transform.position = ReturnRandomPos();

            yield return new WaitForSeconds(1f);
        }
    }

    // 몬스터를 랜덤한 위치에 생성하기 위해 랜덤 위치를 받아오는 함수
    // 1. 맵 콜라이더를 가져와서 x, y 범위를 저장
    // 2. 중앙위치에 -(범위/2) ~ (범위/2) 값을 더해서 랜덤한 위치에 생성되도록

    // TODO :: 3. 플레이어 시작 위치에 생성되면 안되니까 정중앙은 조금 비워둬야함
    public Vector2 ReturnRandomPos()
    {
        Vector2 pos = testMap.transform.position;
        float x = mapCollider.bounds.size.x;
        float y = mapCollider.bounds.size.y;

        x = Random.Range((x / 2) * -1, x / 2);
        y = Random.Range((y / 2) * -1, y / 2);

        Vector2 randomPos = new Vector2(x, y);

        return pos + randomPos;
    }
}
