using System;

namespace Save
{
    [Serializable]
    public class SavePartData 
    {
        public int ID;
        public bool IsOpen;
        public bool[] GuessPuzzle;
    }
}