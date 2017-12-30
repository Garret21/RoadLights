using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace RoadLights
{
    enum lights { off, blockHorizontal, blockVertical };

    enum tileStatus { common, entry, exit };

    class Tile
    {
        public Tile()
        {
            m_coordinates = new Point(0, 0);
            m_isRoad = false;
            m_isFree = false;
            m_light = (int)lights.off;
            m_entryOrExit = (int)tileStatus.common;
            m_image = GetImage;
        }

        public Tile(Point coordinates)
        {
            m_coordinates = coordinates;
            m_isRoad = false;
            m_isFree = false;
            m_image = GetImage;
        }

        public Tile(Point coordinates,
                    bool isRoad,
                    int light,
                    int entryOrExit)
        {
            m_coordinates = coordinates;
            m_isRoad = isRoad;
            m_light = light;
            m_isFree = true;
            m_entryOrExit = entryOrExit;
            m_image = GetImage;
        }

        Image GetImage
        {
            get
            {
                if (!m_isRoad) m_image = ImageResourses.EmptyTile;
                else switch (m_light)
                    {
                        case (int)lights.off:
                            m_image = ImageResourses.RoadTile;
                            break;
                        case (int)lights.blockHorizontal :
                            m_image = ImageResourses.RoadTileLightOnWE;
                            break;
                        case (int)lights.blockVertical:
                            m_image = ImageResourses.RoadTileLightOnSN;
                            break;
                    }
                return m_image;
            }
        }

        public void Draw(Graphics platform)
        {
            platform.DrawImage(GetImage, m_coordinates);
        }

        public void ChangeLight()
        {
            switch (m_light)
            {
                case (int)lights.blockHorizontal:
                    m_light = (int)lights.blockVertical;
                    break;
                case (int)lights.blockVertical:
                    m_light = (int)lights.blockHorizontal;
                    break;
            }
        }

        public bool CheckLight(int direction)
        {
            bool flag = false;
            switch (m_light)
            {
                case (int)lights.off:
                    flag = true;
                    break;
                case (int)lights.blockHorizontal:
                    flag = ((direction == (int)directionVector.north) || (direction == (int)directionVector.south));
                    break;
                case (int)lights.blockVertical:
                    flag = ((direction == (int)directionVector.west) || (direction == (int)directionVector.east));
                    break;
            }
            return flag;
        }

        public bool IsRoad
        {
            get { return m_isRoad; }
        }

        public bool IsFree
        {
            get { return m_isFree; }
            set { m_isFree = value; }
        }

        public int EntryOrExit
        {
            get { return m_entryOrExit;}
        }

        public Point GetCoordinates
        {
            get { return m_coordinates; }
        }

        Image m_image;
        Point m_coordinates;
        bool m_isRoad;
        bool m_isFree;
        int m_light;   
        int m_entryOrExit;
    }
}