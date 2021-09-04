using UniRx;
using UnityEngine;
using System;
using System.Collections.Generic;

public class InputSystem : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] List<Item> items;
    [SerializeField] PackageView packageView;
    public float speed;
    IDisposable moveDispose;
    IDisposable jumpDispose;

    Vector3 vector3;
    private void Awake()
    {
        vector3 = player.transform.position;
    }
    internal void Close()
    {
        moveDispose.Dispose();
        jumpDispose.Dispose();
    }

    public int jumpForce=10;

    internal void ReSet()
    {
        SetControll();
        packageView.ReSet();
        items.ForEach((item) => item.gameObject.SetActive(true));
        player.transform.position= vector3;
    }

    internal void RecoverControl()
    {
        SetControll();
    }

    [SerializeField] Transform wall1;
    [SerializeField] Transform wall2;
    // Start is called before the first frame update
    void Start()
    {
        SetControll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Test");
        }
    }
    private void SetControll()
    {
        moveDispose=Observable.EveryUpdate()
                          .Where(_ => Mathf.Abs(Input.GetAxis("Horizontal")) > 0.001)
                          .Subscribe(_ => Move())
                          .AddTo(this);
        jumpDispose= Observable.EveryUpdate()
                          .Where(_ => Input.GetButtonDown("Jump"))
                          .Subscribe(_ => Jump())
                          .AddTo(this);

    }

    private void Jump()
    {
        rb2D.AddForce(new Vector2(0,jumpForce*100));
    }

    private void Move()
    {
        float move = speed * Time.deltaTime;
        bool dirction= Input.GetAxis("Horizontal")>0;
        move = dirction ? move : -move;
        var xPos= player.transform.position.x + move;
        (float left,float right )= wall1.position.x > wall2.position.x ? (wall2.position.x, wall1.position.x) : (wall1.position.x, wall2.position.x);
        xPos= Mathf.Clamp(xPos, left, right);
        var pos = player.transform.position;
        pos.x = xPos;
        player.transform.position = pos;
    }

}
