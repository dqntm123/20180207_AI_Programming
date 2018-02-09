using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar  {

    public static PriorityQueue closedList, openList;
    
    private static float HeuristicEstimateCost(Node curNode,Node goalNode)//인자값으로 노드의 현재노드와 내가목표로하는 노드값을 받는다.
    {
        Vector3 vecCost = curNode.position - goalNode.position;//현재노드 벡터3값에 목표노드 벡터3값을 뺀것을
        return vecCost.magnitude;//여기로 반환한다.
    }
    public static ArrayList FindPath(Node start,Node goal)
    {
        openList = new PriorityQueue();//오픈리스트안에 새로운 프리오리티큐로 집어넣는다
        openList.Push(start);//노드값의 스타트로 밀어넣는다
        start.nodeTotalCost = 0f;
        start.estimatedCost = HeuristicEstimateCost(start, goal);
        closedList = new PriorityQueue();
        Node node = null;
        while (openList.Length!=0)
        {
            node = openList.First();
            if(node.position==goal.position)//현재노드값의 포지션과 목표노드의 포지션값이 같다면
            {
                return CalculatePath(node);//이값을 반환한다.
            }
            ArrayList neighbours = new ArrayList();
            GridManager.instance.GetNeighbours(node, neighbours);//싱글톤으로 선언한 그리드매니저에 인자값을 넣는다
            for (int i = 0; i < neighbours.Count; i++)//어레이리스트가 0이될때까지 이값을 계속 돌린다
            {
                Node neighbourNode = (Node)neighbours[i];
                if(!closedList.Contains(neighbourNode))
                {
                    float cost = HeuristicEstimateCost(node, neighbourNode);
                    float totalCost = node.nodeTotalCost + cost;
                    float neighbourNodeEstCost = HeuristicEstimateCost(neighbourNode, goal);
                    neighbourNode.nodeTotalCost = totalCost;
                    neighbourNode.parent = node;
                    neighbourNode.estimatedCost = totalCost + neighbourNodeEstCost;
                    if(!openList.Contains(neighbourNode))
                    {
                        openList.Push(neighbourNode);
                    }
                }
            }
            closedList.Push(node);//위에 while값을 돌리고 나왓을때 그 클로즈리스트값을 밀어넣는다 노드에다가
            openList.Remove(node);//그리고 오픈리스트의 노드값은 빼낸다.
        }
        if(node.position!=goal.position)
        {
            Debug.LogError("Goal Not Found");
            return null;
        }
        return CalculatePath(node);
    }
    private static ArrayList CalculatePath(Node node)
    {
        ArrayList list = new ArrayList();
        while(node!=null)
        {
            list.Add(node);
            node = node.parent;
        }
        list.Reverse();
        return list;
    }
}
