﻿using Rhythm.BL.Interfaces;
using Rhythm.BL.Models;
using Rhythm.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Rhythm.BL.Provider
{
    public class ArchiveProvider : IArchiveProvider
    {
        private List<Post> _postsList;
        private List<Archive> _archives = new List<Archive>();
        private int current = -1;

        public object Current
        {
            get
            {
                return _archives[current];
            }
        }

        public ArchiveProvider(List<Post> postsList)
        {
            _postsList = postsList;
            AddArchives();
        }

        public IEnumerator GetEnumerator()
        {
            return _archives.GetEnumerator();
        }

        public bool MoveNext()
        {
            current++;
            return current < _archives.Count;
        }

        public void Reset()
        {
            current = -1;
        }

        public void AddArchives()
        {
            var dateTimeFormatInfo = new DateTimeFormatInfo();

            var group = _postsList.GroupBy(p => new { p.PostedOn.Year, p.PostedOn.Month })
                .OrderByDescending(g => g.Key.Year)
                .ThenByDescending(g => g.Key.Month);

            var archives = group.Select(g => new Archive
            {
                MonthYear = string.Format($"{dateTimeFormatInfo.GetMonthName(g.Key.Month)} {g.Key.Year} ({g.Count()})"),
                Year = g.Key.Year.ToString(CultureInfo.InvariantCulture),
                Month = g.Key.Month.ToString("00")
            }).ToList();

            _archives.AddRange(archives);
        }
    }
}
