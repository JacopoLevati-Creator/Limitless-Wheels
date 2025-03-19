Shader "Custom/SeeThroughOpaque"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1) // Colore pieno, senza trasparenza
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" "RenderType" = "Opaque" } // Non pi� Transparent
        Pass
        {
            ZWrite Off      // Non scrive sulla profondit�, quindi non viene nascosto
            ZTest Always    // Sempre visibile, anche dietro ai muri
            Color[_Color]  // Usa il colore definito nel materiale
        }
    }
}
