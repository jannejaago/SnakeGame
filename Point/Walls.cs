using System;
using System.Collections.Generic;
using System.Text;

namespace Point
{

    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            Random rnd = new Random();
            int obstacleBeginningXCoordinate = rnd.Next(1, mapWidth-4);
            int obstacleLength = rnd.Next(1, mapWidth - obstacleBeginningXCoordinate);
            int obstacleYCoordinate = rnd.Next(0, mapHeight - 2);
            wallList = new List<Figure>();
            HorizontalLine topLine = new HorizontalLine(0, mapWidth - 2, 0, '#');
            HorizontalLine bottomLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '#');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '#');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '#');
            HorizontalLine obstacleLine = new HorizontalLine(obstacleBeginningXCoordinate, obstacleBeginningXCoordinate+obstacleLength, obstacleYCoordinate, '#');
            wallList.Add(topLine);
            wallList.Add(bottomLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
            wallList.Add(obstacleLine);
        }
        public void DrawWalls()
        {
            foreach(Figure wall in wallList)
            {
                wall.DrawFigure();
            }
        }

        public bool IsHitByFigure(Figure figure)
        {
            foreach(Figure wall in wallList)
            {
                if (wall.IsHitByFigure(figure))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
