using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum STATE
    {
        IDLE, SEEK, RETURN
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected Vector3 origen;
    public bool derecha;

    protected float visDist = 5.0f;

    public State(GameObject _npc, Animator _anim, Transform _player, bool _derecha, Vector3 _origen)
    {
        npc = _npc;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
        derecha = _derecha;
        origen = _origen;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State Process()
    {
        if(stage == EVENT.ENTER) Enter();
        if(stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector2 direction = player.position - npc.transform.position;

        if(direction.magnitude < visDist) return true;
        return false;
    }
}

public class Idle : State
{
    public Idle(GameObject _npc, Animator _anim, Transform _player, bool _derecha, Vector3 _origen) : base(_npc, _anim, _player, _derecha, _origen)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("idle");
        anim.ResetTrigger("run");
        // Debug.Log(name);
        Rigidbody2D rb = npc.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, 0.0f);
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new Seek(npc, anim, player, derecha, origen);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Seek : State
{
    public float velocidad = 5.5f;

    public Seek(GameObject _npc, Animator _anim, Transform _player, bool _derecha, Vector3 _origen) : base(_npc, _anim, _player, _derecha, _origen)
    {
        name = STATE.SEEK;
    }

    public override void Enter()
    {
        anim.SetTrigger("run");
        anim.ResetTrigger("idle");
        base.Enter();
    }

    public override void Update()
    {

        if (!CanSeePlayer())
        {
            nextState = new Idle(npc, anim, player, derecha, origen);
            stage = EVENT.EXIT;
        }
        Vector2 direccion = (player.position - npc.transform.position).normalized;
        Rigidbody2D rb = npc.GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(direccion.x * velocidad, npc.transform.position.y);
        rb.velocity = new Vector2(direccion.x * velocidad, 0.0f);
        if (direccion.x > 0 && !derecha)
        {
            Girar();
        }
        else if (direccion.x < 0 && derecha)
        {
            Girar();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public void Girar()
    {
        derecha = !derecha;
        Vector3 escala = npc.transform.localScale;
        escala.x *= -1;
        npc.transform.localScale = escala;
    }
}

public class Return : State
{
    public float velocidad = 4.5f;

    public Return(GameObject _npc, Animator _anim, Transform _player, bool _derecha, Vector3 _origen) : base(_npc, _anim, _player, _derecha, _origen)
    {
        name = STATE.RETURN;
    }

    public override void Enter()
    {
        // Debug.Log("ENTER");
        // anim.SetTrigger("run");
        // anim.ResetTrigger("idle");
        base.Enter();
    }

    public override void Update()
    {
        // Debug.Log("UPDATE");
        float distanciaTolerancia = 0.1f;
        float distancia = Vector2.Distance(npc.transform.position, origen);

        if (distancia < distanciaTolerancia)
        {
            // Debug.Log("if");
            nextState = new Idle(npc, anim, player, derecha, origen);
            stage = EVENT.EXIT;
        }
        Vector2 direccion = (origen - npc.transform.position).normalized;
        Rigidbody2D rb = npc.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direccion.x * velocidad, 0.0f);
        // rb.velocity = new Vector2(direccion.x * velocidad, rb.velocity.y);
        if (direccion.x > 0 && !derecha)
        {
            Girar();
        }
        else if (direccion.x < 0 && derecha)
        {
            Girar();
        }
    }

    public override void Exit()
    {
        // Debug.Log("EXIT");
        base.Exit();
    }

    public void Girar()
    {
        derecha = !derecha;
        Vector3 escala = npc.transform.localScale;
        escala.x *= -1;
        npc.transform.localScale = escala;
    }
}