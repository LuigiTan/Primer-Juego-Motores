using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScritp : MonoBehaviour
{
    [SerializeField] private Partitioning partitioning;
    [SerializeField] private Vector2 size;
   
    void Start()
    {
        //Debug.DrawLine(Vector3.zero, Vector3.one, Color.red, 10); In case it doesnt work
        Rectangle canvas = new Rectangle(transform.position, size);
        Node<Rectangle> root = new Node<Rectangle>(canvas, 0);
        partitioning.Generate(root);

        List<Node<Rectangle>> leaves = new();
        root.Leaves(leaves);


        for (int i = 0; i < leaves.Count; i++)
            leaves[i].Data.Draw(Color.red, 10);
        //Rectangle rectangle = new Rectangle(transform.position, new Vector2(5, 7));
        //rectangle.Draw(Color.red, 5);
        //Node<int> root = new Node<int>(5, 0);
        //Node<int> bl1 = new Node<int>(3, 1);
        //Node<int> br1 = new Node<int>(8, 1);
        //Node<int> tl1 = new Node<int>(7, 1);
        //Node<int> tr1 = new Node<int>(14, 1);
        //root.BottomLeft = bl1;
        //root.BottomRight = br1;
        //root.TopLeft = tl1;
        //root.TopRight = tr1;
  
        //Node<int> bl2 = new Node<int>(3, 2);
        //Node<int> br2 = new Node<int>(2, 2);
        //Node<int> tl2 = new Node<int>(27, 2);
        //Node<int> tr2 = new Node<int>(4, 2);
        //br1.BottomLeft = bl2;
        //br1.BottomRight = br2;
        //br1.TopLeft = tl2;
        //br1.TopRight = tr2;

        //Node<int> bl3 = new Node<int>(6, 3);
        //Node<int> br3 = new Node<int>(0, 3);
        //Node<int> tl3 = new Node<int>(-5, 3);
        //Node<int> tr3 = new Node<int>(8, 3);
        //tr2.BottomLeft = bl3;
        //tr2.BottomRight = br3;
        //tr2.TopLeft = tl3;
        //tr2.TopRight = tr3;



        //List<Node<int>> leaves = new List<Node<int>>();
        //root.Leaves(leaves);

        //for (int i = 0; i < leaves.Count; i++)
        //    print(leaves[i].Data);

    }

}
