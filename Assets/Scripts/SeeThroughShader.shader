Shader "Custom/SeeThroughTransparent"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,0.7) // Con trasparenza
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" "RenderType" = "Transparent" }
        Pass
        {
            ZWrite Off         // Non scrive sulla profondità, evita di essere nascosto
            ZTest Always       // Sempre visibile, anche dietro ai muri
            Blend SrcAlpha OneMinusSrcAlpha // Abilita trasparenza
            Color[_Color]
        }
    }
}
