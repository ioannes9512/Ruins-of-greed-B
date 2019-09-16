using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class exthended_renderer
{
  public static void gestioncolor(this Renderer actuador)
  {
        actuador.material.color = Color.white;
  }
}
