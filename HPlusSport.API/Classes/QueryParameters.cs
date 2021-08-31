using System;

namespace HPlusSport.API.Classes
{
    //This class holds all QueryParameters.
    public class QueryParameters
    {
        //Number of items displayed on a page.
        const int _maxSize = 100;
        private int _size = 50;

        public int Page { get; set; }
        public int Size { 
            get {return _size;}
            set {_size = Math.Min(_maxSize, value);}
        }
    }
}
