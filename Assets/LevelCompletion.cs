using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    public MathTimer mathTimer; // Referensi ke skrip MathTimer

    // Method ini dipanggil ketika level berhasil diselesaikan
    public void LevelCompleted()
    {
        // Memanggil metode ResetTimer() dari objek MathTimer
        mathTimer.RestartTimer();
    }

    // Method ini dipanggil ketika level gagal diselesaikan (misalnya, saat game over)
    public void LevelFailed()
    {
        // Memanggil metode ResetTimer() dari objek MathTimer
        mathTimer.RestartTimer();
    }
}
