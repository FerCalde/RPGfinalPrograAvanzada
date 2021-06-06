using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemiesQueue<T> where T: class
{

    public Node head; //Primer nodo de la fila
    public Node tail; //Último nodo de la fila
    public int count; //Número de nodos totales


    public class Node
    {
        public T data;
        public Node next;
        public Node prev;

        public Node(T t)
        {
            data = t;
            next = null;
            prev = null;
        }
    }

    public void PonerALaFila(T t)
    {
        Node n = new Node(t);
        n.next = tail;
        if (count > 0)
        {
            tail.prev = n;
        }
        if (head == null)
        {
            head = n;
        }
        tail = n;
        count++;

    }

    public T QuitarDeLaFila()
    {
        if (count > 0)
        {
            Node temp = head;
            if (count <= 1)
            {
                head = null;
            }
            else
            {
                head = head.prev;
                head.next = null;
            }
            count--;
            return temp.data;
        }
        else
        {
            Debug.Log("Error, Nothing to dequeue.");
            return null;
        }

    }
}