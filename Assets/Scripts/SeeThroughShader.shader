Shader "Custom/SeeThrough"
{
    SubShader
    {
        Tags {"Queue" = "Overlay"} // Disegna sopra tutto
        Pass
        {
            ZWrite Off // Non scrive sulla profondità
            ZTest Always // Viene sempre disegnato
            ColorMask RGB // Mantiene i colori normali
        }
    }
}