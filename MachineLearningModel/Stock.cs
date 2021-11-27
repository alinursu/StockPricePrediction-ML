using System;

namespace MachineLearningModel
{
    public class Stock
    {
        private DateTime _date;
        private float _open;
        private float _high;
        private float _low;
        private float _close;
        private float _adjClose;
        private int _volume;

        public Stock(DateTime date, float open, float high, float low, float close, float adjClose, int volume)
        {
            _date = date;
            _open = open;
            _high = high;
            _low = low;
            _close = close;
            _adjClose = adjClose;
            _volume = volume;
        }
    }
}