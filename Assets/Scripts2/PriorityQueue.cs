using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue {

    private ArrayList nodes = new ArrayList();

    public int Length
    {
        get
        {
            return this.nodes.Count;
        }
    }
    public bool Contains(object node)
    {
        return this.nodes.Contains(node);
    }
    public Node First()
    {
        if(this.nodes.Count>0)//만약 노드(private로 선언한 ArrayList값)의 카운트에 뭔가가 들어간다면
        {
            return (Node)this.nodes[0];//이것을 반환한다
        }
        return null;//아니라면 아무것도아닌값을 반환한다.
    }
	public void Push(Node node)//노드의 인자값 노드를 밀어넣는다
    {
        this.nodes.Add(node);//list의 모든값을 새로운 배열안에 값아 밀어넣는다. 배열안에 배열을 넣을수있다.
        this.nodes.Sort();
    }
    public void Remove(Node node)
    {
        this.nodes.Remove(node);//노드(어레이리스트)값을 빼준다.
        this.nodes.Sort();//어레이리스트를 정렬한다.
    }
}
