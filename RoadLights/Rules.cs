using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoadLights
{
    class Rules
    {
        public Rules(Tile[,] p_map)
        {
            m_map = p_map;
        }

        public Rules()
        {
            m_map = new Tile[8,5];
            m_map[0, 0] = new Tile(new Point(0, 0));
            m_map[1, 0] = new Tile(new Point(155, 0), true, (int)lights.off, (int)tileStatus.common);
            m_map[2, 0] = new Tile(new Point(310, 0));
            m_map[3, 0] = new Tile(new Point(465, 0), true, (int)lights.off, (int)tileStatus.common);
            m_map[4, 0] = new Tile(new Point(620, 0));
            m_map[5, 0] = new Tile(new Point(775, 0), true, (int)lights.off, (int)tileStatus.common);
            m_map[6, 0] = new Tile(new Point(930, 0));
            m_map[7, 0] = new Tile(new Point(1085, 0), true, (int)lights.off, (int)tileStatus.common);

            m_map[0, 1] = new Tile(new Point(0, 155), true, (int)lights.off, (int)tileStatus.common);
            m_map[1, 1] = new Tile(new Point(155, 155), true, (int)lights.blockHorizontal, (int)tileStatus.common);
            m_map[2, 1] = new Tile(new Point(310, 155), true, (int)lights.off, (int)tileStatus.common);
            m_map[3, 1] = new Tile(new Point(465, 155), true, (int)lights.blockVertical, (int)tileStatus.common);
            m_map[4, 1] = new Tile(new Point(620, 155), true, (int)lights.off, (int)tileStatus.common);
            m_map[5, 1] = new Tile(new Point(775, 155), true, (int)lights.blockHorizontal, (int)tileStatus.common);
            m_map[6, 1] = new Tile(new Point(930, 155), true, (int)lights.off, (int)tileStatus.common);
            m_map[7, 1] = new Tile(new Point(1085, 155), true, (int)lights.blockHorizontal, (int)tileStatus.common);

            m_map[0, 2] = new Tile(new Point(0, 310));
            m_map[1, 2] = new Tile(new Point(155, 310), true, (int)lights.off, (int)tileStatus.common);
            m_map[2, 2] = new Tile(new Point(310, 310));
            m_map[3, 2] = new Tile(new Point(465, 310), true, (int)lights.off, (int)tileStatus.common);
            m_map[4, 2] = new Tile(new Point(620, 310));
            m_map[5, 2] = new Tile(new Point(775, 310), true, (int)lights.off, (int)tileStatus.common);
            m_map[6, 2] = new Tile(new Point(930, 310));
            m_map[7, 2] = new Tile(new Point(1085, 310), true, (int)lights.off, (int)tileStatus.common);

            m_map[0, 3] = new Tile(new Point(0, 465), true, (int)lights.off, (int)tileStatus.exit);
            m_map[1, 3] = new Tile(new Point(155, 465), true, (int)lights.blockVertical, (int)tileStatus.common);
            m_map[2, 3] = new Tile(new Point(310, 465), true, (int)lights.off, (int)tileStatus.common);
            m_map[3, 3] = new Tile(new Point(465, 465), true, (int)lights.blockHorizontal, (int)tileStatus.common);
            m_map[4, 3] = new Tile(new Point(620, 465));
            m_map[5, 3] = new Tile(new Point(775, 465), true, (int)lights.blockVertical, (int)tileStatus.common);
            m_map[6, 3] = new Tile(new Point(930, 465), true, (int)lights.off, (int)tileStatus.common);
            m_map[7, 3] = new Tile(new Point(1085, 465), true, (int)lights.blockHorizontal, (int)tileStatus.common);

            m_map[0, 4] = new Tile(new Point(0, 620));
            m_map[1, 4] = new Tile(new Point(155, 620), true, (int)lights.off, (int)tileStatus.exit);
            m_map[2, 4] = new Tile(new Point(310, 620));
            m_map[3, 4] = new Tile(new Point(465, 620));
            m_map[4, 4] = new Tile(new Point(620, 620));
            m_map[5, 4] = new Tile(new Point(775, 620));
            m_map[6, 4] = new Tile(new Point(930, 620));
            m_map[7, 4] = new Tile(new Point(1085, 620), true, (int)lights.off, (int)tileStatus.exit);
        }

        static public Point GetDirectionVector(int direction)
        {
            Point vector = new Point();
            switch (direction)
            {
                case (int)directionVector.north:
                    vector = new Point(0, -1);
                    break;
                case (int)directionVector.west:
                    vector = new Point(1, 0);
                    break;
                case (int)directionVector.south:
                    vector = new Point(0, 1);
                    break;
                case (int)directionVector.east:
                    vector = new Point(-1, 0);
                    break;
            }
            return vector;
        }

        public void Turn()
        {
            for(int i=0;i<m_machines.Count;i++)
            {
                //Проверка на достижение машинкой тайла выхода
                if (m_map[m_machines[i].GetLocation.X, m_machines[i].GetLocation.Y].EntryOrExit == (int)tileStatus.exit)
                {
                    //уничтожение машинки;
                    m_map[m_machines[i].GetLocation.X, m_machines[i].GetLocation.Y].IsFree = true; //освобождение тайла
                    m_machines.Remove(m_machines[i]);
                }
                else
                {
                    //получение координат переднего и правого тайла
                    Point[] Coordinates = m_machines[i].GetCoordDestinastionTile();

                    //проверка возможности проезда по переднему и правому тайлу
                    bool[] semaphores = new bool[2];
                    semaphores[0] = (VerifyingCoordinatesExistence(Coordinates[0])) ? CheckDirection(m_map[Coordinates[0].X, Coordinates[0].Y], m_machines[i].GetForwardDirection) : false;
                    semaphores[1] = (VerifyingCoordinatesExistence(Coordinates[1])) ? CheckDirection(m_map[Coordinates[1].X, Coordinates[1].Y], m_machines[i].GetRightDirection) : false;

                    /*выбор направления исходя из возможностей проезда
                     * 0 - стоять на месте
                     * 1 - ехать прямо
                     * 2 - ехать направо
                     */
                    int direction = ChooseDirection(semaphores[0], semaphores[1]);

                    if (direction != (int)moveType.stop) //если движение
                        m_map[m_machines[i].GetLocation.X, m_machines[i].GetLocation.Y].IsFree = true; //освобождение тайла
                    m_machines[i].Move(direction);  //движение
                    m_map[m_machines[i].GetLocation.X, m_machines[i].GetLocation.Y].IsFree = false; //занятие тайла
                }
            }
        }

        public bool CreateMachine(Point p_coordinates, int p_direction, Image p_view)
        {
            bool canContinue = true;
            if (m_map[p_coordinates.X, p_coordinates.Y].IsFree)
            {
                m_map[p_coordinates.X, p_coordinates.Y].IsFree = false;
                m_machines.Add(new Car(p_coordinates, p_direction, p_view));
            }
            else canContinue = false;
            return canContinue;
        }

        
        bool VerifyingCoordinatesExistence(Point p_coordinates)
        {
            if ((p_coordinates.X >= m_map.GetLowerBound(0)) && (p_coordinates.X <= m_map.GetUpperBound(0))
                && (p_coordinates.Y >= m_map.GetLowerBound(1)) && (p_coordinates.Y <= m_map.GetUpperBound(1)))
                return true;
            else return false;
        }

        bool CheckDirection(Tile tile, int direction)
        {
            bool semaphoresDirections = false;
            if (tile.IsRoad)
                if (tile.CheckLight(direction))
                    if (tile.IsFree)
                        semaphoresDirections = true;
            return semaphoresDirections;
        }

        int ChooseDirection(bool forwardSemaphore, bool rightSemaphore)
        {
            int finallyDrection = 0;
            if (forwardSemaphore && rightSemaphore)
            {
                Random chooser = new Random(1);
                finallyDrection = chooser.Next(1, 3);
            }
            else if (forwardSemaphore && !rightSemaphore)
                finallyDrection = 1;
            else if (!forwardSemaphore && rightSemaphore)
                finallyDrection = 2;
            return finallyDrection;
        }

        

        public Tile FindTile(Point clickpoint)
        {
            foreach (Tile q in m_map)
                if ((clickpoint.X >= q.GetCoordinates.X) &&
                    (clickpoint.X <= q.GetCoordinates.X + 155) &&
                    (clickpoint.Y >= q.GetCoordinates.Y) &&
                    (clickpoint.Y <= q.GetCoordinates.Y + 155))
                    return q;
            return null;
        }

        public void DrawMap(Graphics platform)
        {
            foreach (Tile tile in m_map)
            {
                tile.Draw(platform);
            }
        }

        public void DrawCars(Graphics platform)
        {
            foreach (Car car in m_machines)
            {
                car.Draw(platform);
            }
        }

        List<Car> m_machines = new List<Car>();

        Tile[,] m_map;
    }
}