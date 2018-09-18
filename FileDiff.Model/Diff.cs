using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using FileDiff.Model;

namespace Model.FileDiff
{
    public class Diff 
    {
        private readonly List<string> _firstLines;
        private readonly List<string>_secondLines;

        private int[,] _matrix;
        private int _preSkip;
        private int _postSkip;

        private readonly List<DiffLine> _diffLines;

        public Diff(List<string> firstLines, List<string> secondLines)
        {
            _firstLines = firstLines;
            _secondLines = secondLines;

            _diffLines = new List<DiffLine>();

        }

        public List<DiffLine> GetDiffList()
        {
            if (_matrix == null)
            {
                ApplyOptimization();
                CreateMatrix();
            }

            GenerateDiffLines();

            return _diffLines;
        }

        /// <summary>
        /// Заполняет массив модицифированных строк
        /// </summary>
        public void GenerateDiffLines()
        {
            for (var i = 0; i < _preSkip; i++)
                CreateDiffLine(DiffType.None, _firstLines[i]);

            var totalSkip = _preSkip + _postSkip;
            GetDiff(_firstLines.Count - totalSkip, _secondLines.Count - totalSkip);

            var firstLinesCount = _firstLines.Count;

            for (var i = _postSkip; i > 0; i--)
                CreateDiffLine(DiffType.None, _firstLines[firstLinesCount - i]);
           
        }
        /// <summary>
        /// Производит первоначальную оптимизацию
        /// </summary>
        private void ApplyOptimization()
        {
            CalculatePreSkip();
            CalculatePostSkip();
        }

        /// <summary>
        /// Пропускает одинаковые строки с начала списков
        /// </summary>
        private void CalculatePostSkip()
        {
            var firstLinesCount = _firstLines.Count;
            var secondLinesCount = _secondLines.Count;

            while (_postSkip < firstLinesCount && _postSkip < secondLinesCount &&
                   Compare(_firstLines[firstLinesCount - _postSkip - 1],
                       _secondLines[secondLinesCount - _postSkip - 1]))
            {
                _postSkip++;
            }
        }

        /// <summary>
        /// Пропускает одинаковые строки с конца списков
        /// </summary>
        private void CalculatePreSkip()
        {
            var firstLinesCount = _firstLines.Count;
            var secondLinesCount = _secondLines.Count;

            while (_preSkip < firstLinesCount && _preSkip < secondLinesCount &&
                   Compare(_firstLines[_preSkip], _secondLines[_preSkip]))
            {
                _preSkip++;
            }
        }

        /// <summary>
        /// Проходит по матрице и заполняет массив модифицированных строк второго файла с соответсвующим статусом
        /// </summary>
        /// <param name="firstLinesIndex"></param>
        /// <param name="secondLinesIndex"></param>
        private void GetDiff(int firstLinesIndex, int secondLinesIndex)
        {
            if (firstLinesIndex > 0 && secondLinesIndex > 0 &&
                Compare(_firstLines[_preSkip + firstLinesIndex - 1], _secondLines[_preSkip + secondLinesIndex - 1]))
            {
                GetDiff(firstLinesIndex - 1, secondLinesIndex - 1);
                CreateDiffLine(DiffType.None, _firstLines[_preSkip + firstLinesIndex - 1]);
            }
            else
            {
                if (secondLinesIndex > 0 &&
                    (firstLinesIndex == 0 ||
                     _matrix[firstLinesIndex, secondLinesIndex - 1] >= _matrix[firstLinesIndex - 1, secondLinesIndex]))
                {
                    GetDiff(firstLinesIndex, secondLinesIndex - 1);
                    CreateDiffLine(DiffType.Add, _secondLines[_preSkip + secondLinesIndex - 1]);
                }
                else if (firstLinesIndex > 0 &&
                         (secondLinesIndex == 0 ||
                          _matrix[firstLinesIndex, secondLinesIndex - 1] <
                          _matrix[firstLinesIndex - 1, secondLinesIndex]))
                {
                    GetDiff(firstLinesIndex - 1, secondLinesIndex);
                    CreateDiffLine(DiffType.Delete, _firstLines[_preSkip + firstLinesIndex - 1]);
                }
            }

        }

        private void CreateMatrix()
        {
            var totalSkip = _preSkip + _postSkip;

            if (totalSkip >= _firstLines.Count || totalSkip >= _secondLines.Count)
                return;

            _matrix = new int[_firstLines.Count - totalSkip + 1, _secondLines.Count - totalSkip + 1];

            for (var i = 1; i <= _firstLines.Count - totalSkip; i++)
            {
                var firstFileIndex = _preSkip + i - 1;

                for (int j = 1, secondLinesIndex = _preSkip + 1; j <= _secondLines.Count - totalSkip; j++, secondLinesIndex++)
                {
                    _matrix[i, j] = Compare(_firstLines[firstFileIndex], _secondLines[secondLinesIndex - 1]) ?
                        _matrix[i - 1, j - 1] + 1 :
                        Math.Max(_matrix[i, j - 1], _matrix[i - 1, j]);
                }
            }

        }

        private void CreateDiffLine(DiffType diffType, string lineValue)
        {
            _diffLines.Add(new DiffLine(diffType, lineValue));
        }

        private bool Compare(string left, string right)
        {
            return Equals(left, right);
        }

    }

}
