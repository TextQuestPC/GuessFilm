using System;

namespace SaveSystem
{
    [Serializable]
    public class SavePartData 
    {
        public int Id;
        public bool IsOpen;
        public bool[] GuessPuzzle;
    }
}