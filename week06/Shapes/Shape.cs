using System;

namespace Shapes
{
    public class Shape
    {
        private string _color;

        public Shape(string color)
        {
            _color = color;
        }

        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        public virtual double GetArea()
        {
            // Base implementation returns 0
            // Derived classes will override this method
            return 0;
        }
    }
}