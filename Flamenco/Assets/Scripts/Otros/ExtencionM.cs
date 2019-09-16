using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtencionM
{ 
    /// <summary>
    /// se hace freeze en el axis z 
    /// </summary>
    /// <param name="rb"></param>
    public static void RigydFrezz(this Rigidbody2D rb)
    {
        rb.freezeRotation = true;        
    }
    /// <summary>
    /// se aplica el Addforce del dash 
    /// </summary>
    /// <param name="rb"></param>
    public static void RigydForce(this Rigidbody2D rb)
    {
        rb.AddForce(new Vector2(10000f, 0f));
    }
    /// <summary>
    /// el personaje recupera su color inicial
    /// </summary>
    /// <param name="render"></param>
    public static void RenderMe(this SpriteRenderer render)
    {
        render.material.color = Color.white;
        render.color = Color.white;
    }
    /// <summary>
    /// se aplica el cambio de color enemigo
    /// </summary>
    /// <param name="render"></param>
    public static void RenderEnemy(this SpriteRenderer render)
    {
        render.material.color = Color.red;
    }
    /// <summary>
    /// se establece la escala inicial del personaje
    /// </summary>
    /// <param name="trans"></param>
    public  static void TransformMe(this Transform trans)
    {
        trans.localScale = new Vector3(18, 19, 1);
    }
}
