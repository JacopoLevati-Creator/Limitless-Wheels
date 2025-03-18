Shader "Custom/SeeThrough"
{
    SubShader
    {
        Tags {"Queue" = "Overlay"} // Disegna sopra tutto
        Pass
        {
            ZWrite Off // Non scrive sulla profondit�
            ZTest Always // Viene sempre disegnato
            ColorMask RGB // Mantiene i colori normali
        }
    }
}