using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoadLights
{
    enum directionVector { north = 1, west, south, east };

    enum moveType { stop, forward, right };

    class Car
    {
        public static Point operator+(Car a, Point b)
        {
            return new Point(a.m_location.X + b.X, a.m_location.Y + b.Y);
        }

        //конструткор
        public Car(Point p_coordinates, int direction, Image view)
        {
            m_image = view;
            m_location = p_coordinates;
            m_forwardDirection = (direction <=(int)directionVector.east ) ? direction : (int)directionVector.north;
        }

        public Point[] GetCoordDestinastionTile()
        {
            Point[] coordinates = new Point[2];
            coordinates[0] = this + Rules.GetDirectionVector(m_forwardDirection);
            coordinates[1] = this + Rules.GetDirectionVector(GetRightDirection);
            return coordinates;
        }

        public void Move(int direction)
        {
            switch (direction)
            {
                case (int)moveType.stop:    
                    break;
                case (int)moveType.forward: 
                    m_location = this + Rules.GetDirectionVector(m_forwardDirection);
                    break;
                case (int)moveType.right:   
                    m_location = this + Rules.GetDirectionVector(GetRightDirection);
                    GetForwardDirection = m_forwardDirection+1;
                    m_image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
        }

        public int GetForwardDirection
        {
            get { return m_forwardDirection; }
            set { m_forwardDirection = ((value >= (int)directionVector.north) && (value <= (int)directionVector.east)) ? value : (int)directionVector.north; }
        }

        public int GetRightDirection
        {
            get { return (m_forwardDirection != (int)directionVector.east) ? m_forwardDirection+1 : (int)directionVector.north; }
        }

        public Point GetLocation
        {
            get { return m_location; }
            set { m_location = value; }
        }

        public void Draw(Graphics platform)
        {
            platform.DrawImage(m_image, new Point(155 * m_location.X + 50, 155 * m_location.Y + 50));
        }

        Image m_image;
        Point m_location;
        int m_forwardDirection;
    }
}
