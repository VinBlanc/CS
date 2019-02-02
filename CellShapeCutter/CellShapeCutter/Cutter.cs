using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellShapeCutter
{
    public class Cutter
    {
        public static List<List<T>> CutToCellShape<T>(
            List<T> rawData,
            int cellColNum)
        {
            int maxColNum = rawData.Count();
            var tmp = new List<List<T>> ();
            
            for(int i=0; i < maxColNum/cellColNum; i++)
            {
                tmp.Add(rawData.GetRange(i*cellColNum, cellColNum));
            }
            return tmp;
        }

        public static List<List<T>> CutToCellShape<T>(
            List<List<T>> rawData,
            int cellColNum,
            int cellRowNum)
        {
            int maxRowNum = rawData.Count();
            int maxColNum = rawData.ElementAt(0).Count();

            var tmp = new List<List<T>>();

            for (int i = 0; i < maxRowNum / cellRowNum; i++)
            {
                var line = rawData.GetRange(i * cellRowNum, cellRowNum);
                for (int j = 0; j < maxColNum / cellColNum; j++)
                {
                    var cell = line.SelectMany(
                        e => e.GetRange(j * cellColNum, cellColNum))
                        .ToList();
                    tmp.Add(cell);
                }
            }
            return tmp;
        }

        private static bool IsCellShapeCorrect(
            List<List<string>> rawData, 
            int cellRowNum, 
            int cellColNum,
            int maxColNum,
            int maxRowNum)
        {
            if (maxRowNum / cellRowNum != 0) return false;
            if (maxColNum / cellColNum != 0) return false;
            return true;
        }

        private static bool IsSquareShape(
            List<List<string>> rawData)
        {
            int rowNumStd = rawData.ElementAt(0).Count();
            var a = rawData
                .Select(line => line.Count())
                .Where(rowNum => rowNum == rowNumStd);

            return true;
        }
    }
}
